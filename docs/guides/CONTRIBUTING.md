# 🤝 Guide de Contribution

Merci de votre intérêt pour contribuer à **EnvironmentCreator** ! Ce guide explique comment participer au projet.

## 📋 Table des matières

1. [Code de Conduite](#code-de-conduite)
2. [Comment Contribuer](#comment-contribuer)
3. [Processus de Développement](#processus-de-développement)
4. [Normes de Code](#normes-de-code)
5. [Soumission de Pull Request](#soumission-de-pull-request)

## 🎯 Code de Conduite

- Respectez tous les contributeurs
- Pas de discrimination basée sur l'origine, l'identité, etc.
- Soyez constructif dans vos critiques
- Acceptez les critiques avec bienveillance

## 💡 Comment Contribuer

### Types de Contributions

#### 1. 🐛 Signaler des Bugs
Créez une issue GitHub avec :
- **Titre** : Description brève du bug
- **Description** : Étapes de reproduction
- **Résultat attendu** vs **Résultat obtenu**
- **Version** : Numéro de version concernée
- **Environnement** : OS, .NET version, etc.

Exemple :
```markdown
**Titre** : Crash lors de la création d'env Python avec chemins Unicode

**Étapes** :
1. Sélectionner Python
2. Créer env dans chemin avec caractères spéciaux (C:\français\app)
3. Cliquer Create

**Résultat** : Application crash avec exception

**Attendu** : Environnement créé correctement
```

#### 2. ✨ Proposer des Fonctionnalités
Créez une issue GitHub avec :
- **Titre** : Courte description
- **Cas d'usage** : Pourquoi avoir cette fonctionnalité
- **Exemple** : Comment ça pourrait fonctionner
- **Alternatives** : Autres solutions envisagées

Exemple :
```markdown
**Titre** : Support des modèles personnalisés

**Cas d'usage** : Pouvoir créer ses propres presets

**Exemple** : Bouton "Create Preset" dans l'UI

**Alternatives** : Fichier de config externe
```

#### 3. 🔧 Améliorer le Code
- Refactoring
- Optimisations performance
- Meilleure couverture de tests
- Documentation

#### 4. 📚 Améliorer la Documentation
- Typos
- Clarifications
- Nouveaux guides
- Examples

## 🔄 Processus de Développement

### Configuration Locale

```bash
# 1. Fork le repo sur GitHub
# 2. Clone localement
git clone https://github.com/VOTRE_UTILISATEUR/EnvironmentCreator.git
cd EnvironmentCreator

# 3. Créer une branche
git checkout -b feature/ma-feature
# ou
git checkout -b fix/mon-bug

# 4. Ouvrir avec Visual Studio ou VS Code
start EnvironmentCreator.sln

# 5. Compiler et tester
dotnet build -c Debug
dotnet run
```

### Arborescence du Code

```
src/
├── Core/              ← Services métier (logique pure)
│   ├── Models/       ← Structures de données
│   ├── Services/     ← Logique async
│   └── Utilities/    ← Helpers
├── UI/               ← Interface WPF
│   ├── Windows/      ← Fenêtres principales
│   └── Views/        ← Contrôles réutilisables
└── [App bootstrap files]

tests/                ← Tests unitaires
docs/                 ← Documentation
```

### Branches

- `main` - Production (version stable)
- `develop` - Développement (version suivante)
- `feature/*` - Nouvelles fonctionnalités
- `fix/*` - Corrections de bugs
- `docs/*` - Documentation

### Commits

Utiliser le format conventionnel :
```
<type>: <description courte>

<description longue optionnelle>

<footer optionnel>
```

Types acceptés :
- `feat` - Nouvelle fonctionnalité
- `fix` - Correction de bug
- `refactor` - Restructuration de code
- `docs` - Documentation
- `style` - Formatage, styles
- `test` - Tests
- `chore` - Maintenance

Exemples :
```
feat: ajouter support des presets personnalisés
fix: corriger crash avec chemins Unicode
docs: améliorer le guide de démarrage
refactor: extraire validation en classe utilitaire
```

## 📏 Normes de Code

### Langage C#

#### Nommage
```csharp
// Classes : PascalCase
public class EnvironmentBuilder { }

// Méthodes : PascalCase
public async Task CreateEnvironmentAsync() { }

// Variables locales : camelCase
var historyService = new HistoryService();

// Constantes : UPPER_SNAKE_CASE
private const string DEFAULT_PATH = "C:\\Envs";

// Interfaces : IPrefixe
public interface IEnvironmentBuilder { }
```

#### Format
```csharp
// Braces style (Allman)
if (condition)
{
    DoSomething();
}
else
{
    DoSomethingElse();
}

// Indentation : 4 espaces
// Longueur max ligne : 120 caractères
// Null-coalescing : utiliser ?? et ?.
```

#### Documentation
```csharp
/// <summary>
/// Crée un nouvel environnement avec la config spécifiée
/// </summary>
/// <param name="config">Configuration de l'environnement</param>
/// <returns>True si succès, False sinon</returns>
public async Task<bool> CreateEnvironmentAsync(EnvironmentConfig config)
{
    // Implementation
}
```

### Architecture

#### Dépendances
```
Models (aucune dépendance)
   ↑
Utilities (→ Models)
   ↑
Services (→ Models + Utilities)
   ↑
UI (→ Services + Models)
```

#### Services
```csharp
// Services doivent être :
// 1. Async-first (Task, Task<T>)
// 2. Indépendants de l'UI
// 3. Testables (pas new keyword)
// 4. Avec responsabilité unique

public class HistoryService
{
    public async Task<List<EnvironmentHistoryItem>> LoadAsync()
    {
        // Async I/O operation
    }

    public async Task SaveAsync(List<EnvironmentHistoryItem> items)
    {
        // Async I/O operation
    }
}
```

## ✅ Checklist Avant Soumission

- [ ] Code compilé sans erreurs
- [ ] Tests passent (si existants)
- [ ] Pas de warnings à la compilation
- [ ] Code formaté selon les normes
- [ ] Commits avec messages clairs
- [ ] Branche à jour avec `develop`
- [ ] Documentation mis à jour (si changement)
- [ ] Tests ajoutés pour nouvelles fonctionnalités

## 📤 Soumission de Pull Request

### Template PR

```markdown
## Description
Brève description des changements

## Type de changement
- [ ] Correction de bug
- [ ] Nouvelle fonctionnalité
- [ ] Refactoring
- [ ] Documentation

## Changements
- Changement 1
- Changement 2

## Tests
Comment tester les changements ?

## Checklist
- [ ] Code compilé
- [ ] Tests passent
- [ ] Documentation à jour
- [ ] Pas de breaking changes
```

### Révision

Attendez-vous à :
- Feedback constructif
- Demandes de changements
- Questions sur l'approche

Soyez ouvert et respectueux ! 💪

## 🎓 Ressources

- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Microsoft REST API Guidelines](https://github.com/microsoft/api-guidelines)
- [Architecture Docs](../architecture/) - Documentation technique

## 🚀 Prochaines Priorités

### Court terme
- [ ] Ajouter tests unitaires
- [ ] Interface utilisateur améliorée
- [ ] Support de plus de languages

### Moyen terme
- [ ] API REST
- [ ] CLI (Command Line Interface)
- [ ] Configuration externalisée

### Long terme
- [ ] Support macOS/Linux
- [ ] MVVM avec ViewModels
- [ ] Plugins extensibles

---

**Questions ?** Créez une Discussion ou Issue sur GitHub.

**Merci de contribuer !** 🙏
