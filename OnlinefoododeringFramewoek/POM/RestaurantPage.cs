using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.POM
{
    public class RestaurantPage
    {
        IWebDriver driver;
        public RestaurantPage(IWebDriver driver) 
        { 
            this.driver=driver;
        }
        
    IWebElement viewmenu=>driver.FindElement(By.XPath("//div[@class='col-xs-12 col-sm-7 col-md-7 col-lg-9']//div//div[988]//div[1]//a"));
     
       public IWebElement Run()
        {
            return viewmenu;
        }
    }
}
