using System;
using System.IO;
using System.Linq;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Extensions;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Serilog;
using Serviecs;
using SmartFormat;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static System.IO.File;

class Build : NukeBuild
{
    const string DefaultPostgresDockerConfigurationFileName = "PostresSql.yml";

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] Solution Solution { get; set; }
    [Parameter] AbsolutePath PostgresDockerTemplateConfigurationFilePath { get; set; }
    [Parameter] AbsolutePath TemplateAppSettingsFolderPath { get; set; }
    [Parameter] AbsolutePath TempFolderPath { get; set; }
    [Parameter] string DefaultLanguageCodeIso3 { get; set; } = "eng";

    Target SetupAppSettings => _ => _
        .Executes(() =>
        {
            foreach (var project in Solution.Projects)
            {
                var appSettingsFile = project.Directory.GetFiles("appsettings.json").SingleOrDefault();
                Log.Information("Find app setting {AppSettingsFile}", appSettingsFile);

                if (appSettingsFile is null) continue;

                var appSettingsTemplatePath = TemplateAppSettingsFolderPath / $"{project.Name}.json";
                Log.Information("Load app settings {AppSettingsTemplatePath}", appSettingsTemplatePath);
                var appSettingsTemplate = ReadAllText(appSettingsTemplatePath);
                Log.Information("App settings template {AppSettingsTemplate}", appSettingsTemplate);

                var options = new
                {
                    PostgresUser,
                    PostgresPassword,
                    PostgresHost,
                    PostgresPort,
                    PostgresDataBaseName,
                    CertificatePath,
                    CertificatePassword,
                    Url,
                    LogLevelDefault,
                    DefaultLanguageCodeIso3
                };

                var smartFormatter = new Formatter();
                var appSettings = smartFormatter.Format(appSettingsTemplate, options);
                WriteAllText(appSettingsFile, appSettings);
                Log.Information("Save app settings {AppSettingsFile}", appSettingsFile);
            }
        });

    public static int Main() => Execute<Build>(x => x.Result);

    protected override void OnBuildInitialized()
    {
        base.OnBuildInitialized();
        TempFolderPath ??= Solution.Directory / ".." / "temp";

        PostgresDockerTemplateConfigurationFilePath ??=
            Solution.Directory / ".." / "build" / "DockerFileTemplates" / DefaultPostgresDockerConfigurationFileName;

        TemplateAppSettingsFolderPath ??=
            Solution.Directory / ".." / "build" / "AppSettingsTemplates";
    }

    IHostService CreateDockerClient()
    {
        var hosts = new Hosts().Discover();

        var docker = hosts.FirstOrDefault(x => x.IsNative) ??
                     hosts.FirstOrDefault(x => x.Name == "default") ??
                     throw new NullReferenceException("docker");

        return docker;
    }

    #region App Parameters

    [Parameter] string LogLevelDefault { get; set; } = "Debug";
    [Parameter] string CertificatePath { get; set; } = "localhost.pfx";
    [Parameter] string CertificatePassword { get; set; } = "QAZ78963wsx";
    [Parameter] string Url { get; set; } = "https://localhost:5002";

    #endregion

    #region Postgres Parameters

    [Parameter] string PostgresContainerName { get; set; } = "regular_script_postgres";
    [Parameter] string PostgresImageName { get; set; } = "postgres";
    [Parameter] string PostgresPassword { get; set; } = "QAZ78963wsx";
    [Parameter] string PostgresUser { get; set; } = "postgresuser";
    [Parameter] string PostgresDataBaseName { get; set; } = "regular_script";
    [Parameter] string PostgresDataFilePath { get; set; } = "~/postgres/data";
    [Parameter] ushort PostgresPort { get; set; } = 1713;
    [Parameter] string PostgresHost { get; set; } = "localhost";

    #endregion

    #region DotNet

    Target Restore => _ => _
        .DependsOn(SetupAppSettings)
        .Executes(() => DotNetRestore(setting => setting.SetProjectFile(Solution.Path)));

    Target Clean => _ => _
        .DependsOn(Restore)
        .Executes(() => DotNetClean(setting => setting.SetProject(Solution.Path)
            .SetConfiguration(Configuration)));

    Target Compile => _ => _
        .DependsOn(Clean)
        .Executes(() => DotNetBuild(settings => settings.SetProjectFile(Solution.Path)
            .SetConfiguration(Configuration)
            .EnableNoRestore()));

    Target Tests => _ => _
        .DependsOn(Compile)
        .Executes(() => DotNetTest(settings => settings.SetProjectFile(Solution.Path)
            .SetConfiguration(Configuration)
            .EnableNoBuild()
            .EnableNoRestore()));

    #endregion

    #region Docker

    Target DockerStopPostresContainer => _ => _
        .Executes(() =>
        {
            var docker = CreateDockerClient();
            var containerId = docker.GetContainerId(PostgresContainerName);

            if (string.IsNullOrWhiteSpace(containerId)) return;

            docker.StopContainer(containerId, PostgresContainerName);
        });

    Target DockerStopContainers => _ => _
        .DependsOn(DockerStopPostresContainer);

    Target DockerRemovePostresContainer => _ => _
        .DependsOn(DockerStopPostresContainer)
        .Executes(() =>
        {
            var docker = CreateDockerClient();
            var containerId = docker.GetContainerId(PostgresContainerName);

            if (string.IsNullOrWhiteSpace(containerId)) return;

            docker.RemoveContainer(containerId, PostgresContainerName);
        });

    Target DockerRemoveContainers => _ => _
        .DependsOn(DockerRemovePostresContainer);

    Target DockerBuildPostres => _ => _
        .DependsOn(DockerRemovePostresContainer)
        .Executes(() =>
        {
            var postgresDockerTemplateConfiguration = ReadAllText(PostgresDockerTemplateConfigurationFilePath);

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
                Port = PostgresPort
            };

            var postgresDockerConfiguration = Smart.Format(postgresDockerTemplateConfiguration, options);

            if (!Directory.Exists(TempFolderPath))
            {
                Directory.CreateDirectory(TempFolderPath);
                Log.Information("Created temp folder {TempFolderPath}", TempFolderPath);
            }

            var postgresDockerConfigurationFilePath = TempFolderPath / DefaultPostgresDockerConfigurationFileName;
            WriteAllText(postgresDockerConfigurationFilePath, postgresDockerConfiguration);

            Log.Information(
                "Save postgres docker configuration in {PostgresDockerConfigurationFilePath}",
                postgresDockerConfigurationFilePath);

            new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(postgresDockerConfigurationFilePath)
                .Build()
                .Start();
        });

    Target DockerBuild => _ => _
        .DependsOn(DockerBuildPostres);

    #endregion

    #region Result

    Target ResultDotnet => _ => _
        .Inherit(Tests);

    Target ResultDocker => _ => _
        .DependsOn(ResultDotnet)
        .Inherit(DockerBuild);

    Target Result => _ => _
        .DependsOn(ResultDocker);

    #endregion
}