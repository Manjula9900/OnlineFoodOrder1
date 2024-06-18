using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using Newtonsoft.Json;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace OnlinefoododeringFramewoek.GenericUtilityFolder
{
    public class BaseClass
    {
       
        protected WebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]

        public void Extentreport()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(workingDirectory);
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Manjula");

        }


        [SetUp]
        public void Setup() 
        {
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
             driver = new ChromeDriver();
             driver.Manage().Window.Maximize();
             driver.Url = "http://49.249.28.218:8081/AppServer/Online_Food_Ordering_System/";
        }
        public static JsonUtility getDataParser()
        {
            return new JsonUtility();
        }
        [TearDown]
        public void ClosingBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();
            driver.Close();
        }
        public AventStack.ExtentReports.Model.Media captureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }
    }
}
