using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    public class UserMenuPage
    {
        IWebDriver driver;
        public UserMenuPage(IWebDriver driver) 
        { 
            this.driver=driver;
        }

     IWebElement loginbutton => driver.FindElement(By.XPath("//a[text()='Login']"));
     IWebElement UserLoginName => driver.FindElement(By.Name("username"));
     IWebElement Userpassword => driver.FindElement(By.Name("password"));
     IWebElement Userloginbtn => driver.FindElement(By.XPath("//input[@type='submit']"));
     IWebElement restobutton => driver.FindElement(By.XPath("//a[text()='Restaurants ']"));
     IWebElement viewmenu => driver.FindElement(By.XPath("//div[341]//div[2]//h5[1]//a[1]"));
     IWebElement cart=>driver.FindElement(By.XPath("//div[@id='2']//div[1]//div[1]//div[2]//input[2]"));
     IWebElement checkbutton=>  driver.FindElement(By.XPath("//a[text()='Checkout']"));
     IWebElement cashradiobutton=> driver.FindElement(By.XPath("//label[contains(@class,'m-b-20')]"));
     IWebElement ordernow=>   driver.FindElement(By.XPath("//input[@type='submit']"));

        public IWebElement ClickONLogBtn()
        {
            return loginbutton;
        }
        public void Login(string Username1, string Password2)
        {
            UserLoginName.SendKeys(Username1);
            Userpassword.SendKeys(Password2);
            Userloginbtn.Click();
        }
        public void ClickONRestoBtn()
        {
            restobutton.Click();
        }
        public IWebElement Run()
        {
            return viewmenu;
        }
        public IWebElement AddCartBtn()
        {
            return cart;
        }
    public IWebElement CheckoutBtn()
    {
      return checkbutton;
    }
    public IWebElement CashonButton()
    {
            return cashradiobutton;
    }
    public IWebElement OrderButton()
    {
            return ordernow;
     }




    }
}
