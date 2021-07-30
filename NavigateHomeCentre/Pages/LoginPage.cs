using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeCentre.Pages
{
    class LoginPage
    {
        private By loginLocator = By.XPath("//span[@id='RIL_HeaderLoginAndMyAccount']");
        private By usernameLocator = By.XPath("//input[@id='email']");
        private By passwordLocator = By.XPath("//input[@id='email']");
        private By errorMessageLocator = By.XPath("//div[@class='sc-chPdSV iesTLv']//div[1]//div[2]");
        private By continueButtonLocator = By.XPath("//button[@class='ripple sc-bwzfXH ePDJxz sc-jzJRlG dDDLqU']");
                
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }
        public void SendEmail(string userEmail)
        {
            driver.FindElement(usernameLocator).SendKeys(userEmail);
        }
        public void SendPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }
        public void ClickOnContinue()
        {
            driver.FindElement(continueButtonLocator).Click();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageLocator).Text.Trim();
        }
    }
}
