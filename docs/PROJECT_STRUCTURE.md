# EnvironmentCreator - Architecture Professionnelle

## 📁 Structure du Projet

```
EnvironmentCreator/
├── src/                              # Code source
│   ├── Core/                         # Logique métier
│   │   ├── Models/                   # Modèles de données
│   │   │   ├── EnvironmentHistoryItem.cs
│   │   │   └── PresetManager.cs
│   │   ├── Services/                 # Services métier (async)
│   │   │   ├── HistoryService.cs
│   │   │   ├── EnvironmentBuilder.cs
│   │   │   ├── PythonBuilder.cs
│   │   │   ├── CSharpBuilder.cs
│   │   │   └── GitService.cs
│   │   └── Utilities/                # Utilitaires
│   │       ├── ValidationHelper.cs
│   │       └── ConfigurationHelper.cs
│   ├── UI/                           # Présentation
│   │   ├── Windows/                  # Fenêtres principales
│   │   │   └── MainWindow.xaml(.cs)
│   │   └── Views/                    # Contrôles/Vues réutilisables
│   ├── App.xaml(.cs)                 # Bootstrap application
│   └── Program.cs                    # Entry point
├── tests/                            # Tests unitaires
│   ├── Services/
│   └── Models/
├── docs/                             # Documentation
│   ├── architecture/
│   │   └── ARCHITECTURE.md
│   └── guides/
│       ├── GETTING_STARTED.md
│       └── CONTRIBUTING.md
├── build/                            # Artefacts (généré)
│   ├── Debug/
│   └── Release/
├── publish/                          # Archives publiées
├── EnvironmentCreator.csproj         # Projet C#
├── EnvironmentCreator.sln            # Solution Visual Studio
├── README.md                         # Guide d'utilisation
└── LICENSE                           # Licence MIT
```

## 🎯 Principes d'organisation

### Séparation des préoccupations
- **src/Core/** : Logique pure, indépendante de l'UI
- **src/UI/** : Interface utilisateur XAML/WPF
- **tests/** : Tests unitaires et d'intégration
- **docs/** : Documentation développeur

### Hiérarchie des dépendances
```
Models (pas de dépendance)
    ↑
Utilities (dépend de Models)
    ↑
Services (dépend de Models + Utilities)
    ↑
UI (dépend de Services + Models)
```

### Conventions de nommage
- **Dossiers** : PascalCase (Models, Services, UI)
- **Fichiers** : PascalCase.cs (HistoryService.cs)
- **Namespaces** : EnvironmentCreator.Core.Services
- **Classes** : PascalCase (HistoryService)
- **Interfaces** : IPrefixe (IEnvironmentBuilder)

## 📦 Contenu par dossier

### src/Core/Models/
Modèles de données purs (pas de logique métier)
```csharp
EnvironmentHistoryItem     // Élément d'historique
EnvironmentConfig          // Configuration d'environnement
PresetConfig               // Configuration preset
```

### src/Core/Services/
Services avec logique métier (async)
```csharp
HistoryService             // Gestion persistance historique
EnvironmentBuilder         // Orchestration création
PythonBuilder              // Construction env Python
CSharpBuilder              // Construction env C#
GitService                 // Opérations Git
```

### src/Core/Utilities/
Fonctions utilitaires et helpers
```csharp
ValidationHelper           // Validation chemins/entrées
ConfigurationHelper        // Gestion configuration
PathHelper                 // Utilitaires chemins
```

### src/UI/Windows/
Fenêtres WPF principales
```
MainWindow.xaml            // Interface principale
MainWindow.xaml.cs         // Code-behind
```

### src/UI/Views/
Contrôles et vues réutilisables
```
(Futurs contrôles personnalisés)
```

## 🔄 Flux d'utilisation

```
1. Program.cs → App.xaml.cs
2. App.xaml.cs → MainWindow
3. MainWindow (UI Events)
   ↓
4. HistoryService.LoadHistoryAsync()
5. Présets via PresetManager
6. Create → EnvironmentBuilder
   ├─ PythonBuilder ou CSharpBuilder
   └─ GitService.InitializeAsync()
7. Historique → HistoryService.SaveHistoryAsync()
```

## 🚀 Prochaines étapes

- [ ] Ajouter interface IEnvironmentBuilder pour DI
- [ ] Implémenter ViewModel pour MVVM
- [ ] Ajouter tests unitaires
- [ ] Créer application console alternative
- [ ] Exposer API REST
- [ ] Ajouter logging (Serilog)
- [ ] Ajouter configuration externalisée

## 📝 Fichiers de documentation

- **ARCHITECTURE.md** : Détails techniques
- **GETTING_STARTED.md** : Guide démarrage
- **CONTRIBUTING.md** : Guidelines contribution
