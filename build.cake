var target = Argument("target", "Run");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    
    .Does(() =>
{
    CleanDirectory($"./bin/{configuration}");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./cakeExample.csproj", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
    
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreRun("./cakeExample.csproj");
    
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);