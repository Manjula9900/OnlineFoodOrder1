using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    internal class AdminDashBoardPage
    {
        public IWebDriver driver;
        public AdminDashBoardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        private IWebElement menu => driver.FindElement(By.XPath("//span[.='Menu']"));
        //js.ExecuteScript("arguments[0].click();", menu);
        //LogOut
        private IWebElement ProfilePic => driver.FindElement(By.CssSelector(".profile-pic"));
        private IWebElement LogOut => driver.FindElement(By.CssSelector(".fa-power-off"));

        public void Menu()
        {
            menu.Click();
        }
        public void Logout()
        {
            ProfilePic.Click();
            LogOut.Click();
        }
    }
}
    

