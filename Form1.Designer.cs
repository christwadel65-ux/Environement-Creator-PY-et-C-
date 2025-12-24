namespace EnvironmentCreator;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        
        var labelTitle = new Label();
        var labelName = new Label();
        var textBoxName = new TextBox();
        var labelPath = new Label();
        var textBoxPath = new TextBox();
        var buttonBrowse = new Button();
        var labelType = new Label();
        var radioPython = new RadioButton();
        var radioCSharp = new RadioButton();
        
        var panelLeft = new Panel();
        
        var groupBoxPythonData = new GroupBox();
        var checkBoxNumpy = new CheckBox();
        var checkBoxPandas = new CheckBox();
        var checkBoxScikitLearn = new CheckBox();
        var checkBoxTensorFlow = new CheckBox();
        
        var groupBoxPythonWeb = new GroupBox();
        var checkBoxFlask = new CheckBox();
        var checkBoxDjango = new CheckBox();
        var checkBoxFastAPI = new CheckBox();
        var checkBoxBeautifulSoup = new CheckBox();
        
        var groupBoxPythonUtil = new GroupBox();
        var checkBoxRequests = new CheckBox();
        var checkBoxMatplotlib = new CheckBox();
        var checkBoxPytest = new CheckBox();
        var checkBoxPython_dotenv = new CheckBox();

        var groupBoxPythonInfra = new GroupBox();
        var checkBoxSQLAlchemy = new CheckBox();
        var checkBoxRedis = new CheckBox();
        var checkBoxCelery = new CheckBox();
        var checkBoxScrapy = new CheckBox();
        var checkBoxPillow = new CheckBox();
        var checkBoxPyTorch = new CheckBox();

        var groupBoxPythonTooling = new GroupBox();
        var checkBoxJupyter = new CheckBox();
        var checkBoxBlack = new CheckBox();
        var checkBoxPydantic = new CheckBox();
        var checkBoxClick = new CheckBox();
        var checkBoxAlembic = new CheckBox();
        
        var groupBoxCSharpData = new GroupBox();
        var checkBoxEFCore = new CheckBox();
        var checkBoxDapper = new CheckBox();
        var checkBoxNewtonsoft = new CheckBox();
        
        var groupBoxCSharpWeb = new GroupBox();
        var checkBoxAspNetCore = new CheckBox();
        var checkBoxSwagger = new CheckBox();
        var checkBoxMediatR = new CheckBox();
        
        var groupBoxCSharpTest = new GroupBox();
        var checkBoxXUnit = new CheckBox();
        var checkBoxNUnit = new CheckBox();
        var checkBoxSerilog = new CheckBox();
        var checkBoxPolly = new CheckBox();

        var groupBoxCSharpInfra = new GroupBox();
        var checkBoxRefit = new CheckBox();
        var checkBoxAutofac = new CheckBox();
        var checkBoxNLog = new CheckBox();
        var checkBoxRabbitMQ = new CheckBox();
        var checkBoxMongoDB = new CheckBox();
        var checkBoxGraphQL = new CheckBox();
        var checkBoxIdentityModel = new CheckBox();
        var checkBoxHangfire = new CheckBox();
        var checkBoxFluentAssertions = new CheckBox();
        var checkBoxEFCoreTools = new CheckBox();
        
        var buttonCreate = new Button();
        var buttonClear = new Button();
        var listBoxEnvironments = new ListBox();
        var labelEnvironments = new Label();

        // labelTitle
        labelTitle.AutoSize = true;
        labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        labelTitle.Location = new Point(20, 20);
        labelTitle.Text = "Environment Creator";

        // labelName
        labelName.AutoSize = true;
        labelName.Location = new Point(20, 70);
        labelName.Text = "Name:";

        // textBoxName
        textBoxName.Location = new Point(100, 67);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new Size(280, 27);

        // labelPath
        labelPath.AutoSize = true;
        labelPath.Location = new Point(20, 110);
        labelPath.Text = "Path:";

        // textBoxPath
        textBoxPath.Location = new Point(100, 107);
        textBoxPath.Name = "textBoxPath";
        textBoxPath.Size = new Size(250, 27);

        // buttonBrowse
        buttonBrowse.Location = new Point(355, 107);
        buttonBrowse.Size = new Size(25, 27);
        buttonBrowse.Text = "...";
        buttonBrowse.Click += ButtonBrowse_Click;

        // labelType
        labelType.AutoSize = true;
        labelType.Location = new Point(20, 145);
        labelType.Text = "Environment Type:";

        // radioPython
        radioPython.AutoSize = true;
        radioPython.Location = new Point(150, 145);
        radioPython.Name = "radioPython";
        radioPython.Text = "Python";
        radioPython.Checked = true;
        radioPython.CheckedChanged += RadioPython_CheckedChanged;

        // radioCSharp
        radioCSharp.AutoSize = true;
        radioCSharp.Location = new Point(260, 145);
        radioCSharp.Name = "radioCSharp";
        radioCSharp.Text = "C#";
        radioCSharp.CheckedChanged += RadioCSharp_CheckedChanged;

        // panelLeft
        panelLeft.Location = new Point(20, 180);
        panelLeft.Name = "panelLeft";
        panelLeft.Size = new Size(540, 620);
        panelLeft.AutoScroll = true;
        panelLeft.BorderStyle = BorderStyle.FixedSingle;

        // groupBoxPythonData
        groupBoxPythonData.Controls.Add(checkBoxNumpy);
        groupBoxPythonData.Controls.Add(checkBoxPandas);
        groupBoxPythonData.Controls.Add(checkBoxScikitLearn);
        groupBoxPythonData.Controls.Add(checkBoxTensorFlow);
        groupBoxPythonData.Location = new Point(5, 5);
        groupBoxPythonData.Size = new Size(500, 95);
        groupBoxPythonData.Text = "Data Science & ML";
        groupBoxPythonData.Tag = "python";

        checkBoxNumpy.AutoSize = true;
        checkBoxNumpy.Location = new Point(10, 25);
        checkBoxNumpy.Text = "NumPy";
        checkBoxNumpy.Tag = "python";

        checkBoxPandas.AutoSize = true;
        checkBoxPandas.Location = new Point(110, 25);
        checkBoxPandas.Text = "Pandas";
        checkBoxPandas.Tag = "python";

        checkBoxScikitLearn.AutoSize = true;
        checkBoxScikitLearn.Location = new Point(210, 25);
        checkBoxScikitLearn.Text = "Scikit-learn";
        checkBoxScikitLearn.Tag = "python";

        checkBoxTensorFlow.AutoSize = true;
        checkBoxTensorFlow.Location = new Point(10, 55);
        checkBoxTensorFlow.Text = "TensorFlow";
        checkBoxTensorFlow.Tag = "python";

        // groupBoxPythonWeb
        groupBoxPythonWeb.Controls.Add(checkBoxFlask);
        groupBoxPythonWeb.Controls.Add(checkBoxDjango);
        groupBoxPythonWeb.Controls.Add(checkBoxFastAPI);
        groupBoxPythonWeb.Controls.Add(checkBoxBeautifulSoup);
        groupBoxPythonWeb.Location = new Point(5, 105);
        groupBoxPythonWeb.Size = new Size(500, 95);
        groupBoxPythonWeb.Text = "Web & Scraping";
        groupBoxPythonWeb.Tag = "python";

        checkBoxFlask.AutoSize = true;
        checkBoxFlask.Location = new Point(10, 25);
        checkBoxFlask.Text = "Flask";
        checkBoxFlask.Tag = "python";

        checkBoxDjango.AutoSize = true;
        checkBoxDjango.Location = new Point(110, 25);
        checkBoxDjango.Text = "Django";
        checkBoxDjango.Tag = "python";

        checkBoxFastAPI.AutoSize = true;
        checkBoxFastAPI.Location = new Point(210, 25);
        checkBoxFastAPI.Text = "FastAPI";
        checkBoxFastAPI.Tag = "python";

        checkBoxBeautifulSoup.AutoSize = true;
        checkBoxBeautifulSoup.Location = new Point(10, 55);
        checkBoxBeautifulSoup.Text = "Beautiful Soup";
        checkBoxBeautifulSoup.Tag = "python";

        // groupBoxPythonUtil
        groupBoxPythonUtil.Controls.Add(checkBoxRequests);
        groupBoxPythonUtil.Controls.Add(checkBoxMatplotlib);
        groupBoxPythonUtil.Controls.Add(checkBoxPytest);
        groupBoxPythonUtil.Controls.Add(checkBoxPython_dotenv);
        groupBoxPythonUtil.Location = new Point(5, 205);
        groupBoxPythonUtil.Size = new Size(500, 95);
        groupBoxPythonUtil.Text = "Utilities & Testing";
        groupBoxPythonUtil.Tag = "python";

        checkBoxRequests.AutoSize = true;
        checkBoxRequests.Location = new Point(10, 25);
        checkBoxRequests.Text = "Requests";
        checkBoxRequests.Tag = "python";

        checkBoxMatplotlib.AutoSize = true;
        checkBoxMatplotlib.Location = new Point(120, 25);
        checkBoxMatplotlib.Text = "Matplotlib";
        checkBoxMatplotlib.Tag = "python";

        checkBoxPytest.AutoSize = true;
        checkBoxPytest.Location = new Point(10, 55);
        checkBoxPytest.Text = "Pytest";
        checkBoxPytest.Tag = "python";

        checkBoxPython_dotenv.AutoSize = true;
        checkBoxPython_dotenv.Location = new Point(120, 55);
        checkBoxPython_dotenv.Text = "python-dotenv";
        checkBoxPython_dotenv.Tag = "python";

        // groupBoxPythonInfra
        groupBoxPythonInfra.Controls.Add(checkBoxSQLAlchemy);
        groupBoxPythonInfra.Controls.Add(checkBoxRedis);
        groupBoxPythonInfra.Controls.Add(checkBoxCelery);
        groupBoxPythonInfra.Controls.Add(checkBoxScrapy);
        groupBoxPythonInfra.Controls.Add(checkBoxPillow);
        groupBoxPythonInfra.Controls.Add(checkBoxPyTorch);
        groupBoxPythonInfra.Location = new Point(5, 305);
        groupBoxPythonInfra.Size = new Size(500, 95);
        groupBoxPythonInfra.Text = "Data & Infra";
        groupBoxPythonInfra.Tag = "python";

        checkBoxSQLAlchemy.AutoSize = true;
        checkBoxSQLAlchemy.Location = new Point(10, 25);
        checkBoxSQLAlchemy.Text = "SQLAlchemy";
        checkBoxSQLAlchemy.Tag = "python";

        checkBoxRedis.AutoSize = true;
        checkBoxRedis.Location = new Point(130, 25);
        checkBoxRedis.Text = "Redis";
        checkBoxRedis.Tag = "python";

        checkBoxCelery.AutoSize = true;
        checkBoxCelery.Location = new Point(240, 25);
        checkBoxCelery.Text = "Celery";
        checkBoxCelery.Tag = "python";

        checkBoxScrapy.AutoSize = true;
        checkBoxScrapy.Location = new Point(10, 55);
        checkBoxScrapy.Text = "Scrapy";
        checkBoxScrapy.Tag = "python";

        checkBoxPillow.AutoSize = true;
        checkBoxPillow.Location = new Point(130, 55);
        checkBoxPillow.Text = "Pillow";
        checkBoxPillow.Tag = "python";

        checkBoxPyTorch.AutoSize = true;
        checkBoxPyTorch.Location = new Point(240, 55);
        checkBoxPyTorch.Text = "PyTorch";
        checkBoxPyTorch.Tag = "python";

        // groupBoxPythonTooling
        groupBoxPythonTooling.Controls.Add(checkBoxJupyter);
        groupBoxPythonTooling.Controls.Add(checkBoxBlack);
        groupBoxPythonTooling.Controls.Add(checkBoxPydantic);
        groupBoxPythonTooling.Controls.Add(checkBoxClick);
        groupBoxPythonTooling.Controls.Add(checkBoxAlembic);
        groupBoxPythonTooling.Location = new Point(5, 405);
        groupBoxPythonTooling.Size = new Size(500, 95);
        groupBoxPythonTooling.Text = "Tooling & CLI";
        groupBoxPythonTooling.Tag = "python";

        checkBoxJupyter.AutoSize = true;
        checkBoxJupyter.Location = new Point(10, 25);
        checkBoxJupyter.Text = "Jupyter";
        checkBoxJupyter.Tag = "python";

        checkBoxBlack.AutoSize = true;
        checkBoxBlack.Location = new Point(100, 25);
        checkBoxBlack.Text = "Black";
        checkBoxBlack.Tag = "python";

        checkBoxPydantic.AutoSize = true;
        checkBoxPydantic.Location = new Point(190, 25);
        checkBoxPydantic.Text = "Pydantic";
        checkBoxPydantic.Tag = "python";

        checkBoxClick.AutoSize = true;
        checkBoxClick.Location = new Point(10, 55);
        checkBoxClick.Text = "Click";
        checkBoxClick.Tag = "python";

        checkBoxAlembic.AutoSize = true;
        checkBoxAlembic.Location = new Point(100, 55);
        checkBoxAlembic.Text = "Alembic";
        checkBoxAlembic.Tag = "python";

        // groupBoxCSharpData
        groupBoxCSharpData.Controls.Add(checkBoxEFCore);
        groupBoxCSharpData.Controls.Add(checkBoxDapper);
        groupBoxCSharpData.Controls.Add(checkBoxNewtonsoft);
        groupBoxCSharpData.Location = new Point(5, 5);
        groupBoxCSharpData.Size = new Size(500, 80);
        groupBoxCSharpData.Text = "Data & Serialization";
        groupBoxCSharpData.Tag = "csharp";
        groupBoxCSharpData.Visible = false;

        checkBoxEFCore.AutoSize = true;
        checkBoxEFCore.Location = new Point(10, 25);
        checkBoxEFCore.Text = "Entity Framework Core";
        checkBoxEFCore.Tag = "csharp";

        checkBoxDapper.AutoSize = true;
        checkBoxDapper.Location = new Point(10, 50);
        checkBoxDapper.Text = "Dapper";
        checkBoxDapper.Tag = "csharp";

        checkBoxNewtonsoft.AutoSize = true;
        checkBoxNewtonsoft.Location = new Point(180, 50);
        checkBoxNewtonsoft.Text = "Newtonsoft.Json";
        checkBoxNewtonsoft.Tag = "csharp";

        // groupBoxCSharpWeb
        groupBoxCSharpWeb.Controls.Add(checkBoxAspNetCore);
        groupBoxCSharpWeb.Controls.Add(checkBoxSwagger);
        groupBoxCSharpWeb.Controls.Add(checkBoxMediatR);
        groupBoxCSharpWeb.Location = new Point(5, 90);
        groupBoxCSharpWeb.Size = new Size(500, 80);
        groupBoxCSharpWeb.Text = "Web & Architecture";
        groupBoxCSharpWeb.Tag = "csharp";
        groupBoxCSharpWeb.Visible = false;

        checkBoxAspNetCore.AutoSize = true;
        checkBoxAspNetCore.Location = new Point(10, 25);
        checkBoxAspNetCore.Text = "ASP.NET Core";
        checkBoxAspNetCore.Tag = "csharp";

        checkBoxSwagger.AutoSize = true;
        checkBoxSwagger.Location = new Point(120, 25);
        checkBoxSwagger.Text = "Swagger/OpenAPI";
        checkBoxSwagger.Tag = "csharp";

        checkBoxMediatR.AutoSize = true;
        checkBoxMediatR.Location = new Point(260, 25);
        checkBoxMediatR.Text = "MediatR";
        checkBoxMediatR.Tag = "csharp";

        // groupBoxCSharpTest
        groupBoxCSharpTest.Controls.Add(checkBoxXUnit);
        groupBoxCSharpTest.Controls.Add(checkBoxNUnit);
        groupBoxCSharpTest.Controls.Add(checkBoxSerilog);
        groupBoxCSharpTest.Controls.Add(checkBoxPolly);
        groupBoxCSharpTest.Location = new Point(5, 175);
        groupBoxCSharpTest.Size = new Size(500, 95);
        groupBoxCSharpTest.Text = "Testing & Resilience";
        groupBoxCSharpTest.Tag = "csharp";
        groupBoxCSharpTest.Visible = false;

        checkBoxXUnit.AutoSize = true;
        checkBoxXUnit.Location = new Point(10, 25);
        checkBoxXUnit.Text = "xUnit";
        checkBoxXUnit.Tag = "csharp";

        checkBoxNUnit.AutoSize = true;
        checkBoxNUnit.Location = new Point(100, 25);
        checkBoxNUnit.Text = "NUnit";
        checkBoxNUnit.Tag = "csharp";

        checkBoxSerilog.AutoSize = true;
        checkBoxSerilog.Location = new Point(10, 55);
        checkBoxSerilog.Text = "Serilog";
        checkBoxSerilog.Tag = "csharp";

        checkBoxPolly.AutoSize = true;
        checkBoxPolly.Location = new Point(120, 55);
        checkBoxPolly.Text = "Polly";
        checkBoxPolly.Tag = "csharp";

        // groupBoxCSharpInfra
        groupBoxCSharpInfra.Controls.Add(checkBoxRefit);
        groupBoxCSharpInfra.Controls.Add(checkBoxAutofac);
        groupBoxCSharpInfra.Controls.Add(checkBoxNLog);
        groupBoxCSharpInfra.Controls.Add(checkBoxRabbitMQ);
        groupBoxCSharpInfra.Controls.Add(checkBoxMongoDB);
        groupBoxCSharpInfra.Controls.Add(checkBoxGraphQL);
        groupBoxCSharpInfra.Controls.Add(checkBoxIdentityModel);
        groupBoxCSharpInfra.Controls.Add(checkBoxHangfire);
        groupBoxCSharpInfra.Controls.Add(checkBoxFluentAssertions);
        groupBoxCSharpInfra.Controls.Add(checkBoxEFCoreTools);
        groupBoxCSharpInfra.Location = new Point(5, 280);
        groupBoxCSharpInfra.Size = new Size(500, 140);
        groupBoxCSharpInfra.Text = "API & Infra";
        groupBoxCSharpInfra.Tag = "csharp";
        groupBoxCSharpInfra.Visible = false;

        // row 1
        checkBoxRefit.AutoSize = true;
        checkBoxRefit.Location = new Point(10, 25);
        checkBoxRefit.Text = "Refit";
        checkBoxRefit.Tag = "csharp";

        checkBoxAutofac.AutoSize = true;
        checkBoxAutofac.Location = new Point(150, 25);
        checkBoxAutofac.Text = "Autofac";
        checkBoxAutofac.Tag = "csharp";

        checkBoxNLog.AutoSize = true;
        checkBoxNLog.Location = new Point(290, 25);
        checkBoxNLog.Text = "NLog";
        checkBoxNLog.Tag = "csharp";

        checkBoxRabbitMQ.AutoSize = true;
        checkBoxRabbitMQ.Location = new Point(430, 25);
        checkBoxRabbitMQ.Text = "RabbitMQ";
        checkBoxRabbitMQ.Tag = "csharp";

        // row 2
        checkBoxMongoDB.AutoSize = true;
        checkBoxMongoDB.Location = new Point(10, 55);
        checkBoxMongoDB.Text = "MongoDB";
        checkBoxMongoDB.Tag = "csharp";

        checkBoxGraphQL.AutoSize = true;
        checkBoxGraphQL.Location = new Point(150, 55);
        checkBoxGraphQL.Text = "GraphQL .NET";
        checkBoxGraphQL.Tag = "csharp";

        checkBoxIdentityModel.AutoSize = true;
        checkBoxIdentityModel.Location = new Point(290, 55);
        checkBoxIdentityModel.Text = "IdentityModel";
        checkBoxIdentityModel.Tag = "csharp";

        checkBoxHangfire.AutoSize = true;
        checkBoxHangfire.Location = new Point(430, 55);
        checkBoxHangfire.Text = "Hangfire";
        checkBoxHangfire.Tag = "csharp";

        // row 3
        checkBoxFluentAssertions.AutoSize = true;
        checkBoxFluentAssertions.Location = new Point(150, 85);
        checkBoxFluentAssertions.Text = "FluentAssertions";
        checkBoxFluentAssertions.Tag = "csharp";

        checkBoxEFCoreTools.AutoSize = true;
        checkBoxEFCoreTools.Location = new Point(290, 85);
        checkBoxEFCoreTools.Text = "EF Core Tools";
        checkBoxEFCoreTools.Tag = "csharp";

        // Add groups to panel
        panelLeft.Controls.Add(groupBoxPythonData);
        panelLeft.Controls.Add(groupBoxPythonWeb);
        panelLeft.Controls.Add(groupBoxPythonUtil);
        panelLeft.Controls.Add(groupBoxPythonInfra);
        panelLeft.Controls.Add(groupBoxPythonTooling);
        panelLeft.Controls.Add(groupBoxCSharpData);
        panelLeft.Controls.Add(groupBoxCSharpWeb);
        panelLeft.Controls.Add(groupBoxCSharpTest);
        panelLeft.Controls.Add(groupBoxCSharpInfra);

        // buttonCreate
        buttonCreate.BackColor = Color.FromArgb(0, 122, 204);
        buttonCreate.ForeColor = Color.White;
        buttonCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        buttonCreate.Location = new Point(20, 820);
        buttonCreate.Name = "buttonCreate";
        buttonCreate.Size = new Size(120, 40);
        buttonCreate.Text = "✓ Create";
        buttonCreate.Click += ButtonCreate_Click;

        // buttonClear
        buttonClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        buttonClear.Location = new Point(150, 820);
        buttonClear.Name = "buttonClear";
        buttonClear.Size = new Size(120, 40);
        buttonClear.Text = "✕ Clear";
        buttonClear.Click += ButtonClear_Click;

        // labelEnvironments
        labelEnvironments.AutoSize = true;
        labelEnvironments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        labelEnvironments.Location = new Point(580, 180);
        labelEnvironments.Text = "Environments:";

        // listBoxEnvironments
        listBoxEnvironments.FormattingEnabled = true;
        listBoxEnvironments.ItemHeight = 20;
        listBoxEnvironments.Location = new Point(580, 205);
        listBoxEnvironments.Name = "listBoxEnvironments";
        listBoxEnvironments.Size = new Size(480, 555);

        // Form1
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 920);
        Controls.Add(labelTitle);
        Controls.Add(labelName);
        Controls.Add(textBoxName);
        Controls.Add(labelPath);
        Controls.Add(textBoxPath);
        Controls.Add(buttonBrowse);
        Controls.Add(labelType);
        Controls.Add(radioPython);
        Controls.Add(radioCSharp);
        Controls.Add(panelLeft);
        Controls.Add(buttonCreate);
        Controls.Add(buttonClear);
        Controls.Add(labelEnvironments);
        Controls.Add(listBoxEnvironments);
        Name = "Form1";
        Text = "Environment Creator";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
