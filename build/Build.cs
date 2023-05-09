using CliWrap;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Serilog;
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
    AbsolutePath DockerFiles { get; set; }

    protected override void OnBuildInitialized()
    {
        base.OnBuildInitialized();
        DockerFiles = Solution.Directory / ".." / "build" / "DockerFiles";
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
        .Executes(() => Cli.Wrap("docker-compose")
            .WithWorkingDirectory(DockerFiles)
            .WithArguments("-f ./PostresSQL.yml up -d")
            .WithStandardErrorPipe(PipeTarget.ToDelegate(Log.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(Log.Information))
            .ExecuteAsync()
            .GetAwaiter()
            .GetResult());
}