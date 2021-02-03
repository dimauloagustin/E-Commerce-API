cd ($PSScriptRoot + "\..")

get-childitem -Include "TestResults" -Recurse -force | Remove-Item -Force -Recurse

dotnet test src --collect:"XPlat Code Coverage"

[array]$files=Get-ChildItem -Include coverage.cobertura.xml -Recurse -File| select -expand fullname

$reportArgs="-reports:" + ($files -join ';')

reportgenerator $reportArgs "-targetdir:coveragereport" -reporttypes:Html