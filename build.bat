rmdir /s /q build

dotnet publish SEVNLauncher -c Release -r win-x64 /p:PublishSingleFile=true -o build/win