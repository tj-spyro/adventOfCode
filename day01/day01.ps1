[int[]]$modules = Get-Content -Path .\input.txt

#$modules = @(12, 14, 1969,100756)

function CalculateFuel{
    Param(
        [int]$mass
    )

    $result = [System.Math]::Floor($mass / 3) - 2

    if($result -lt 0)
    {
        $result = 0
    }
    return $result
}

function CalculateExtraFuel{
    Param(
        [int]$fuel
    )

    [int[]]$extraFuels =@()
    while($true)
    {
        $fuel = CalculateFuel -mass $fuel
        
        if($fuel -le 0)
        {
            $totalExtra = 0
            $extraFuels | %{$totalExtra += $_}
            return $totalExtra
            break
        }
        $extraFuels += $fuel
    }
}

$totalFuel = 0
foreach($moduleMass in $modules)
{
    $moduleFuel = CalculateFuel -mass $moduleMass
    $extraFuel = CalculateExtraFuel -fuel $moduleFuel    

    $totalFuel += ($moduleFuel + $extraFuel)
    Write-Host "Module mass: $moduleMass, fuel needed: $moduleFuel, extra fuel needed: $extraFuel, running total fuel: $totalFuel"
}
Write-Host "Total Fuel required: $totalFuel"