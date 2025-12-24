# Architecture refactorisée v3.0.0

## Structure du projet

```
EnvironmentCreator/
├── Models/                      # Modèles de données
│   ├── EnvironmentHistoryItem.cs   # Élément d'historique
│   └── PresetManager.cs            # Gestion des presets
│
├── Services/                    # Couche métier
│   ├── HistoryService.cs           # Gestion de l'historique (JSON)
│   ├── EnvironmentBuilder.cs       # Orchestration création d'env
│   ├── PythonBuilder.cs            # Création env Python
│   ├── CSharpBuilder.cs            # Création env C#
│   └── GitService.cs               # Initialisation Git
│
├── MainWindow.xaml              # UI XAML
├── MainWindow.xaml.cs           # Code-behind (événements, coordination)
│
└── App.xaml / Program.cs        # Bootstrap
```

## Avantages de la nouvelle structure

### 1. **Séparation des responsabilités**
- **Models** : Données pures (EnvironmentHistoryItem, PresetConfig)
- **Services** : Logique métier (création d'env, historique, Git)
- **View** : Présentation (MainWindow.xaml.cs)

### 2. **Testabilité**
- Services injectables
- Logique détachée de l'UI
- Pas de dépendances circulaires

### 3. **Maintenabilité**
- Chaque service a une responsabilité unique
- Facile de modifier/étendre
- Code clairement organisé

### 4. **Réutilisabilité**
- Services peuvent être utilisés dans d'autres contextes
- HistoryService, EnvironmentBuilder indépendants de l'UI
- Possibilité future de CLI ou API

## Classes et responsabilités

### Models
```csharp
// Données historique
EnvironmentHistoryItem {
    Name, Path, Type, Libraries, CreatedAt
}

// Presets prédéfinis
PresetManager {
    Presets: Dictionary<string, PresetConfig>
    GetPreset(name): PresetConfig?
}
```

### Services
```csharp
// Historique JSON
HistoryService {
    LoadHistoryAsync(): List<EnvironmentHistoryItem>
    SaveHistoryAsync(items): Task
    ClearHistory(): void
}

// Orchestration
EnvironmentBuilder {
    CreateEnvironmentAsync(config): Task<bool>
    ValidatePath(path): void
}

// Création Python
PythonBuilder {
    CreateAsync(envPath, libraries): Task
}

// Création C#
CSharpBuilder {
    CreateAsync(envPath, projectName, libraries): Task
}

// Git
GitService {
    InitializeRepositoryAsync(envPath): Task
}
```

### Configuration
```csharp
EnvironmentConfig {
    Name, Path, IsPython, SelectedLibraries
}
```

## Flux d'exécution

```
1. MainWindow.xaml.cs (Événement Create_Click)
   ↓
2. ValidateInput() → EnvironmentConfig
   ↓
3. EnvironmentBuilder.CreateEnvironmentAsync()
   ├─ ValidatePath()
   ├─ PythonBuilder.CreateAsync() OU CSharpBuilder.CreateAsync()
   ├─ GitService.InitializeRepositoryAsync()
   └─ Retour succès/erreur
   ↓
4. AddToHistory() + SaveHistoryAsync()
   └─ HistoryService.SaveHistoryAsync()
```

## Améliorations futures

- [ ] **MVVM** : Ajouter ViewModel pour meilleure séparation UI/logique
- [ ] **Dependency Injection** : Injecter les services via conteneur
- [ ] **Patterns** : Factory pour builders, Observer pour historique
- [ ] **API REST** : Exposer services via API
- [ ] **CLI** : Interface ligne de commande
- [ ] **Tests unitaires** : Tester les services indépendamment
- [ ] **Configuration** : Fichier config pour personnaliser presets

## Notes de compatibilité

- v3.0.0 utilise la même structure XAML qu'avant
- Comportement utilisateur inchangé
- Code plus maintenable et extensible
- Prêt pour patterns avancés (MVVM, DI)
