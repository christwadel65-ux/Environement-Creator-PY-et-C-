# 📦 Installation Guide - EnvironmentCreator v4.0.0

## For End Users (No Programming Experience)

### ⚡ 60-Second Installation

**Step 1: Download**
- Go to [Releases](https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-/releases)
- Download `EnvironmentCreator-4.0.0-publish.zip` (~70 MB)

**Step 2: Extract**
- Right-click the ZIP file
- Select "Extract All..."
- Choose a location (e.g., `C:\Program Files` or `C:\Apps`)

**Step 3: Run**
- Open the extracted folder
- Double-click `EnvironmentCreator.exe`
- Done! ✓

### 🎯 Next Steps

See [GETTING_STARTED.md](guides/GETTING_STARTED.md) for:
- Creating your first environment
- Using presets
- Usage examples

---

## For Developers (Building from Source)

### Requirements
- **Visual Studio 2022** or **VS Code** with C# extension
- **.NET 10.0 SDK** ([Download](https://dotnet.microsoft.com/download))
- **Git** ([Download](https://git-scm.com/))

### Clone & Build

**Step 1: Clone Repository**
```bash
git clone https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-.git
cd Environement-Creator-PY-et-C-
```

**Step 2: Restore & Build**
```bash
# Restore dependencies
dotnet restore

# Build in Debug mode
dotnet build -c Debug

# Or build in Release
dotnet build -c Release
```

**Step 3: Run**
```bash
# Development mode
dotnet run

# Or run the executable
.\bin\Debug\net10.0-windows\EnvironmentCreator.exe
```

### Publish Your Own Build

```powershell
# Using the publish script
.\publish.ps1 -Zip -Version "4.0.0"

# Manual publish
dotnet publish -c Release -r win-x64 --self-contained

# Output: bin/Release/net10.0-windows/win-x64/publish/
```

---

## ✅ Verify Installation

### Windows Explorer Method
```
✓ EnvironmentCreator.exe exists
✓ App launches without error
✓ UI displays correctly
✓ No Windows Defender warnings
```

### Command Line Method
```bash
# Navigate to app folder
cd C:\Path\To\EnvironmentCreator

# Check files
dir EnvironmentCreator.exe
dir EnvironmentCreator.dll

# Run application
.\EnvironmentCreator.exe
```

---

## 🆘 Troubleshooting Installation

### "Windows cannot find the file"
**Cause:** App not in PATH or wrong location

**Solution:**
- Navigate to folder with File Explorer
- Double-click `EnvironmentCreator.exe`
- Or create shortcut on Desktop

### "The system cannot find the path specified"
**Cause:** .NET Runtime not properly installed

**Solution:**
- Download standalone version (includes runtime)
- Or install .NET 10.0 Runtime from [Microsoft](https://dotnet.microsoft.com/download)

### "Access Denied"
**Cause:** Permission issue or antivirus blocking

**Solution:**
1. Extract to non-protected folder (e.g., `C:\Apps`)
2. Right-click → "Run as Administrator"
3. Add exception to antivirus
4. Disable Windows Defender temporarily (testing only)

### "Application not starting"
**Cause:** Visual C++ Runtime missing

**Solution:**
- Download: [Visual C++ Redistributables](https://support.microsoft.com/en-us/help/2977003)
- Install: vcredist_x64.exe
- Restart computer
- Try again

### "No such file or directory"
**Cause:** Incomplete extraction

**Solution:**
- Re-download the ZIP
- Use built-in Windows extractor or 7-Zip
- Extract all files (not just exe)
- Try again

---

## 🔍 System Information

### Check Your Windows Version
```powershell
# Open PowerShell as Administrator and run:
Get-ComputerInfo -Property OsVersion

# Need: Windows 7 SP1 or later
```

### Check .NET Installation
```bash
# Check if .NET is installed
dotnet --version

# Expected: 10.0.x or higher
```

### Check Git Installation
```bash
git --version
# Expected: git version 2.30+
```

---

## 🚀 First Run

### What to Expect
1. **Splash screen** appears (~1 second)
2. **Main window** opens
3. **Empty history** (first time only)
4. **Ready to use** ✓

### What NOT to Expect
- ❌ No UAC prompts (unless "Run as Admin")
- ❌ No internet connection required
- ❌ No registration or license key needed
- ❌ No separate installer needed

---

## 💾 Where Files Are Stored

### Application Files
- **Installation**: Any folder (portable app)
- **Settings**: `%AppData%\EnvironmentCreator\`
- **History**: `%AppData%\EnvironmentCreator\history.json`

### Created Environments
- **Location**: Wherever you specify
- **Example**: `C:\Projects\my-project\`

### Registry Changes
- **None!** Portable app, no registry modifications

---

## 🔄 Uninstall

### Complete Removal

```powershell
# 1. Delete application folder
Remove-Item -Recurse "C:\Path\To\EnvironmentCreator"

# 2. Delete settings (optional)
Remove-Item -Recurse "$env:APPDATA\EnvironmentCreator"

# 3. Delete Desktop shortcut (if created)
Remove-Item "$env:USERPROFILE\Desktop\EnvironmentCreator.lnk"
```

**Note:** Created environments are NOT deleted (intentional)

---

## 📝 Post-Installation

### Create Desktop Shortcut

```powershell
$AppPath = "C:\Path\To\EnvironmentCreator\EnvironmentCreator.exe"
$ShortcutPath = "$env:USERPROFILE\Desktop\EnvironmentCreator.lnk"

$WshShell = New-Object -ComObject WScript.Shell
$Shortcut = $WshShell.CreateShortcut($ShortcutPath)
$Shortcut.TargetPath = $AppPath
$Shortcut.Save()
```

### Add to Start Menu

1. Open Settings
2. Search "Add app to Start"
3. Select app folder
4. Drag `EnvironmentCreator.exe` to Start Menu

---

## 🎓 Next Steps

1. **Run the app** → `EnvironmentCreator.exe`
2. **Read guide** → [GETTING_STARTED.md](guides/GETTING_STARTED.md)
3. **Create environment** → Click a preset
4. **Explore features** → Try different options

---

**Happy creating!** 🚀

Need help? Check [FAQ](guides/GETTING_STARTED.md#faq) or [GitHub Issues](https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-/issues)
