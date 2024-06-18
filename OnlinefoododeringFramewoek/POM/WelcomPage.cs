using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    public class WelcomPage
    {
        private IWebDriver driver;
        public WelcomPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement regbutton => driver.FindElement(By.XPath("//a[text()='Register']"));
        //IWebElement loginbutton => driver.FindElement(By.XPath("//a[text()='Login']"));
        IWebElement restobutton => driver.FindElement(By.XPath("//a[text()='Restaurants ']"));
        IWebElement myorder => driver.FindElement(By.XPath("//a[text()='My Orders']"));
        public IWebElement ClickONRegBtn()
        {
            return regbutton;
        }
        //public IWebElement ClickONLogBtn()
        //{
          // return loginbutton;
        //}
        public void ClickONRestoBtn()
        {
            restobutton.Click();
        }
        public void ClickONRMyOrderBtn()
        {
            myorder.Click();
            //  return new RegisterPage();
        }

    }
}
