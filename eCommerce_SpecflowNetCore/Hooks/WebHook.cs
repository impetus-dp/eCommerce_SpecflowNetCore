using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;


namespace eCommerce_SpecflowNetCore.Hooks
{
    [Binding]
    public class WebHook
    {
        public static IWebDriver driver;
        private static ExtentTest featureName;
        private static ExtentTest scenario, step;
        private static ExtentReports extent;

        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar + "ExtentReport"
           + Path.DirectorySeparatorChar + "ExtentReport_" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scontext)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
          
            scenario = featureName.CreateNode<Scenario>(scontext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();

            
        }
        [BeforeTestRun]
        public static void IntialiseReport()
        {
            AventStack.ExtentReports.Reporter.ExtentV3HtmlReporter htmlreport = new ExtentV3HtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(htmlreport);
            extent.AddSystemInfo("os", "win10");
            extent.AddSystemInfo("Environment", "QA");
                        
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();

            driver.Quit();
            

        }
        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scontext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            Screenshot Ss = ((ITakesScreenshot)driver).GetScreenshot();
            string Screenshot = Ss.AsBase64EncodedString;
            try
            {
                if (scontext.TestError == null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass(ScenarioStepContext.Current.StepInfo.Text);
                }
                //Steps failed or with errors
                else if (scontext.TestError != null)
                {
                    
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scontext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scontext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scontext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
                    }
                    else if (stepType == "And")
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scontext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
                    }

                }
                else if (scontext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefinitionPending");

                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefinitionPending");

                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefinitionPending");

                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("StepDefinitionPending");
                }
            }

            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("F:\\VStudioC#\\dpayarda\\GoodWorkingCopies\\SpecFlowBddPomExtent18Sep_V1\\SpecFlowDan16Sep\\Screenshots\\Oct23.jpeg", ScreenshotImageFormat.Png);
                step.Log(Status.Info, e.ToString());
                step.Log(Status.Fail, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());

            }

        }
    }
}
