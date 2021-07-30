using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class PatientFinderPage
    {
        private By createPatientButtonLocator = By.Id("create_patient_btn1");
        private IWebDriver driver;
        public PatientFinderPage(IWebDriver driver)
        {
            this.driver = driver;
        }        

        public void SwitchTofinFrame(string frame)
        {
            driver.SwitchTo().Frame(frame);
        }

        public void ClickOnCreatePatientButton()
        {
            driver.FindElement(createPatientButtonLocator).Click();
        }

        public void SwitchToDefaultFrame()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
