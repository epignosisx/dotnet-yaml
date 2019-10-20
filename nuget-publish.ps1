$version = Read-Host -Prompt "Enter version to publish"
$nugetKey = Read-Host -Prompt "Enter nuget key"

Remove-Item -Path "./src/dotnet-yaml/bin/Release" -Force -Recurse
& dotnet build --configuration "Release"
& dotnet test --configuration "Release"
Push-Location "./src/dotnet-yaml"
& dotnet pack --configuration "Release" --no-build --no-restore
& dotnet nuget push "./bin/Release/dotnet-yaml.$version.nupkg" -k $nugetKey -s https://api.nuget.org/v3/index.json
Pop-Location