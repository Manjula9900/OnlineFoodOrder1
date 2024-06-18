using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    internal class AdminLoginPage
    {
      
            public IWebDriver driver;
            public AdminLoginPage(IWebDriver driver)
            {
                this.driver = driver;
            }
            private IWebElement AdminName => driver.FindElement(By.Name("username"));
            private IWebElement Adminpassword => driver.FindElement(By.Name("password"));

            public void Login(string username, string password)
            {
                AdminName.SendKeys("username");
                Adminpassword.SendKeys("password" + Keys.Enter);
            }
        }
}
