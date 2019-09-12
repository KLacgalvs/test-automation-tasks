using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using test_automation_exercise.Utilities;

namespace test_automation_exercise.PageObjects
{
    public class MainPageObjects
    {
        public MainPageObjects(Driver _driver)
        {
            PageFactory.InitElements(_driver.webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Elektronika')]")]
        public IWebElement DropElectronics { get; private set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'vie datori')]")]
        public IWebElement LinkLaptops { get; private set; }

        [FindsBy(How = How.XPath, Using = "//fieldset[@class='sort-by']/select")]
        public IWebElement DropSortBy { get; private set; }

        [FindsBy(How = How.XPath, Using = "//select/option[contains(text(),'Cena')]")]
        public IWebElement ButtonSortByPrice { get; private set; }

        [FindsBy(How = How.XPath, Using = "//fieldset[@class='sort-by']//img[@class='v-middle loaded']")]
        public IWebElement ButtonChangeOrder { get; private set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@class='rbutton close-modal']")]
        public IWebElement ButtonCloseMiniCart { get; private set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='header-cart']")]
        public IWebElement ButtonOpenCart { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='clear-cart']")]
        public IWebElement ButtonClearCart { get; private set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='gbutton action-clear']")]
        public IWebElement ButtonConfirmClear { get; private set; }

        
        

    }
}
