namespace EnvironmentCreator;

public partial class Form1 : Form
{
    private List<string> environments = new();

    public Form1()
    {
        InitializeComponent();
        UpdateLibraryVisibility(); // Initialiser la visibilité au démarrage
    }

    private void ButtonBrowse_Click(object? sender, EventArgs e)
    {
        using (var folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Select a folder for the environment";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var textBoxPath = Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "textBoxPath");
                if (textBoxPath != null)
                {
                    textBoxPath.Text = folderDialog.SelectedPath;
                }
            }
        }
    }

    private void RadioPython_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateLibraryVisibility();
    }

    private void RadioCSharp_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateLibraryVisibility();
    }

    private void UpdateLibraryVisibility()
    {
        var radioPython = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Name == "radioPython");
        if (radioPython == null) return;

        bool isPython = radioPython.Checked;

        // Update all GroupBoxes on the panel
        foreach (var control in Controls.OfType<Panel>())
        {
            foreach (var groupBox in control.Controls.OfType<GroupBox>())
            {
                if (groupBox.Tag == null) continue;

                string tag = groupBox.Tag?.ToString() ?? "";
                groupBox.Visible = (isPython && tag == "python") || (!isPython && tag == "csharp");
            }
        }
    }

    private void ButtonCreate_Click(object? sender, EventArgs e)
    {
        var textBoxName = Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "textBoxName");
        var textBoxPath = Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "textBoxPath");
        var radioPython = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Name == "radioPython");
        var listBox = Controls.OfType<ListBox>().FirstOrDefault(x => x.Name == "listBoxEnvironments");

        if (textBoxName == null || textBoxPath == null || radioPython == null || listBox == null)
        {
            MessageBox.Show("Error: Some form elements are missing.", "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string name = textBoxName.Text.Trim();
        string path = textBoxPath.Text.Trim();
        bool isPython = radioPython.Checked;

        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Please enter an environment name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBoxName.Focus();
            return;
        }

        if (string.IsNullOrEmpty(path))
        {
            MessageBox.Show("Please select a path.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBoxPath.Focus();
            return;
        }

        // Validate and prepare folder path
        try
        {
            // Normalize path
            path = Path.GetFullPath(path);
            
            // Check if path exists
            if (!Directory.Exists(path))
            {
                MessageBox.Show(
                    $"The folder does not exist:\n\n{path}\n\nPlease select an existing folder.",
                    "Folder Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Check if path is writable
            string testFile = Path.Combine(path, ".write_test_" + Guid.NewGuid().ToString());
            try
            {
                File.WriteAllText(testFile, "test");
                File.Delete(testFile);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Access denied! You don't have permission to write in this folder.",
                    "Permission Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Invalid folder path:\n\n{ex.Message}",
                "Path Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        try
        {
            string envPath = Path.Combine(path, name);
            
            // Check if environment already exists
            if (Directory.Exists(envPath))
            {
                MessageBox.Show(
                    $"An environment named '{name}' already exists in this folder.",
                    "Environment Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create environment directory
            Directory.CreateDirectory(envPath);

            // Get selected libraries
            var selectedLibraries = GetSelectedLibraries(isPython);

            // Create environment-specific files
            if (isPython)
            {
                CreatePythonEnvironment(envPath, selectedLibraries);
            }
            else
            {
                CreateCSharpEnvironment(envPath, name, selectedLibraries);
            }

            string typeLabel = isPython ? "Python" : "C#";
            string libList = selectedLibraries.Count > 0 ? $" [{string.Join(", ", selectedLibraries)}]" : "";
            string envEntry = $"{name} ({typeLabel}){libList}";
            
            if (!environments.Contains(envEntry))
            {
                environments.Add(envEntry);
                listBox.Items.Add(envEntry);
                MessageBox.Show(
                    $"Environment created successfully!\n\nLocation: {envPath}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ClearInputs();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating environment:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private List<string> GetSelectedLibraries(bool isPython)
    {
        var selected = new List<string>();
        string targetTag = isPython ? "python" : "csharp";

        // Find all CheckBoxes recursively in the panel
        var panelLeft = Controls.OfType<Panel>().FirstOrDefault(x => x.Name == "panelLeft");
        if (panelLeft == null)
            return selected;

        foreach (var groupBox in panelLeft.Controls.OfType<GroupBox>())
        {
            if (groupBox.Tag != null && groupBox.Tag.ToString() == targetTag)
            {
                foreach (var checkBox in groupBox.Controls.OfType<CheckBox>())
                {
                    if (checkBox.Checked)
                    {
                        selected.Add(checkBox.Text);
                    }
                }
            }
        }

        return selected;
    }

    private void CreatePythonEnvironment(string envPath, List<string> libraries)
    {
        // Create a requirements.txt file
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
            if (libraryMap.ContainsKey(lib))
            {
                requirementsContent.Add(libraryMap[lib]);
            }
        }
        File.WriteAllText(requirementsPath, string.Join("\n", requirementsContent) + "\n");

        // Create a .gitignore file
        string gitIgnorePath = Path.Combine(envPath, ".gitignore");
        File.WriteAllText(gitIgnorePath, "venv/\n__pycache__/\n*.pyc\n.env\n.vscode/\n.idea/\n*.egg-info/\n");

        // Create a main.py file
        string mainPath = Path.Combine(envPath, "main.py");
        File.WriteAllText(mainPath, "#!/usr/bin/env python3\n\nif __name__ == \"__main__\":\n    print(\"Hello from Python environment!\")\n");

        // Create a README.md
        string readmePath = Path.Combine(envPath, "README.md");
        File.WriteAllText(readmePath, $"# {Path.GetFileName(envPath)}\n\nPython Environment\n\n## Setup\n\n```bash\npython -m venv venv\nvenv\\Scripts\\activate  # On Windows\nsource venv/bin/activate  # On macOS/Linux\npip install -r requirements.txt\n```\n");
    }

    private void CreateCSharpEnvironment(string envPath, string name, List<string> libraries)
    {
        // Create a .csproj file with dependencies
        string csprojPath = Path.Combine(envPath, $"{name}.csproj");
        
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
            if (libraryVersions.ContainsKey(lib))
            {
                var (packageName, version) = libraryVersions[lib];
                packageLines.Add($"    <PackageReference Include=\"{packageName}\" Version=\"{version}\" />");
            }
        }

        string packagesSection = packageLines.Count > 0 
            ? "\n  <ItemGroup>\n" + string.Join("\n", packageLines) + "\n  </ItemGroup>"
            : "";

        string csprojContent = $@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
{packagesSection}

</Project>";
        File.WriteAllText(csprojPath, csprojContent);

        // Create a Program.cs file
        string programPath = Path.Combine(envPath, "Program.cs");
        File.WriteAllText(programPath, @"namespace EnvironmentApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(""Hello from C# environment!"");
    }
}");

        // Create a .gitignore file
        string gitIgnorePath = Path.Combine(envPath, ".gitignore");
        File.WriteAllText(gitIgnorePath, "bin/\nobj/\n.vs/\n*.csproj.user\n.vscode/\n.idea/\npackages/\n");

        // Create a README.md
        string readmePath = Path.Combine(envPath, "README.md");
        File.WriteAllText(readmePath, $"# {name}\n\nC# Console Application\n\n## Build & Run\n\n```bash\ndotnet restore\ndotnet build\ndotnet run\n```\n");
    }

    private void ButtonClear_Click(object? sender, EventArgs e)
    {
        ClearInputs();
        foreach (var checkBox in Controls.OfType<CheckBox>())
        {
            checkBox.Checked = false;
        }
    }

    private void ClearInputs()
    {
        var textBoxName = Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "textBoxName");
        var textBoxPath = Controls.OfType<TextBox>().FirstOrDefault(x => x.Name == "textBoxPath");

        if (textBoxName != null) textBoxName.Text = "";
        if (textBoxPath != null) textBoxPath.Text = "";
    }
}
