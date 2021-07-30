using AutomationWrapper.Base;
using NavigateHomeCentre.Pages;
using NavigateHomeCentre.Utilities;
using NUnit.Framework;

namespace NavigateHomeCentre
{
    public class NavigateHomeCentre : WebDriverWrapper
    {
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifyEmptySignData")]
        public void VerifyEmptySignTest(string userEmail, string password, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnLogin();
            login.SendEmail(userEmail);
            login.SendPassword(password);
            login.ClickOnContinue();

            Assert.AreEqual(expectedValue, login.GetErrorMessage());
        }
        
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifySignUpData")]
        public void VerifySignUpTest(string firstname, string lastname, string email, string password, string confirmedPassword, string mobileNum, string expectedValue)
        {
            SignUpPage signUp = new SignUpPage(driver);
            signUp.ClickOnLogin();
            signUp.ClickOnRegister();
            signUp.SendFirstName(firstname);
            signUp.SendLastName(lastname);
            signUp.SendEmail(email);
            signUp.SendPassword(password);
            signUp.SendConfirmedPassword(confirmedPassword);
            signUp.SendMobildNum(mobileNum);
            signUp.ClickOnGenerate();

            Assert.AreEqual(expectedValue, signUp.GetErrorMessage());
        }
        
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "VerifyPlaceOrderData")]
        public void VerifyPlaceOrderTest(string pinCode, string expectedValue)
        {
            OrderPage order = new OrderPage(driver);
            order.ClickOnCamera();
            order.ClickOnDSLR();
            order.ClickOnFirstProduct();
            order.SwitchToProductTab();
            order.SendPinCode(pinCode);
            order.ClickOnAddToCart();   //Error Occur
            order.ClickOnRemove();
            order.ClickYes();

            Assert.AreEqual(expectedValue, order.afterMessageOfRemoveCart());
        }
    }
}