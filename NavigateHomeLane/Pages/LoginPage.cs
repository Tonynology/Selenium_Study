using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeCentre.Pages
{
    class LoginPage
    {
        private By registerLocator = By.XPath("//a[normalize-space()='Login/Register']");
        private By loginLocator = By.XPath("//a[normalize-space()='Log in']");
        private By emailLocator = By.XPath("//input[@placeholder='Enter Your Email ID']");
        private By passwordLocator = By.XPath("//input[@placeholder='Enter Your Password']");
        private By loginButtonLocator = By.XPath("//button[normalize-space()='Log In']");
        private By errorMessageLocator = By.XPath("//label[normalize-space()='Please enter your email']");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnRegister()
        {
            driver.FindElement(registerLocator).Click();
        }
        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }
        public void SendEmail(string email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
        }
        public void SendPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }
        public void ClickOnLoginButton()
        {
            driver.FindElement(loginButtonLocator).Click();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageLocator).Text.Trim();
        }
    }
}
