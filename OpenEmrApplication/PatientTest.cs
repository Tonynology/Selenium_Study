using AutomationWrapper.Base;
using NUnit.Framework;
using OpenEmrApplication.Pages;
using OpenEmrApplication.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication
{
    class PatientTest : WebDriverWrapper
    {        
        [Test, TestCaseSource(typeof(TestCaseSourceUtils), "AddPatientData")]
        public void AddPatientTest(string username, string password, string language, 
            string firstname, string lastname, string DOB, string gender, string expectedAlert, 
            string expectedPatientName)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.SelectLanguageByText(language);
            login.SubmitButton();

            //DashboardPage
            DashboardPage dashboard = new DashboardPage(driver);
            dashboard.ClickOnPatientOrClient();
            dashboard.ClickOnPatient();

            //PatientFinderPage
            PatientFinderPage patientFinder = new PatientFinderPage(driver);
            patientFinder.SwitchTofinFrame("fin");
            patientFinder.ClickOnCreatePatientButton();
            patientFinder.SwitchToDefaultFrame();

            //SearchOrAddPatientPage
            SearchOrAddPatientPage searchOrAddPatient = new SearchOrAddPatientPage(driver);
            searchOrAddPatient.SwitchToPatFrame("pat");
            searchOrAddPatient.sendPatientFName(firstname);
            searchOrAddPatient.sendPatientLName(lastname);
            searchOrAddPatient.sendCalender(DOB);
            searchOrAddPatient.selectSex(gender);
            searchOrAddPatient.ClickOnCreate();
            searchOrAddPatient.SwitchToDefaultContent();

            searchOrAddPatient.SwitchToModalFrame("modalframe");
            searchOrAddPatient.ClickOnConfirm();
            searchOrAddPatient.SwitchToDefaultContent();

            string actualValue = searchOrAddPatient.WaitForAlertGetTextAndAccept();
            searchOrAddPatient.CheckAndClosePopUp();

            //PatientDashboardPage
            PatientDashboardPage patientDashboard = new PatientDashboardPage(driver);
            patientDashboard.SwitchToPatFrame("Pat");

            Assert.IsTrue(actualValue.Contains(expectedAlert));//given condition must be true otherwise method is failure
            String actualValueOfAddedPatient = driver.FindElement(By.XPath("//h2[contains(text(),'Medical')]")).Text;
            //should be present here
            Assert.AreEqual(expectedPatientName, actualValueOfAddedPatient);


        }
    }
}
