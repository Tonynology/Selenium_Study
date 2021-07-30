using AutomationWrapper.Base;
using MagentoApplication.Pages;
using MagentoApplication.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MagentoApplication
{
    public class LoginTest : WebDriverWrapper
    {

        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
        public void ValidCredentialTest(string userEmail, string userPassword)
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnSignInButton();
            login.SendEmail(userEmail);
            login.SendPassword(userPassword);
            login.ClickOnSendButton();

            //verification (Expected value in excel)
        }
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "InvalidCredentialData")]
        public void InvalidCredentialTest(string userEmail, string userPassword, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnSignInButton();
            login.SendEmail(userEmail);
            login.SendPassword(userPassword);
            login.ClickOnSendButton();

            //verification (Expected value in excel
            //Assert.AreEqual(expectedValue, login.GetErrorMessage());
        }
    }
}