using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.GenericUtilityFolder
{
    public class ScreenShotHelper
    {
        private readonly IWebDriver driver;
        private readonly string screenshotFolderPath;

        public ScreenShotHelper(IWebDriver driver, string screenshotFolderPath)
        {
            this.driver = driver;
            this.screenshotFolderPath = screenshotFolderPath;
        }

        public void TakeScreenshot(string screenshotName)
        {
            // Create directory if it doesn't exist
            Directory.CreateDirectory(screenshotFolderPath);

            // Capture screenshot
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            // Save screenshot
            string screenshotFilePath = Path.Combine(screenshotFolderPath, $"{screenshotName}_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.png");
            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
        }
    }
}
}
