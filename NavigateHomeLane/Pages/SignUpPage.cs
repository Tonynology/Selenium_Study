using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeLane.Pages
{
    class SignUpPage
    {
        private By registerLocator = By.XPath("//a[normalize-space()='Login/Register']");
        private By nameLocator = By.XPath("//input[@id='username']");
        private By phoneNumLocator = By.XPath("//input[@id='userphone']");
        private By emailLocator = By.XPath("//input[@id='useremail']");
        private By pinLocator = By.XPath("//input[@id='pincode']");
        private By continueLocator = By.XPath("//button[normalize-space()='Sign Up']");
        private By errorMessageLocator = By.XPath("//label[normalize-space()='Please enter your phone number']");
        private IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnRegister()
        {
            driver.FindElement(registerLocator).Click();
        }
        public void SendName(string name)
        {
            driver.FindElement(nameLocator).SendKeys(name);
        }
        public void SendPhoneNum(string phoneNum)
        {
            driver.FindElement(phoneNumLocator).SendKeys(phoneNum);
        }
        public void SendEmail(string email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
        }
        public void SendPin(string pinNum)
        {
            driver.FindElement(pinLocator).SendKeys(pinNum);
        }
        public void ClickOnContinue()
        {
            driver.FindElement(continueLocator).Click();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageLocator).Text.Trim();
        }
    }
}
