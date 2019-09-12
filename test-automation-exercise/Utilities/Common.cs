using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test_automation_exercise.Utilities
{
    public static class Common
    {
        /// <summary>
        /// Wait until element is clickable and then click it
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webElement"></param>
        public static void WaitAndClick(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            webElement.Click();
        }

        /// <summary>
        /// Wait until element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webElement"></param>
        public static void WaitUntilClikable(IWebDriver driver, IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constants.timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        /// <summary>
        /// Hover element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="webElement"></param>
        public static void HoverElement(IWebDriver driver, IWebElement webElement)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(webElement).Perform();

        }

        /// <summary>
        /// FindAllElements by passing complete css selector
        /// </summary>
        /// <param name="attribute">Locator name</param>
        /// <param name="attrvalue">Locator value</param>
        public static List<IWebElement> FindAllElements(IWebDriver driver, string selector, string by = "css")
        {
            List<IWebElement> webElements = new List<IWebElement>();
            IList<IWebElement> allElements = driver.FindElements(By.CssSelector(selector));
            foreach (IWebElement element in allElements)
            {
                webElements.Add(element);
            }
            return webElements;
        }


        /// <summary>
        /// Find all elements by Xpath
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="x_path"></param>
        /// <returns></returns>
        public static List<IWebElement> FindAllElementsByXpath(IWebDriver driver, string selector)
        {
            List<IWebElement> webElements = new List<IWebElement>();
            IList<IWebElement> allElements = driver.FindElements(By.XPath(selector));
            foreach (IWebElement element in allElements)
            {
                webElements.Add(element);
            }
            return webElements;
        }

        /// <summary>
        /// Creates price
        /// </summary>
        /// <param name="text">value for parsing</param>
        /// <returns>double</returns>
        public static double GetPrice(string text)
        {
            double price;
            Regex digitsOnly = new Regex(@"[€ ]");
            text = digitsOnly.Replace(text, "").Replace(",", ".");
            Double.TryParse(text, out price);
            return price;
        }

        public static void MoveIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor jsExec = driver as IJavaScriptExecutor;
            jsExec.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public static void WindowScroolBarDown(IWebDriver driver,string scrollY = "500")
        {
            IJavaScriptExecutor jsScript = driver as IJavaScriptExecutor;
            string selectedWindow = driver.CurrentWindowHandle;

            jsScript.ExecuteScript("window.scroll(0," + scrollY + ")");
        }

        /// <summary>
        /// Wait for time to pass
        /// </summary>
        /// <param name="seconds"></param>
        public static void WaitForSeconds(int seconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.Seconds < seconds)
            {
                //Waiting
            }
            stopwatch.Stop();
        }

    }
}
