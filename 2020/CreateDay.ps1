[CmdletBinding()]
param (
  [Parameter(Mandatory)]
  [int]$Day,
  [Parameter(Mandatory)]
  [string]$Title
)

$projectName = "{0:d2}-{1}" -f $Day,$Title.Replace(' ','')
$testProjectName = "{0}.Tests" -f $projectName

dotnet new console -n $projectName
dotnet new nunit -n $testProjectName

dotnet sln add ".\$projectName" ".\$testProjectName"

Push-Location
Set-Location ".\$projectName"

dotnet add package unity
dotnet add reference ..\Tools

Pop-Location
Set-Location ".\$testProjectName"

dotnet add package Moq
dotnet add reference "..\$projectName"

Pop-Location