using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;

namespace EnvironmentCreator;

public partial class MainWindow : Window
{
    private readonly List<string> _environments = new();

    public MainWindow()
    {
        InitializeComponent();
        Loaded += (_, _) => UpdateLibraryVisibility();
        UpdateLibraryVisibility();
    }

    private void EnvironmentType_Checked(object sender, RoutedEventArgs e)
    {
        UpdateLibraryVisibility();
    }

    private void UpdateLibraryVisibility()
    {
        if (PythonRadio == null || PythonPanel == null || CSharpPanel == null)
            return;

        bool isPython = PythonRadio.IsChecked == true;
        PythonPanel.Visibility = isPython ? Visibility.Visible : Visibility.Collapsed;
        CSharpPanel.Visibility = isPython ? Visibility.Collapsed : Visibility.Visible;
    }

    private void Browse_Click(object sender, RoutedEventArgs e)
    {
        using var dialog = new WinForms.FolderBrowserDialog
        {
            Description = "Select a folder for the environment"
        };
        if (dialog.ShowDialog() == WinForms.DialogResult.OK)
        {
            PathBox.Text = dialog.SelectedPath;
        }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        NameBox.Text = string.Empty;
        PathBox.Text = string.Empty;
        foreach (var cb in GetAllCheckBoxes(LibraryStack))
        {
            cb.IsChecked = false;
        }
    }

    private void Create_Click(object sender, RoutedEventArgs e)
    {
        string name = NameBox.Text.Trim();
        string path = PathBox.Text.Trim();
        bool isPython = PythonRadio.IsChecked == true;

        if (string.IsNullOrWhiteSpace(name))
        {
            System.Windows.MessageBox.Show("Please enter an environment name.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            NameBox.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(path))
        {
            System.Windows.MessageBox.Show("Please select a path.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
            PathBox.Focus();
            return;
        }

        // Validate folder path
        try
        {
            path = Path.GetFullPath(path);
            if (!Directory.Exists(path))
            {
                System.Windows.MessageBox.Show($"Folder does not exist:\n{path}", "Path Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check write permission
            string testFile = Path.Combine(path, ".write_test_" + Guid.NewGuid());
            File.WriteAllText(testFile, "test");
            File.Delete(testFile);
        }
        catch (UnauthorizedAccessException)
        {
            System.Windows.MessageBox.Show("Access denied to this folder.", "Permission Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Invalid folder path:\n{ex.Message}", "Path Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            string envPath = Path.Combine(path, name);
            if (Directory.Exists(envPath))
            {
                System.Windows.MessageBox.Show($"Environment already exists:\n{envPath}", "Duplicate", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Directory.CreateDirectory(envPath);
            var selectedLibraries = GetSelectedLibraries(isPython);

            if (isPython)
                CreatePythonEnvironment(envPath, selectedLibraries);
            else
                CreateCSharpEnvironment(envPath, name, selectedLibraries);

            string typeLabel = isPython ? "Python" : "C#";
            string libList = selectedLibraries.Count > 0 ? $" [{string.Join(", ", selectedLibraries)}]" : "";
            string envEntry = $"{name} ({typeLabel}){libList}";

            if (!_environments.Contains(envEntry))
            {
                _environments.Add(envEntry);
                System.Windows.MessageBox.Show($"Environment created!\nLocation: {envPath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Clear_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Error creating environment:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private List<System.Windows.Controls.CheckBox> GetAllCheckBoxes(DependencyObject root)
    {
        var result = new List<System.Windows.Controls.CheckBox>();
        int count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(root);
        for (int i = 0; i < count; i++)
        {
            var child = System.Windows.Media.VisualTreeHelper.GetChild(root, i);
            if (child is System.Windows.Controls.CheckBox cb)
            {
                result.Add(cb);
            }
            else
            {
                result.AddRange(GetAllCheckBoxes(child));
            }
        }
        return result;
    }

    private List<string> GetSelectedLibraries(bool isPython)
    {
        string tag = isPython ? "python" : "csharp";
        return GetAllCheckBoxes(LibraryStack)
            .Where(cb => (cb.Tag as string) == tag && cb.IsChecked == true)
            .Select(cb => cb.Content?.ToString() ?? string.Empty)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToList();
    }

    private void CreatePythonEnvironment(string envPath, List<string> libraries)
    {
        string requirementsPath = Path.Combine(envPath, "requirements.txt");
        var libraryMap = new Dictionary<string, string>
        {
            { "NumPy", "numpy" },
            { "Pandas", "pandas" },
            { "Scikit-learn", "scikit-learn" },
            { "TensorFlow", "tensorflow" },
            { "Flask", "flask" },
            { "Django", "django" },
            { "FastAPI", "fastapi" },
            { "Beautiful Soup", "beautifulsoup4" },
            { "Requests", "requests" },
            { "Matplotlib", "matplotlib" },
            { "Pytest", "pytest" },
            { "python-dotenv", "python-dotenv" },
            { "SQLAlchemy", "sqlalchemy" },
            { "Redis", "redis" },
            { "Celery", "celery" },
            { "Scrapy", "scrapy" },
            { "Pillow", "pillow" },
            { "PyTorch", "torch" },
            { "Jupyter", "jupyter" },
            { "Black", "black" },
            { "Pydantic", "pydantic" },
            { "Click", "click" },
            { "Alembic", "alembic" }
        };

        var requirementsContent = new List<string> { "# Python environment requirements" };
        foreach (var lib in libraries)
        {
            if (libraryMap.TryGetValue(lib, out var pkg))
            {
                requirementsContent.Add(pkg);
            }
        }
        File.WriteAllLines(requirementsPath, requirementsContent);

        File.WriteAllText(Path.Combine(envPath, ".gitignore"), "venv/\n__pycache__/\n*.pyc\n.env\n.vscode/\n.idea/\n*.egg-info/\n");
        File.WriteAllText(Path.Combine(envPath, "main.py"), "#!/usr/bin/env python3\n\nif __name__ == \"__main__\":\n    print(\"Hello from Python environment!\")\n");
        File.WriteAllText(Path.Combine(envPath, "README.md"), $"# {Path.GetFileName(envPath)}\n\nPython Environment\n\n## Setup\n\n```bash\npython -m venv venv\nvenv\\Scripts\\activate  # Windows\nsource venv/bin/activate  # macOS/Linux\npip install -r requirements.txt\n```\n");
    }

    private void CreateCSharpEnvironment(string envPath, string name, List<string> libraries)
    {
        var libraryVersions = new Dictionary<string, (string PackageName, string Version)>
        {
            { "Entity Framework Core", ("Microsoft.EntityFrameworkCore", "8.0.0") },
            { "Dapper", ("Dapper", "2.0.123") },
            { "Newtonsoft.Json", ("Newtonsoft.Json", "13.0.3") },
            { "ASP.NET Core", ("Microsoft.AspNetCore.App", "8.0.0") },
            { "Swagger/OpenAPI", ("Swashbuckle.AspNetCore", "6.4.0") },
            { "MediatR", ("MediatR", "12.0.1") },
            { "xUnit", ("xunit", "2.6.1") },
            { "NUnit", ("NUnit", "3.13.3") },
            { "Serilog", ("Serilog", "3.0.1") },
            { "Polly", ("Polly", "8.0.0") },
            { "Refit", ("Refit", "7.1.0") },
            { "Autofac", ("Autofac", "7.1.0") },
            { "NLog", ("NLog", "5.2.0") },
            { "RabbitMQ", ("RabbitMQ.Client", "6.8.1") },
            { "MongoDB", ("MongoDB.Driver", "2.21.0") },
            { "GraphQL .NET", ("GraphQL", "7.7.1") },
            { "IdentityModel", ("IdentityModel", "7.0.0") },
            { "Hangfire", ("Hangfire", "1.8.11") },
            { "FluentAssertions", ("FluentAssertions", "6.12.0") },
            { "EF Core Tools", ("Microsoft.EntityFrameworkCore.Tools", "8.0.0") }
        };

        var packageLines = new List<string>();
        foreach (var lib in libraries)
        {
            if (libraryVersions.TryGetValue(lib, out var info))
            {
                packageLines.Add($"    <PackageReference Include=\"{info.PackageName}\" Version=\"{info.Version}\" />");
            }
        }

        string packagesSection = packageLines.Count > 0
            ? "\n  <ItemGroup>\n" + string.Join("\n", packageLines) + "\n  </ItemGroup>"
            : string.Empty;

        string csproj = $"<Project Sdk=\"Microsoft.NET.Sdk\">\n\n  <PropertyGroup>\n    <OutputType>Exe</OutputType>\n    <TargetFramework>net10.0</TargetFramework>\n    <Nullable>enable</Nullable>\n    <ImplicitUsings>enable</ImplicitUsings>\n  </PropertyGroup>{packagesSection}\n\n</Project>";
        File.WriteAllText(Path.Combine(envPath, $"{name}.csproj"), csproj);

        File.WriteAllText(Path.Combine(envPath, "Program.cs"), "namespace EnvironmentApp;\n\nclass Program\n{\n    static void Main(string[] args)\n    {\n        Console.WriteLine(\"Hello from C# environment!\");\n    }\n}\n");

        File.WriteAllText(Path.Combine(envPath, ".gitignore"), "bin/\nobj/\n.vs/\n*.csproj.user\n.vscode/\n.idea/\npackages/\n");
        File.WriteAllText(Path.Combine(envPath, "README.md"), $"# {name}\n\nC# Console Application\n\n## Build & Run\n\n```bash\ndotnet restore\ndotnet build\ndotnet run\n```\n");
    }
}
