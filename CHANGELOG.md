# Changelog

Toutes les modifications notables de ce projet sont documentées dans ce fichier.

Le format est basé sur [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
et ce projet adhère au [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2025-12-14

### Ajouts
- **Création automatique de l'environnement virtuel Python** (`python -m venv venv`)
- **Installation automatique des packages** pour les bibliothèques Python sélectionnées
- Gestion des processus pour l'exécution de la création venv et pip install
- Ajout de Python 3.x dans les prérequis de la documentation
- Option `-Zip` dans le script de publication pour créer des archives de release

### Modifications
- README mis à jour avec les nouvelles fonctionnalités Python
- Workflow de scaffolding Python amélioré avec automatisation complète
- Artifacts de publication réduits (uniquement localisation française)

### Corrections
- L'environnement Python crée maintenant automatiquement un environnement virtuel fonctionnel
- L'installation des packages ne nécessite plus d'intervention manuelle

## [1.0.0] - 2025-12-13

### Ajouts initiaux
- Interface WPF pour Environment Creator
  - Layout single-page sans scroll avec dimensionnement stable
  - Basculement Python/C# avec expanders de catégories
  - Validation: existence du dossier, test de permission d'écriture, feedback clair
- Scaffolding d'environnement
  - **Python**: requirements.txt, main.py, README.md, .gitignore
  - **C#**: .csproj avec packages sélectionnés, Program.cs, README.md, .gitignore
- Build & Release
  - Publication self-contained win-x64
  - Dossier `publish/` suivi; `bin/` et `obj/` ignorés
  - Git LFS pour les binaires dans `publish/`
- Outils
  - Script `publish.ps1` pour build/copy et commit/push git optionnel
- Documentation & License
  - README avec instructions de publication et d'utilisation
  - Licence MIT avec attribution d'auteur

### Bibliothèques Python supportées
- NumPy, Pandas, Scikit-learn, TensorFlow
- Flask, Django, FastAPI
- Beautiful Soup, Requests, Scrapy
- Matplotlib, Pillow
- Pytest, Black
- SQLAlchemy, Alembic
- Redis, Celery
- PyTorch, Jupyter
- Pydantic, Click
- python-dotenv

### Bibliothèques C# supportées
- Entity Framework Core, Dapper
- ASP.NET Core, Swagger/OpenAPI
- MediatR, Polly, Refit, Autofac
- xUnit, NUnit, FluentAssertions
- Serilog, NLog
- RabbitMQ, MongoDB
- GraphQL .NET, IdentityModel
- Hangfire
- Newtonsoft.Json
