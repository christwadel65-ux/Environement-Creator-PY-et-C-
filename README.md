# Environment Creator

WPF desktop app to scaffold Python or C# environments with common libraries.

## Requirements
- .NET 10.0 SDK (or newer)
- Windows (win-x64 target)
- Python 3.x (for Python environment creation)

## Run (development)
```bash
cd EnvironmentCreator
dotnet run
```

## Publish (self-contained, win-x64)
```bash
dotnet publish -c Release -r win-x64 --self-contained
# Copy artifacts to root publish folder
Copy-Item -Recurse -Force ./bin/Release/net10.0-windows/win-x64/publish/* ./publish/
# Output: publish/EnvironmentCreator.exe
```

Or use the helper script on Windows:

```powershell
./publish.ps1            # build + copy to publish/
./publish.ps1 -Commit    # build + copy + git add/commit/push
./publish.ps1 -Zip -Version "1.0.0"  # build + create release zip
```

## Features
- Switch Python / C# library sets (expanders).
- Folder validation (exists + write test file).
- **Automatic Python virtual environment creation** (`python -m venv venv`).
- **Automatic package installation** for selected Python libraries.
- Generates:
  - **Python**: requirements.txt, main.py, README.md, .gitignore, venv/ (virtual environment)
  - **C#**: .csproj with selected PackageReference entries, Program.cs, README.md, .gitignore
- UI: single-page, no scroll, buttons anchored.

## Usage
1. Enter `Name` and choose `Path` (use `...` to browse).
2. Select `Environment Type`: Python or C#.
3. Pick desired libraries from the expanders.
4. Click `Create` to scaffold the environment in the chosen folder.
   - **Python**: Creates virtual environment and installs selected packages automatically
   - **C#**: Creates .csproj with NuGet package references
5. Use `Clear` to reset the form.

### Python Environment
After creation, activate the environment:
```bash
cd <your-project-folder>
venv\Scripts\activate  # Windows
# Packages are already installed!
python main.py
```

### C# Environment
After creation, build and run:
```bash
cd <your-project-folder>
dotnet restore
dotnet run
```

## Git Setup
- Remote: `origin` → `https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-.git`
- Default branch: `main`

### .gitignore
Build folders are excluded, only published artifacts are kept:

```
bin/
obj/
publish/
```

### Git LFS (Large File Storage)
Binaries in the publish folder are tracked with LFS to keep the repo lean:

```
/publish/*.exe filter=lfs diff=lfs merge=lfs -text
/publish/*.dll filter=lfs diff=lfs merge=lfs -text
/publish/*.pdb filter=lfs diff=lfs merge=lfs -text
/publish/*.baml filter=lfs diff=lfs merge=lfs -text
```

Initialize locally if needed:

```bash
git lfs install
```

## Notes
- Old WinForms files are excluded from compilation; WPF `MainWindow` is the entry point.
- If the EXE is in use, close it before rebuilding to avoid file lock warnings.
