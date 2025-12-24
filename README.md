# Environment Creator v4.0.0

Professional WPF application to create Python and C# development environments with pre-configured libraries and dependencies.

![Version](https://img.shields.io/badge/version-4.0.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Platform](https://img.shields.io/badge/platform-Windows-blue)

## 🎯 Overview

EnvironmentCreator is a desktop application that scaffolds production-ready development environments for:
- **Python** projects (Data Science, Web, ML/DL, API)
- **C#** projects (Console, API, Web)

Includes automatic:
- Virtual environment creation (Python)
- Dependency installation
- Git repository initialization
- Project scaffolding with best practices

## 📋 Requirements

- **Windows** 7+ or Windows Server 2008+
- **.NET Runtime 10.0** (not included in published archive)
- *(Optional)* **Git** for automatic repo initialization
- *(Optional)* **Python 3.x** for Python venv creation

## 🚀 Quick Start

### Download & Run
1. Download `EnvironmentCreator-4.0.0-publish.zip`
2. Extract the archive
3. Run `EnvironmentCreator.exe`

### Create Your First Environment
1. Enter environment name: `my-project`
2. Choose path: Click `...` to select folder
3. Select type: **Python** or **C#**
4. Choose preset: Click a quick-start configuration
5. Click **Create** ✓

## 📦 Features

### Smart Presets
6 pre-configured templates to jumpstart projects:
- **Data Science** - NumPy, Pandas, Scikit-learn, Matplotlib
- **Web Dev (FastAPI)** - FastAPI, SQLAlchemy, Pydantic
- **Web Dev (Django)** - Django, ORM, Testing
- **ML/DL** - TensorFlow, PyTorch, Deep Learning stack
- **API (C#)** - ASP.NET Core, Swagger, EF Core
- **Console (C#)** - Logging, Configuration

### Automatic Setup
- ✅ Python virtual environment creation
- ✅ Package installation (pip)
- ✅ C# project with NuGet packages
- ✅ Git repository initialization
- ✅ Scaffolding with README & examples

### Environment History
- Tracks all created environments
- Quick access to previous projects
- One-click folder opening
- Copy path to clipboard
- Remove from history

## 🔧 Development

### Build
```bash
dotnet build -c Debug
```

### Run (Development)
```bash
dotnet run
```

### Publish (Release)
```powershell
# Using helper script
.\publish.ps1 -Zip -Version "4.0.0"

# Manual publish
dotnet publish -c Release -r win-x64 --self-contained
```

## 📁 Project Structure

```
src/
├── Core/                    # Business logic
│   ├── Models/             # Data structures
│   ├── Services/           # Creation logic (async)
│   └── Utilities/          # Helpers
├── UI/                      # Windows Forms & WPF
│   ├── Windows/            # MainWindow
│   └── Views/              # Custom controls
└── [Bootstrap files]

docs/                        # Complete documentation
├── guides/                 # User & contributor guides
└── architecture/           # Technical design

tests/                       # Unit tests (ready for expansion)
```

### Namespaces
```csharp
EnvironmentCreator.Core.Models
EnvironmentCreator.Core.Services
EnvironmentCreator.Core.Utilities
EnvironmentCreator.UI.Windows
```

## 📚 Documentation

Full documentation in [docs/](docs/) folder:
- **[GETTING_STARTED.md](docs/guides/GETTING_STARTED.md)** - User guide
- **[CONTRIBUTING.md](docs/guides/CONTRIBUTING.md)** - Developer guide
- **[ARCHITECTURE.md](docs/architecture/ARCHITECTURE.md)** - Technical design
- **[FOLDER_STRUCTURE.md](docs/architecture/FOLDER_STRUCTURE.md)** - Project organization

## 🔄 Git Repository

```bash
# Clone the repository
git clone https://github.com/christwadel65-ux/Environement-Creator-PY-et-C-.git

# Create a feature branch
git checkout -b feature/my-feature
```

### What's Tracked
- ✅ Documentation (docs/)
- ✅ Configuration (csproj, sln)
- ✅ Published binaries (publish/)
- ❌ Source code (src/ - excluded)
- ❌ Build artifacts (bin/, obj/)

See [.gitignore](.gitignore) for details.

## 💡 Usage Examples

### Create Python Data Science Environment
```powershell
# 1. Click "Data Science" preset
# 2. Enter name: "credit-analysis"
# 3. Select path
# 4. Click Create

# 5. Setup environment
cd credit-analysis
venv\Scripts\activate
python main.py
```

### Create C# API Project
```powershell
# 1. Select C#
# 2. Click "API (C#)" preset
# 3. Enter name: "my-api"
# 4. Click Create

# 5. Build and run
cd my-api
dotnet restore
dotnet run
```

## 🐛 Troubleshooting

### App won't start
- Ensure you have .NET Runtime 10.0
- Check Windows version (Win7+)
- Try running as Administrator

### Environment creation fails
- Verify folder path exists and is writable
- Ensure Git is installed (for repo init)
- Check Python 3.x is in PATH (for Python envs)

### History is empty
- First-time users see empty history
- Create an environment to populate it

## 📝 Changelog

### v4.0.0 (2025-12-24)
- ✨ Professional architecture reorganization
- 📚 Complete documentation suite added
- 🎯 6 smart presets for quick setup
- 🔧 Improved error handling
- 📝 Contributing guidelines

**Previous versions** → See [CHANGELOG.md](CHANGELOG.md)

## 📄 License

MIT License - See [LICENSE](LICENSE) for details

## 🤝 Contributing

Contributions welcome! See [CONTRIBUTING.md](docs/guides/CONTRIBUTING.md) for:
- Code standards
- Commit conventions
- Pull request process
- Development setup

## 💬 Support

**Questions or Issues?**
1. Check [FAQ](docs/guides/GETTING_STARTED.md#faq)
2. Read [documentation](docs/)
3. Create an issue on GitHub

---

**Version**: 4.0.0  
**License**: MIT  
**Platform**: Windows (win-x64)  
**Runtime**: .NET 10.0+
