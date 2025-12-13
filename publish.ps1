# Publish script: build, copy artifacts to root publish, optional commit, create release zip
param(
    [switch]$Commit,
    [string]$Message = "chore: update publish artifacts",
    [switch]$Zip,
    [string]$Version = "1.0.0"
)

Write-Host "Publishing EnvironmentCreator (Release, win-x64, self-contained)" -ForegroundColor Cyan

dotnet publish -c Release -r win-x64 --self-contained
if ($LASTEXITCODE -ne 0) { Write-Error "dotnet publish failed"; exit 1 }

$src = Join-Path $PSScriptRoot "bin/Release/net10.0-windows/win-x64/publish"
$dst = Join-Path $PSScriptRoot "publish"

if (-not (Test-Path $dst)) { New-Item -ItemType Directory -Path $dst | Out-Null }

Write-Host "Copying artifacts to $dst" -ForegroundColor Cyan
Copy-Item -Recurse -Force "$src/*" "$dst/"

if ($Zip) {
    $zipName = "EnvironmentCreator-$Version-publish.zip"
    $zipPath = Join-Path $PSScriptRoot $zipName
    Write-Host "Creating release archive: $zipName" -ForegroundColor Cyan
    Compress-Archive -Path "$dst/*" -DestinationPath $zipPath -Force
    Write-Host "Archive created: $zipPath (upload to GitHub releases)" -ForegroundColor Green
}

if ($Commit) {
    Write-Host "Committing publish artifacts" -ForegroundColor Cyan
    git add $dst
    git commit -m $Message
    git push
}

Write-Host "Done. Artifacts in: $dst" -ForegroundColor Green
