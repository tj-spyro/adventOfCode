[int[]]$modules = Get-Content -Path .\input.txt

#$modules = @(12, 14, 1969,100756)

$fuel = 0
foreach($module in $modules)
{
    $result = [System.Math]::Floor($module / 3) - 2
    $fuel = $fuel + $result
    Write-Host "Module mass: $module, fuel needed: $result, running total fuel: $fuel"
}
Write-Host "Total Fuel required: $fuel"