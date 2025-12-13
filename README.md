# Environment Creator

WPF desktop app to scaffold Python or C# environments with common libraries.

## Requirements
- .NET 10.0 SDK (or newer)
- Windows (win-x64 target)

## Run (development)
```bash
cd EnvironmentCreator
dotnet run
```

## Publish (self-contained, win-x64)
```bash
dotnet publish -c Release -r win-x64 --self-contained
# Output: bin/Release/net10.0-windows/win-x64/publish/EnvironmentCreator.exe
```

## Features
- Switch Python / C# library sets (expanders).
- Folder validation (exists + write test file).
- Generates:
  - Python: requirements.txt, main.py, README.md, .gitignore
  - C#: .csproj with selected PackageReference entries, Program.cs, README.md, .gitignore
- UI: single-page, no scroll, buttons anchored.

## Notes
- Old WinForms files are excluded from the build; WPF `MainWindow` is the entry point.
- If the EXE is in use, close it before rebuilding to avoid file lock warnings.
