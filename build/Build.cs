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
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
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
            Solution.Directory / ".." / "build" / "DockerFileTemplates" / "PostresSQL.yml";
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

    Target Docker => _ => _
        .DependsOn(Tests)
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

            var postgresDockerConfigurationFilePath = TempFolderPath / "PostresSQL.yml";
            File.WriteAllText(postgresDockerConfigurationFilePath, postgresDockerConfiguration);

            Log.Information(
                "Save postgres docker configuration in {PostgresDockerConfigurationFilePath}",
                postgresDockerConfigurationFilePath);

            Log.Information("{PostgresDockerConfiguration}", postgresDockerConfiguration);
            var hosts = new Hosts().Discover();
            var docker = hosts.FirstOrDefault(x => x.IsNative) ?? hosts.FirstOrDefault(x => x.Name == "default");
            var containers = docker.Host.Ps($"--all --filter name={PostgresContainerName}");

            if (!string.IsNullOrWhiteSpace(containers.Error))
            {
                throw new Exception(containers.Error);
            }

            var containerId = containers.Data.SingleOrDefault();

            if (!string.IsNullOrWhiteSpace(containerId))
            {
                var stop = docker.Host.Stop(containerId);

                if (!string.IsNullOrWhiteSpace(stop.Error))
                {
                    throw new Exception(stop.Error);
                }

                var run = docker.Host.RemoveContainer(containerId);

                if (!string.IsNullOrWhiteSpace(run.Error))
                {
                    throw new Exception(run.Error);
                }
            }

            new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(postgresDockerConfigurationFilePath)
                .Build()
                .Start();
        });
}