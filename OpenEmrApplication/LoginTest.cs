using AutomationWrapper.Base;
using NUnit.Framework;
using OpenEmrApplication.Pages;
using OpenEmrApplication.Utilities;

namespace OpenEmrApplication
{
    class LoginTest : WebDriverWrapper
    {
        [Test]
        public void AcknowledgmentLicensingCertificationLinkTest()
        {
            LoginPage login = new LoginPage(driver);
            login.ClickOnAcknowledgementsLicensingCertification();

            login.switchToAcknowledgementsLicensingCertificationTab();
            AckLicCertPage ack = new AckLicCertPage(driver);
            Assert.IsTrue(ack.GetPageSource().Contains("License information"), "Assertion using page contains License information");
        }

        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "InvalidCredentialData")]
        [TestCase("john","john123","Dutch","Invalid username or password")]
        [TestCase("Peter", "perter123", "Danish", "Invalid username or password")]
        public void InvalidCredentialTest(string username, string password, string language, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.SubmitButton();

            Assert.AreEqual(expectedValue, login.GetErrorMessage());
        }

        [Test,Description("Valid Credential test"),TestCaseSource(typeof(TestCaseSourceUtils), "ValidCredentialData")]
        public void ValidCredentialTest(string username, string password, string language, string expectedValue)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.SubmitButton();

            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.WaitForPresenceOfCalendar();
            Assert.AreEqual(expectedValue, dashboard.GetTitle());


        }
    }
}
