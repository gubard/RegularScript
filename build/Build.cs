using System;
using System.IO;
using System.Linq;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Commands;
using Ductus.FluentDocker.Services;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Serilog;
using SmartFormat;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    public const string DefaultPostgresDockerConfigurationFileName = "PostresSql.yml";
    public static int Main() => Execute<Build>(x => x.Docker);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] Solution Solution { get; set; }
    [Parameter] AbsolutePath PostgresDockerTemplateConfigurationFilePath { get; set; }
    [Parameter] public AbsolutePath TempFolderPath { get; set; }
    [Parameter] public string PostgresContainerName { get; set; } = "regular_script_postgres";
    [Parameter] public string PostgresImageName { get; set; } = "postgres";
    [Parameter] public string PostgresPassword { get; set; } = "QAZ78963wsx";
    [Parameter] public string PostgresUser { get; set; } = "postgresuser";
    [Parameter] public string PostgresDataBaseName { get; set; } = "regular_script";
    [Parameter] public string PostgresDataFilePath { get; set; } = "~/postgres/data";
    [Parameter] public ushort PostgresPort { get; set; } = 1713;

    protected override void OnBuildInitialized()
    {
        base.OnBuildInitialized();
        TempFolderPath ??= Solution.Directory / ".." / "temp";

        PostgresDockerTemplateConfigurationFilePath ??=
            Solution.Directory / ".." / "build" / "DockerFileTemplates" / DefaultPostgresDockerConfigurationFileName;
    }

    Target Restore => _ => _
        .Executes(() => DotNetRestore(setting => setting.SetProjectFile(Solution.Path)));

    Target Clean => _ => _
        .DependsOn(Restore)
        .Executes(() => DotNetClean(setting => setting.SetProject(Solution.Path)
            .SetConfiguration(Configuration)));

    Target Compile => _ => _
        .DependsOn(Clean)
        .Executes(() => DotNetBuild(settings => settings.SetProjectFile(Solution.Path)
            .SetConfiguration(Configuration)));

    Target Tests => _ => _
        .DependsOn(Compile)
        .Executes(() => DotNetTest(settings => settings.SetProjectFile(Solution.Path)
            .SetConfiguration(Configuration)));

    Target DockerStopContainers => _ => _
        .Executes(() =>
        {
            var hosts = new Hosts().Discover();
            var docker = hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");
            var psCommandResponse = docker.Host.Ps($"--all --filter name={PostgresContainerName}");

            if (!string.IsNullOrWhiteSpace(psCommandResponse.Error))
            {
                throw new Exception(psCommandResponse.Error);
            }
            
            Log.Information("List {PostgresContainerName}", PostgresContainerName);

            foreach (var log in psCommandResponse.Log)
            {
                Log.Information(log);
            }

            var containerId = psCommandResponse.Data.SingleOrDefault();

            if (string.IsNullOrWhiteSpace(containerId))
            {
                return;
            }

            var stopCommandResponse = docker.Host.Stop(containerId);

            if (!string.IsNullOrWhiteSpace(stopCommandResponse.Error))
            {
                throw new Exception(stopCommandResponse.Error);
            }
            
            Log.Information("Stop {PostgresContainerName}", PostgresContainerName, containerId);
            
            foreach (var log in stopCommandResponse.Log)
            {
                Log.Information(log);
            }
        });
    
    Target DockerRemoveContainers => _ => _
        .DependsOn(DockerStopContainers)
        .Executes(() =>
        {
            var hosts = new Hosts().Discover();
            var docker = hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");
            var psCommandResponse = docker.Host.Ps($"--all --filter name={PostgresContainerName}");

            if (!string.IsNullOrWhiteSpace(psCommandResponse.Error))
            {
                throw new Exception(psCommandResponse.Error);
            }
            
            Log.Information("List {PostgresContainerName}", PostgresContainerName);
            
            foreach (var log in psCommandResponse.Log)
            {
                Log.Information(log);
            }

            var containerId = psCommandResponse.Data.SingleOrDefault();

            if (string.IsNullOrWhiteSpace(containerId))
            {
                return;
            }

            var removeContainerCommandResponse = docker.Host.RemoveContainer(containerId);

            if (!string.IsNullOrWhiteSpace(removeContainerCommandResponse.Error))
            {
                throw new Exception(removeContainerCommandResponse.Error);
            }
            
            Log.Information("Remove {PostgresContainerName}", PostgresContainerName, containerId);
            
            foreach (var log in removeContainerCommandResponse.Log)
            {
                Log.Information(log);
            }
        });

    Target Docker => _ => _
        .DependsOn(Tests)
        .DependsOn(DockerRemoveContainers)
        .Executes(() =>
        {
            var postgresDockerTemplateConfiguration = File.ReadAllText(PostgresDockerTemplateConfigurationFilePath);

            Log.Information(
                "Loaded postgres docker template configuration from {PostgresDockerTemplateConfigurationFilePath}",
                PostgresDockerTemplateConfigurationFilePath);

            Log.Information("{PostgresDockerTemplateConfiguration}", postgresDockerTemplateConfiguration);

            var options = new
            {
                ContainerName = PostgresContainerName,
                ImageName = PostgresImageName,
                Password = PostgresPassword,
                User = PostgresUser,
                DataBaseName = PostgresDataBaseName,
                DataFilePath = PostgresDataFilePath,
                Port = PostgresPort,
            };

            var postgresDockerConfiguration = Smart.Format(postgresDockerTemplateConfiguration, options);

            if (!Directory.Exists(TempFolderPath))
            {
                Directory.CreateDirectory(TempFolderPath);
                Log.Information("Created temp folder {TempFolderPath}", TempFolderPath);
            }

            var postgresDockerConfigurationFilePath = TempFolderPath / DefaultPostgresDockerConfigurationFileName;
            File.WriteAllText(postgresDockerConfigurationFilePath, postgresDockerConfiguration);

            Log.Information(
                "Save postgres docker configuration in {PostgresDockerConfigurationFilePath}",
                postgresDockerConfigurationFilePath);

            Log.Information("{PostgresDockerConfiguration}", postgresDockerConfiguration);

            new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(postgresDockerConfigurationFilePath)
                .Build()
                .Start();
        });
}