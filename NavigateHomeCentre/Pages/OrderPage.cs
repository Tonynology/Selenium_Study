using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeCentre.Pages
{
    class OrderPage
    {
        private By cameraLocator = By.XPath("//div[contains(text(),'Cameras')]");
        private By DSLRLocator = By.XPath("//a[@class='nav__description__hoverULine'][normalize-space()='DSLR Cameras']");
        private By firstProductLocator = By.XPath("//p[contains(text(),'Canon EOS 200D II DSLR Camera with 18-55 mm and 55')]");
        private By pinCodeLocator = By.XPath("//input[@id='RIL_PDPInputPincode']");
        private By addToCartLocator = By.XPath("//button[@id='add_to_cart_main_btn']");
        private By removeLocator = By.XPath("//button[@id='btn-cab-remove-491431413']");
        private By yesLocator = By.XPath("//button[@class='ripple sc-bwzfXH hAqxqA sc-jzJRlG hhKkJF']");
        private By removeCartMessageLocator = By.XPath("//div[@class='sc-bxivhb fYljnK']");

        private IWebDriver driver;

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnCamera()
        {
            driver.FindElement(cameraLocator).Click();
        }
        public void ClickOnDSLR()
        {
            driver.FindElement(DSLRLocator).Click();
        } 
        public void ClickOnFirstProduct()
        {
            driver.FindElement(firstProductLocator).Click();
        }
        public void SwitchToProductTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }
        public void SendPinCode(string pinCode)
        {
            driver.FindElement(pinCodeLocator).SendKeys(pinCode);
        }
        public void ClickOnAddToCart()      // Error Occur
        {
            driver.FindElement(addToCartLocator).Click();
        }
        public void ClickOnRemove()
        {
            driver.FindElement(removeLocator).Click();
        }
        public void ClickYes()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));//ignore no alert exception

            driver.FindElement(yesLocator).Click();
        }
        public string afterMessageOfRemoveCart()
        {
            return driver.FindElement(removeCartMessageLocator).Text.Trim();
        }
    }
}
