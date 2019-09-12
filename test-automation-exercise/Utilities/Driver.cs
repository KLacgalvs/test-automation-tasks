using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_automation_exercise.Utilities
{
    public class Driver
    {
        public IWebDriver webDriver;

        public Driver(string device = "desktop")
        {
            //ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions capability = new ChromeOptions();
            capability.AddArgument("--disable-notifications");
            webDriver = new ChromeDriver(capability);
            SetTimeout();
            MaximizeWindow();

        }

        public void CloseWebDriver()
        {
            webDriver.Quit();
        }

        public void MaximizeWindow()
        {
            webDriver.Manage().Window.Maximize();
        }
        public void Navigate(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
        public void SetTimeout(int timeout = 30)
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public void Refresh()
        {
            webDriver.Navigate().Refresh();
        }
    }
}
