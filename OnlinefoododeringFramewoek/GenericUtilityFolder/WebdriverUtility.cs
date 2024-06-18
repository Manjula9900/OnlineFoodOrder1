using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.GenericUtilityFolder
{
    public class WebdriverUtility
    {
        public static void EnterText(IWebElement element, string value)
        {
            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        // Custom Method for Selecting from a dropdown by text
        public static void SelectFromDropDownByText(IWebElement element, string selectText)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(selectText);
        }
        // Custom Method for Selecting from a dropdown using value
        public static void SelectFromDropDownByValue(IWebElement element, string inputValue)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByValue(inputValue);
        }

        // Custom Method for Selecting from a dropdown using index
        public static void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByIndex(index);
        }

        // Custom Method for Drag and drop. we need to specify the origin element and destination elements
        public static void DragAndDropItem(IWebDriver driver, IWebElement sourceElement, IWebElement destinationElement)
        {
            Actions action = new Actions(driver);
            action.ClickAndHold(sourceElement).MoveToElement(destinationElement).Release().Perform();
        }

        // Custom method for performing a click action
        public static void ActionClick(IWebDriver driver, IWebElement Element)
        {
            Actions action = new Actions(driver);
            action.Click(Element).Build().Perform();
        }
        // Custom method for hovering over an element and then clicking it
        public static void ActionHoverAndClick(IWebDriver driver, IWebElement ElementHover, IWebElement ElementClick)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(ElementHover).Click(ElementClick).Build().Perform();
        }

        // Custom method for scrolling into view of an element
        public static void ScrollIntoView(IWebDriver driver, IWebElement Element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Element);
        }

        // Custom method for adding a think time or sleep
        public static void ThinkTime(int TimeInSeconds)
        {
            System.Threading.Thread.Sleep(TimeInSeconds * 1000);
        }

    }
}
