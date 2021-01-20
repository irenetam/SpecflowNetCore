using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public class TestHooks
    {
        private static AventStack.ExtentReports.ExtentReports report;
        private static ExtentTest featureName;
        private static ExtentTest scenario;

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private IWebDriver webDriver;
        public TestHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentV3HtmlReporter(@"C:\Reports\FinalReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "Report test" + DateTime.Now;
            report = new AventStack.ExtentReports.ExtentReports();
            report.AttachReporter(htmlReporter);
        }
        [Before]
        public void CreateWebDriver(ScenarioContext context)
        {
            // We are using Chrome, but you can use any driver
            SelectBrowser(BrowserType.Firefox);
            context["WEB_DRIVER"] = webDriver;
            featureName = report.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        private void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();

                    // options = _ChromePerformanceOptions();

                    options.AddArgument("--start-maximized");
                    options.AddArgument("--disable-notifications");

                    //options.SetLoggingPreference("goog:loggingPrefs", LogLevel.All);
                    //options.SetLoggingPreference("performance", LogLevel.All);
                    webDriver = new ChromeDriver(options);
                    break;
                case BrowserType.Firefox:
                    var op = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    };
                    webDriver = new FirefoxDriver(op);
                    webDriver.Manage().Window.Maximize();
                    break;
                case BrowserType.IE:
                    break;
            }
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();


            if (_scenarioContext.TestError == null)
            {
                CreateNodeStepInfo(stepType, _scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                CreateNodeError(stepType, _scenarioContext.TestError);
            }
        }

        private void CreateNodeError(string stepType, Exception testError)
        {
            switch (stepType)
            {
                case "Given":
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(testError.InnerException);
                    break;
                case "When":
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(testError.InnerException);
                    break;
                case "Then":
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(testError.Message);
                    break;
                default:
                    break;
            }
        }

        private void CreateNodeStepInfo(string stepType, string stepInfo)
        {
            switch (stepType)
            {
                case "Given":
                    scenario.CreateNode<Given>(stepInfo);
                    break;
                case "When":
                    scenario.CreateNode<When>(stepInfo);
                    break;
                case "Then":
                    scenario.CreateNode<Then>(stepInfo);
                    break;
                case "And":
                    scenario.CreateNode<And>(stepInfo);
                    break;
                default:
                    break;
            }
        }

        [AfterScenario]
        public void CloseWebDriver(ScenarioContext context)
        {
            var driver = context["WEB_DRIVER"] as IWebDriver;
            driver.Close();
            driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Write the report to the report directory
            report.Flush();
        }
    }

    enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
}
