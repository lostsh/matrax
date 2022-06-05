$base_dir = "bin/"
$exe_dir = $base_dir+"matrax/"

if(-not(Test-Path $exe_dir -PathType Container)){ 
    Write-Output "[=]`tDownload binaryes [$exe_dir]" 
    Invoke-WebRequest -Uri https://github.com/lostsh/matrax/releases/download/V1.0/matrax_win-x64.zip -ContentType application/x-zip-compressed -OutFile matrax.zip
    Expand-Archive -LiteralPath 'matrax.zip' -DestinationPath $base_dir
    Remove-Item .\matrax.zip 
    Write-Output "[+]`tDone" 
}

Write-Output "[+]`tStart matrax "(-join($exe_dir, "Matrax.exe"))
Start-Process -FilePath (-join($exe_dir, "Matrax.exe"))