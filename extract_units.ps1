$filePath = "h:\src\OpenFlows\Base\Haestad.Support\dev\Haestad.Support\Units\UnitConversionManager.cs"
$content = [System.IO.File]::ReadAllText($filePath)

$startIndex = $content.IndexOf("void InitializeUnits()")
$openBrace = $content.IndexOf("{", $startIndex)
$braceCount = 1
$currentIndex = $openBrace + 1
while ($braceCount -gt 0 -and $currentIndex -lt $content.Length) {
    if ($content[$currentIndex] -eq '{') { $braceCount++ }
    elseif ($content[$currentIndex] -eq '}') { $braceCount-- }
    $currentIndex++
}
$body = $content.Substring($openBrace, $currentIndex - $openBrace)

$results = @()
# Using a regex that accounts for tabs (more accurately \s)
$matches = [regex]::Matches($body, 'new\s+(Unit|CurrencyBasedUnit)\s*\((.*?)\)', [System.Text.RegularExpressions.RegexOptions]::Singleline)

foreach ($m in $matches) {
    $typeName = $m.Groups[1].Value
    # Collapse multiple whitespaces (including tabs/newlines) into single space
    $argsString = [regex]::Replace($m.Groups[2].Value, '\s+', ' ')
    
    $args = @()
    $currentArg = ""
    $parenDepth = 0
    foreach ($char in $argsString.ToCharArray()) {
        if ($char -eq '(') { $parenDepth++ }
        elseif ($char -eq ')') { $parenDepth-- }
        if ($char -eq ',' -and $parenDepth -eq 0) {
            $args += $currentArg.Trim()
            $currentArg = ""
        } else {
            $currentArg += $char
        }
    }
    $args += $currentArg.Trim()

    if ($args.Count -ge 4) {
        $unitName = $args[0].Trim('"').Trim()
        $dimension = $args[1]
        
        $factor = $args[3]
        $isSupported = ($typeName -match "Unit|CurrencyBasedUnit") -and ($factor -notmatch "new ")

        $results += [PSCustomObject]@{
            TypeName = $typeName
            UnitName = $unitName
            Dimension = $dimension
            Factor = $factor
            Supported = $isSupported
        }
    }
}

$results | Export-Csv -Path "i:\github\UnitRegistry\dummy\haestad-units-extracted.csv" -NoTypeInformation
$results | Where-Object { $_.Supported -eq $true } | Export-Csv -Path "i:\github\UnitRegistry\dummy\haestad-units-supported.csv" -NoTypeInformation

$total = $results.Count
$supported = ($results | Where-Object { $_.Supported -eq $true }).Count
$unsupported = $total - $supported
Write-Output "Total extracted: $total"
Write-Output "Supported: $supported"
Write-Output "Unsupported: $unsupported"
