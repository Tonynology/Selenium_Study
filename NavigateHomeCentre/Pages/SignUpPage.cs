using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeCentre.Pages
{
    class SignUpPage
    {
        private By loginLocator = By.XPath("//span[@id='RIL_HeaderLoginAndMyAccount']");
        private By registerLocator = By.XPath("//span[normalize-space()='Register']");
        private By firstnameLocator = By.XPath("//input[@id='fname']");
        private By lastnameLocator = By.XPath("//input[@id='lname']");
        private By emailLocator = By.XPath("//input[@id='email']");
        private By passwordLocator = By.XPath("//input[@id='password']");
        private By confirmedPasswordLocator = By.XPath("//input[@id='cpassword']");
        private By mobileNumLocator = By.XPath("//input[@id='mnumber']");
        private By generateLocator = By.XPath("//button[@class='ripple sc-bwzfXH gxyWrF sc-jzJRlG jAPKvX']");
        private By errorMessageLocator = By.XPath("//p[@class='sc-dNLxif kGHgbn']");


        private IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
        }        
        public void ClickOnLogin()
        {
            driver.FindElement(loginLocator).Click();
        }
        public void ClickOnRegister()
        {
            driver.FindElement(registerLocator).Click();
        }

        public void SendFirstName(string firstname)
        {
            driver.FindElement(firstnameLocator).SendKeys(firstname);
        }
        public void SendLastName(string lastname)
        {
            driver.FindElement(lastnameLocator).SendKeys(lastname);
        }
        public void SendEmail(string email)
        {
            driver.FindElement(emailLocator).SendKeys(email);
        }
        public void SendPassword(string password)
        {
            driver.FindElement(passwordLocator).SendKeys(password);
        }
        public void SendConfirmedPassword(string confirmedPassword)
        {
            driver.FindElement(confirmedPasswordLocator).SendKeys(confirmedPassword);
        }
        public void SendMobildNum(string mobileNum)
        {
            driver.FindElement(mobileNumLocator).SendKeys(mobileNum);
        }
        public void ClickOnGenerate()
        {
            driver.FindElement(generateLocator).Click();
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessageLocator).Text.Trim();
        }
    }
}
