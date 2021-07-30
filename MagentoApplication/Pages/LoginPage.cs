using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagentoApplication.Pages
{
    class LoginPage
    {
        private By signInLocator = By.XPath("//span[text()='Sign in']");
        private By emailLocator = By.Id("email");
        private By passwordLocator = By.Id("pass");
        private By sendLocator = By.Name("send");
        //private By errorLocator = By.Name("send");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnSignInButton()
        {
            driver.FindElement(signInLocator).Click();
        }

        public void SendEmail(string email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
        }
        public void SendPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        } 
        public void ClickOnSendButton()
        {
            driver.FindElement(sendLocator).Click();
        }
        //public string GetErrorMessage()
        //{
        //    return driver.FindElement(errorLocator).Text.Trim();
        //}

        //click to continue

    }
}
