# Set versions for AssemblyInfo.cs
$version = ( Get-Content .\Version.txt );
$env:AssemblyBaseVersion = $version | foreach{ if( $_ -match "^\d+\.\d+" ){ $matches[0] } }
if ( $env:APPVEYOR_REPO_TAG -ne "True" )
{
	if ( ${env:APPVEYOR_BUILD_NUMBER} -eq $null )
	{
		$now = [DateTime]::UtcNow
		$daysSpan = $now - ( New-Object DateTime( $now.Year, 1, 1 ) )
		$env:PackageVersion = "${version}-dev-{0:yy}{1:000}" -f @( $now, $daysSpan.Days )
	}
	elseif ( ${version} -match "^[\d.]+$" )
	{
		$env:PackageVersion = "${version}-final-${env:APPVEYOR_BUILD_NUMBER}"
	}
	else
	{
		$env:PackageVersion = "${version}-dev-${env:APPVEYOR_BUILD_NUMBER}"
	}
}
else
{
	$env:PackageVersion = $version
}

Write-Information "version:'${version}', AssemblyBaseVersion:'${AssemblyBaseVersion}', PackageVersion:'${PackageVersion}'"
