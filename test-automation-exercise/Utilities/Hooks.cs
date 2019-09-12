using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace test_automation_exercise.Utilities
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private Driver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
            //this._objectContainer = objectContainer ?? throw new ArgumentNullException("scenarioContext");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new Driver();
            _driver.SetTimeout();
            _driver.webDriver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_driver, typeof(IWebDriver));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.CloseWebDriver();
        }
    }
}
