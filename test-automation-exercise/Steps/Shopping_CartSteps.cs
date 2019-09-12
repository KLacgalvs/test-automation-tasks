using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using test_automation_exercise.PageObjects;
using test_automation_exercise.Utilities;

namespace test_automation_exercise.Steps
{
    [Binding]
    public class Shopping_CartSteps
    {
        Driver driver;
        MainPageObjects Main;
        List<double> allProductPrices;
        List<string> allProductNames;
        public Shopping_CartSteps(Driver webdriver)
        {
            driver = webdriver;
            Main = new MainPageObjects(webdriver);
            allProductNames = new List<string>();
            allProductPrices = new List<double>();
        }

        [Given(@"I see desired webshop (.*)")]
        public void GivenISeeDesiredWebshop(string desiredUrl)
        {
            driver.Navigate(desiredUrl);
            driver.webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.timeout);
        }

        [When(@"I select desired product group and sort products by price")]
        public void WhenISelectDesiredProductGroupAndSortProductsByPrice()
        {
            Common.WaitUntilClikable(driver.webDriver, Main.DropElectronics);
            Common.HoverElement(driver.webDriver, Main.DropElectronics);
            Common.WaitAndClick(driver.webDriver, Main.LinkLaptops);
            Common.WaitAndClick(driver.webDriver, Main.DropSortBy);
            Common.WaitAndClick(driver.webDriver, Main.ButtonSortByPrice);
            Common.WaitAndClick(driver.webDriver, Main.ButtonChangeOrder);

        }

        [Then(@"I see products in (.*) order")]
        public void ThenISeeProductsInOrder(string order)
        {
            List<IWebElement> allProducts = Common.FindAllElements(driver.webDriver, "[id*='product-price']");
            for (int i = 0; i < allProducts.Count; i++)
            {
                double temp = Common.GetPrice(allProducts[i].Text);
                temp = Math.Round(temp, 2);
                allProductPrices.Add(temp);
            }

            Assert.IsTrue(allProductPrices.Count > 0, "Prices were not added to list!");

            for (int i = 1; i < allProductPrices.Count - 1; i++)
            {
                if (order == "descending")
                {
                    Assert.IsTrue(allProductPrices[i - 1] >= allProductPrices[i] && allProductPrices[i] >= allProductPrices[i + 1], "Prices were not in descending order!");
                }
                if (order == "ascending")
                {
                    Assert.IsTrue(allProductPrices[i - 1] <= allProductPrices[i] && allProductPrices[i] <= allProductPrices[i + 1], "Prices were not in ascending order!");
                }
            }
        }

        [When(@"I Add to cart (.*) products")]
        public void WhenIAddToCartProducts(int nrOfProducts)
        {
            List<IWebElement> productTitle = Common.FindAllElements(driver.webDriver, "[class='product-name']");
            List<IWebElement> addToCartButtons = Common.FindAllElements(driver.webDriver, "[class='add-to-cart gbutton ajax-cart-easy-add']");

            for (int i = 0; i < productTitle.Count; i++)
            {
                allProductNames.Add(productTitle[i].Text);
            }

            Common.WindowScroolBarDown(driver.webDriver);

            for (int i = 0; i < nrOfProducts; i++)
            {
                Common.WaitAndClick(driver.webDriver, addToCartButtons[i]);
                Common.WaitForSeconds(1);
                Common.WaitAndClick(driver.webDriver, Main.ButtonCloseMiniCart);
                Common.WaitForSeconds(1);
            }
            Common.WaitAndClick(driver.webDriver, Main.ButtonOpenCart);

        }



        [Then(@"I see (.*) desired products in cart")]
        public void ThenISeeDesiredProductsInCart(int nrOfProducts)
        {
            Common.WaitUntilClikable(driver.webDriver, Main.ButtonClearCart);
            List<IWebElement> productNames = Common.FindAllElementsByXpath(driver.webDriver, "//tr[@class='cart-item']/td[@class='td-name']");
            List<IWebElement> productPrices = Common.FindAllElementsByXpath(driver.webDriver, "//td[contains(@class, 'td-price price')]");

            Assert.IsTrue(productNames.Count == nrOfProducts && productPrices.Count == nrOfProducts,
                "Expected product count : {0} , but was {1}", nrOfProducts, productNames.Count);

            for (int i = 0; i < nrOfProducts; i++)
            {
                string name = productNames[i].Text;
                string temp = productPrices[i].Text;
                double price = Common.GetPrice(temp);
                price = Math.Round(price, 2);
                Assert.IsTrue(allProductNames[i].Contains(name), "Expected name : {0}, but was : {1} ", allProductNames[i], name);
                Assert.IsTrue(allProductPrices[i] == price, "Expected price : {0}, but was {1}", allProductPrices[i], price);

            }

        }

        [Then(@"I empty my shopping cart")]
        public void ThenIEmptyMyShoppingCart()
        {
            Common.WaitAndClick(driver.webDriver, Main.ButtonClearCart);
            Common.WaitAndClick(driver.webDriver, Main.ButtonConfirmClear);
        }

    }
}
