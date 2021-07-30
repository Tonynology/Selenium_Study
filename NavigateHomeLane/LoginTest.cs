using AutomationWrapper.Base;
using NavigateHomeCentre.Pages;
using NavigateHomeLane.Pages;
using NavigateHomeLane.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigateHomeLane
{
    class LoginTest : WebDriverWrapper
    {
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifyEmptySignData")]
        public void VerifyEmptySignTest(string name, string phoneNum, string email, string pinNum, string expectedValue)
        {
            SignUpPage SignUp = new SignUpPage(driver);
            SignUp.ClickOnRegister();
            SignUp.SendName(name);
            SignUp.SendPhoneNum(phoneNum);
            SignUp.SendEmail(email);
            SignUp.SendPin(pinNum);
            SignUp.ClickOnContinue();

            Assert.AreEqual(expectedValue, SignUp.GetErrorMessage());
        }

        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifyEmptyLoginData")]
        public void VerifyEmptyLoginTest(string email, string password, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnRegister();
            login.ClickOnLogin();
            login.SendEmail(email);
            login.SendPassword(password);
            login.ClickOnLoginButton();

            Assert.AreEqual(expectedValue, login.GetErrorMessage());
        }
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifyPlaceOrderTest")]
        public void VerifyPlaceOrderTest(string name, string email, string phoneNum, string pinNum, string expectedValue)
        {
            OrderPage order = new OrderPage(driver);
            order.ClickOnHomeOffice();
            order.ClickOnDashWallTable();
            order.ClickOnBookButton();
            order.SendName(name);
            order.SendEmail(email);
            order.SendMobileNum(phoneNum);
            order.SendPinNum(pinNum);
            order.ClickOnFinalBookButton();

            Assert.AreEqual(expectedValue, order.GetErrorMessage());
        }
    }
}
