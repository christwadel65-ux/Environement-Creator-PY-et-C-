# Changelog

## 1.0.0 - 2025-12-13

- Initial WPF UI for Environment Creator
  - Single-page layout without scroll; stable window sizing
  - Python/C# environment type toggle with category expanders
  - Validation: folder existence, write permission test, clear feedback
- Environment scaffolding
  - Python: requirements.txt, main.py, README.md, .gitignore
  - C#: .csproj with selected packages, Program.cs, README.md, .gitignore
- Build & Release
  - Self-contained win-x64 publish
  - Root `publish/` folder tracked; `bin/` and `obj/` ignored
  - Git LFS for binaries in `publish/`
- Tooling
  - `publish.ps1` script for build/copy and optional git commit/push
- Documentation & License
  - README updated (publish instructions, usage)
  - MIT License with author attribution
