# 🚀 Guide de Démarrage

Bienvenue dans **EnvironmentCreator** ! Ce guide vous aidera à prendre en main l'application.

## ⚡ Installation Rapide

### Prérequis
- Windows 7+ ou Windows Server 2008+
- .NET Runtime 10.0 (inclus dans l'archive)
- *(Optionnel)* Git pour initialisation des repos

### Installation
1. Télécharger **EnvironmentCreator-4.0.0-publish.zip**
2. Extraire l'archive
3. Exécuter **EnvironmentCreator.exe**

Voilà ! L'application est prête. ✅

## 🎯 Utilisation

### 1️⃣ Créer un Environnement Python

1. **Sélectionner le type** : Cocher **Python**
2. **Entrer le nom** : Ex. `my-data-science`
3. **Choisir le chemin** : Cliquer sur `...` et sélectionner un dossier
4. **Choisir les bibliothèques** :
   - Développez les sections (Data Science & ML, Web, etc.)
   - Cochez les librarires souhaitées
5. **Créer** : Cliquer sur "Create Environment"

#### Ou utiliser un **Preset** 🎨
Pour gagner du temps, cliquez sur un preset :
- **Data Science** - NumPy, Pandas, Scikit-learn, Matplotlib, Jupyter
- **Web Dev (FastAPI)** - FastAPI, SQLAlchemy, Pydantic, Pytest
- **Web Dev (Django)** - Django, SQLAlchemy, Black, Pytest
- **ML/DL** - TensorFlow, PyTorch, NumPy, Pandas

L'environnement se crée avec :
```
my-data-science/
├── main.py              # Script principal
├── requirements.txt     # Dépendances pip
├── .gitignore          # Fichiers ignorés Git
├── .env.example        # Variables d'env
└── README.md           # Instructions setup
```

### 2️⃣ Créer un Environnement C#

1. **Sélectionner le type** : Cocher **C#**
2. **Entrer le nom** : Ex. `MyConsoleApp`
3. **Choisir le chemin** : Cliquer sur `...`
4. **Choisir les packages** :
   - Data & Serialization : Entity Framework Core, Dapper, Newtonsoft.Json
   - Web & Architecture : ASP.NET Core, Swagger, MediatR
   - Testing & Resilience : xUnit, NUnit, Serilog, Polly
   - API & Infra : Refit, Autofac, NLog, RabbitMQ, MongoDB...
5. **Créer** : Cliquer sur "Create Environment"

L'environnement se crée avec :
```
MyConsoleApp/
├── MyConsoleApp.csproj     # Configuration projet
├── Program.cs              # Point d'entrée
├── appsettings.json        # Configuration app
├── .gitignore              # Fichiers ignorés
└── README.md               # Instructions
```

## 📚 Fonctionnalités

### Historique 📋
L'application sauvegarde tous les environnements créés dans le panneau droit :
- Nom, type, date de création
- Bibliothèques/packages installés
- Actions rapides :
  - 📂 **Open** - Ouvrir le dossier dans l'explorateur
  - 📋 **Copy Path** - Copier le chemin en clipboard
  - 🗑️ **Delete** - Supprimer de l'historique

### Présets Rapides 🎨
6 configurations prédéfinies pour démarrer vite :
1. Data Science
2. Web Dev (FastAPI)
3. Web Dev (Django)
4. ML/DL
5. API (C#)
6. Console (C#)

Cliquez sur un preset pour pré-remplir les dépendances automatiquement !

### Initialisation Git 🔄
Chaque environnement créé initialise automatiquement un repo Git :
```bash
cd my-environment
git log --oneline
# Initial commit: project scaffolding
```

## 💡 Cas d'Usage

### 1. Démarrer un projet Data Science
```
1. Cliquer sur preset "Data Science"
2. Entrer le nom : "credit-scoring"
3. Cliquer "Create"
4. cd credit-scoring
5. python -m venv venv
6. venv\Scripts\activate
7. pip install -r requirements.txt
```

### 2. Créer un API FastAPI
```
1. Cliquer sur preset "Web Dev (FastAPI)"
2. Entrer le nom : "user-api"
3. Ajouter des librarires supplémentaires si besoin
4. Cliquer "Create"
5. Setup environment comme ci-dessus
6. Développer votre API
```

### 3. Créer une app console C#
```
1. Cocher "C#"
2. Sélectionner preset "Console (C#)"
3. Entrer le nom : "my-app"
4. Cliquer "Create"
5. cd my-app
6. dotnet restore
7. dotnet run
```

## 🔧 Configuration Avancée

### Ajouter des Bibliothèques Non Listées

#### Python
Éditez `requirements.txt` après création :
```txt
numpy==1.24.0
pandas==2.0.0
ma-librarire-perso==1.0.0
```

Puis installez :
```bash
pip install -r requirements.txt
```

#### C#
Éditez le `.csproj` ou utilisez :
```bash
dotnet add package NomDuPackage
```

### Personnaliser les Presets
Les presets sont définis dans :
- Fichier source : `src\Core\Models\PresetManager.cs`
- Pour ajouter un preset, modifiez le dictionnaire

## ❓ FAQ

**Q: Où sont stockés les environnements ?**
R: À l'emplacement que vous choisissez avec le bouton `...`

**Q: Puis-je modifier un environnement après création ?**
R: Oui ! Tous les fichiers sont standards (requirements.txt, .csproj)

**Q: L'historique est-il sauvegardé ?**
R: Oui, dans `AppData\EnvironmentCreator\history.json`

**Q: Puis-je utiliser sur macOS/Linux ?**
R: Non, version actuelle Windows uniquement (.NET Windows Forms + WPF)

**Q: Comment réinitialiser l'historique ?**
R: Supprimer `%AppData%\EnvironmentCreator\history.json`

## 🐛 Support

En cas de problème :
1. Vérifier que le chemin sélectionné existe et est accessible
2. S'assurer que Git est installé (pour l'initialisation auto)
3. Vérifier les permissions d'écriture du dossier

---

**Besoin d'aide ?** Consultez [README.md](../../README.md) ou les autres guides.
