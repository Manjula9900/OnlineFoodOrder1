using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    internal class RegisterPage
    {
        IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement regbutton => driver.FindElement(By.XPath("//a[text()='Register']"));
        IWebElement un => driver.FindElement(By.Id("example-text-input"));
        IWebElement FirstName => driver.FindElement(By.Name("firstname"));
        IWebElement LName => driver.FindElement(By.Name("lastname"));
        IWebElement email => driver.FindElement(By.Name("email"));
        IWebElement phoneno => driver.FindElement(By.Name("phone"));
        IWebElement pwd => driver.FindElement(By.Name("password"));
        IWebElement cpwd => driver.FindElement(By.Name("cpassword"));
        IWebElement add => driver.FindElement(By.Id("exampleTextarea"));
        IWebElement subtn => driver.FindElement(By.Name("submit"));
        public void EnterUserName(string username, string FName, string Lname, string Email, string phonenu, string password, string cnfpwd, string address)
        {
            regbutton.Click();
            un.SendKeys(username);
            FirstName.SendKeys(FName);
            LName.SendKeys(Lname);
            email.SendKeys(Email);
            phoneno.SendKeys(phonenu);
            pwd.SendKeys(password);
            cpwd.SendKeys(cnfpwd);
            add.SendKeys(address);
            subtn.Click();
        }

    }
}
