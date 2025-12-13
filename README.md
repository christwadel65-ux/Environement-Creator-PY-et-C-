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

## Git Setup
- Remote: `origin` → `https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-.git`
- Default branch: `main`

### .gitignore
Build folders are excluded, only published artifacts are kept:

```
bin/
obj/
!bin/Release/**/publish/
!bin/Release/**/publish/**
```

### Git LFS (Large File Storage)
Binaries in the publish folder are tracked with LFS to keep the repo lean:

```
bin/Release/**/publish/*.exe filter=lfs diff=lfs merge=lfs -text
bin/Release/**/publish/*.dll filter=lfs diff=lfs merge=lfs -text
bin/Release/**/publish/*.pdb filter=lfs diff=lfs merge=lfs -text
bin/Release/**/publish/*.baml filter=lfs diff=lfs merge=lfs -text
```

Initialize locally if needed:

```bash
git lfs install
```

## Notes
- Old WinForms files are excluded from compilation; WPF `MainWindow` is the entry point.
- If the EXE is in use, close it before rebuilding to avoid file lock warnings.
