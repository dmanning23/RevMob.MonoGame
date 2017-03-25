rm *.nupkg
nuget pack .\RevMobBuddy.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push -source https://www.nuget.org -NonInteractive *.nupkg