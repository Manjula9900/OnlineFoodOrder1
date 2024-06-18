using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;

namespace OnlineFoodOrder
{
    public class Tests
    {
        public ExtentReports extent;
        public ExtentTest test;

        //report file
        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Manjula");

        }


        //Logion as user place the order, logout login as admin navigate to order and cancel the order and logout again login as user check whether order canceld.IWebDriver driver;
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Url = "http://rmgtestingserver/domain/Online_Food_Ordering_System/";
        }

        [Test, Ignore("ignore it")]
        public void Test1()
        {
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            driver.FindElement(By.Id("example-text-input")).SendKeys("Manjula");
            driver.FindElement(By.Name("firstname")).SendKeys("ManjulaDB");
            driver.FindElement(By.Name("lastname")).SendKeys("BBB");
            driver.FindElement(By.Name("email")).SendKeys("manju123@gmail.com");
            driver.FindElement(By.Name("phone")).SendKeys("9631245678");
            driver.FindElement(By.Name("password")).SendKeys("Manju123@");
            driver.FindElement(By.Name("cpassword")).SendKeys("Manju123@");
            driver.FindElement(By.Id("exampleTextarea")).SendKeys("Rajajinagar 3rd block");
            driver.FindElement(By.Name("submit")).Click();
        }
        [Test]
        public void Test2()
        {
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Name("username")).SendKeys("Manjula");
            driver.FindElement(By.Name("password")).SendKeys("Manju123@" + Keys.Enter);
            driver.FindElement(By.XPath("//a[text()='Restaurants ']")).Click();
            driver.FindElement(By.XPath("//div[@class='col-xs-12 col-sm-7 col-md-7 col-lg-9']//div//div[988]//div[1]//a")).Click();
            driver.FindElement(By.XPath("//div[@id='2']//div[1]//div[1]//div[2]//input[2]")).Click();
            driver.FindElement(By.XPath("//a[text()='Checkout']")).Click();
            driver.FindElement(By.XPath("//label[contains(@class,'m-b-20')]")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().Alert().Accept();

        }
        [Test]
        public void Test3()
        {
            driver.Url = "http://rmgtestingserver/domain/Online_Food_Ordering_System/Admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("codeastro");
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
            driver.FindElement(By.XPath("//span[text()='Orders']")).Click();
            // driver.FindElement(By.XPath("//td[text()='Manjula']")).Click();
            Thread.Sleep(1000);
            IList<IWebElement> tr = driver.FindElements(By.XPath("//table[@id='myTable']//tr//td[1]"));
            foreach (IWebElement element in tr)
            {
                List< string> list = new List<string>();
                string act_text = element.Text;
                list.Add(act_text);
                if (list.Contains("Manjula"))
                 {
                    Console.WriteLine("order placed");
                    driver.FindElement(By.XPath("//td[text()='Manjula']/following-sibling::td[7]//a[1]")).Click();
                    driver.SwitchTo().Alert().Accept();
                }
                //IJavaScriptExecutor jss = (IJavaScriptExecutor)driver;
                //jss.ExecuteScript("arguments[0].ScrollIntoView(true);",ele);
                /* driver.FindElement(By.XPath("//td[text()='Manjula']/following-sibling::td[7]//a[1]")).Click();
                 driver.FindElement(By.XPath("//button[text()=' Dispatch']")).Click();
                 driver.FindElement(By.XPath("//button[text()='Update Order Status']")).Click();


                 string parent = driver.CurrentWindowHandle;
                 IList<string> ch = driver.WindowHandles;
                 foreach (string id in ch)
                 {
                     if (!id.Equals(parent))
                     {
                        string url = driver.SwitchTo().Window(id).Url;

                         IWebElement dropdown = driver.FindElement(By.XPath("//tr[3]//td[2]//select"));
                         SelectElement sel = new SelectElement(dropdown);
                         sel.SelectByText("Cancelled");
                         Thread.Sleep(2000);
                         driver.FindElement(By.XPath("//textarea[@name='remark']")).SendKeys("cancel the order");
                         Thread.Sleep(2000);
                         driver.FindElement(By.XPath("//input[@name='update']")).Click();

                     }

                 }*/
            }
        }

            /* [Test]
             public void Test4()
             {
                 driver.FindElement(By.XPath("//a[text()='Login']")).Click();
                 driver.FindElement(By.Name("username")).SendKeys("Manjula");
                 driver.FindElement(By.Name("password")).SendKeys("Manju123@" + Keys.Enter);
                 driver.FindElement(By.XPath("//a[text()='My Orders']")).Click();
             }*/




            [TearDown]
            public void closing()
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

            driver.Dispose();
            }
          public AventStack.ExtentReports.Model.Media captureScreenShot(IWebDriver driver, String screenShotName)

           {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();




        }



    }
    }


