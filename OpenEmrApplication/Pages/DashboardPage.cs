using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class DashboardPage
    {
        private By calendarLocator = By.XPath("//span[text()='Calendar']");
        private By patientOrClientLocator = By.XPath("//div[text()='Patient/Client']");
        private By patientLocator = By.XPath("//div[text()='Patients']");

        private IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnPatientOrClient()
        {
            driver.FindElement(patientOrClientLocator).Click();
        }

        public void ClickOnPatient()
        {
            driver.FindElement(patientLocator).Click();
        }

        public void WaitForPresenceOfCalendar()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Message = "Calendar text is not there";
            wait.Until(x => x.FindElement(calendarLocator));
        }

        public string GetTitle()
        {
            return driver.Title.Trim();
        }
    }
}
