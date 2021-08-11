using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeLane.Pages
{
    class OrderPage
    {
        private By homeOfficeLocator = By.LinkText("Home Office");
        private By dashWallTableLocator = By.XPath("//div[@id='HLKT00000601']");
        private By bookButtonLocator = By.XPath("//button[@id='bfcbtn']");
        private By nameLocator = By.XPath("//input[@placeholder='Enter your name']");
        private By emailLocator = By.XPath("//input[@placeholder='Enter your email']");
        private By mobileLocator = By.XPath("//input[@placeholder='Enter your mobile number']");
        private By pinLocator = By.XPath("//input[@id='pincode']");
        private By finalBookLocator = By.XPath("//button[@id='bfc']");
        private By errorMessageLocator = By.XPath("//label[normalize-space()='Please enter pincode.']");

        private IWebDriver driver;

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnHomeOffice()
        {
            driver.FindElement(homeOfficeLocator).Click();
        }
        public void ClickOnDashWallTable()
        {
            IWebElement ele = driver.FindElement(dashWallTableLocator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", ele);

            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollTo(0, 700)");        //scrolling down using JavaScript.
            //driver.FindElement(dashWallTableLocator).Click();

            //var element = driver.FindElement(dashWallTableLocator);
            //Actions actions = new Actions(driver);
            //actions.MoveToElement(element);           //Mouse locate on to the specific element.
            //actions.Perform();
            //element.Click();
        }
        public void ClickOnBookButton()
        {
            driver.FindElement(bookButtonLocator).Click();
        }
        public void SendName(string name)
        {
            driver.FindElement(nameLocator).SendKeys(name);
        }
        public void SendEmail(string email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
        }
        public void SendMobileNum(string mobileNum)
        {
            driver.FindElement(mobileLocator).SendKeys(mobileNum);
        }
        public void SendPinNum(string pinNum)
        {
            driver.FindElement(pinLocator).SendKeys(pinNum);
        }
        public void ClickOnFinalBookButton()
        {
            driver.FindElement(finalBookLocator).Click();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageLocator).Text.Trim();
        }
    }
}
