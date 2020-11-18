var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var solution = "./EWSOAuthDemo.sln";
var buildDir = Directory("./EWSOAuthDemo/bin") + Directory(configuration);


Task("Clean")
	.Does(() => {
		CleanDirectory(buildDir);
	});

Task("Restore-NuGet-Packages") 
	.IsDependentOn("Clean")
	.Does(() => {
		NuGetRestore(solution);
	});


Task("Build")
	.IsDependentOn("Restore-NuGet-Packages")
	.Does(() => {
		MSBuild(solution, settings => settings.SetConfiguration(configuration));
	});


Task("Default")
    .IsDependentOn("Build");

RunTarget(target);