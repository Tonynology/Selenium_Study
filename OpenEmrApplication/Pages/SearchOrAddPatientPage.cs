using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class SearchOrAddPatientPage
    {
        private By firstnameLocator = By.Id("form_fname");
        private By lastnameLocator = By.Id("form_lname");
        private By calenderLocator = By.Id("form_DOB");
        private By sexLocator = By.Id("form_sex");
        private By createLocator = By.Id("create");
        private By confirmLocator = By.XPath("//input[@value='Confirm Create New Patient']");
        private By closePopUpLocator = By.XPath("//div[@class='closeDlgIframe']");


        private IWebDriver driver;
        public SearchOrAddPatientPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToPatFrame(string frame)
        {
            driver.SwitchTo().Frame(frame);
        }

        public void sendPatientFName(string fname)
        {
            driver.FindElement(firstnameLocator).SendKeys(fname);
        }
        public void sendPatientLName(string lname)
        {
            driver.FindElement(lastnameLocator).SendKeys(lname);
        }
        public void sendCalender(string date)
        {
            driver.FindElement(calenderLocator).SendKeys(date);
        }
        public void selectSex(string sex)
        {
            SelectElement selectGender = new SelectElement(driver.FindElement(sexLocator));
            selectGender.SelectByText(sex);
        }
        public void ClickOnCreate()
        {
            driver.FindElement(createLocator).Click();
        }
        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }
        public void SwitchToModalFrame(string modalFrame)
        {
            driver.SwitchTo().Frame(modalFrame);
        }
        public void ClickOnConfirm()
        {
            driver.FindElement(confirmLocator).Click();
        }

        public string WaitForAlertGetTextAndAccept()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));//ignore no alert exception

            string actualValueOfAlert = wait.Until(x => x.SwitchTo().Alert()).Text;
            Console.WriteLine(actualValueOfAlert);

            wait.Until(x => x.SwitchTo().Alert()).Accept();

            return actualValueOfAlert;
        }

        public void CheckAndClosePopUp()
        {
            if (driver.FindElements(closePopUpLocator).Count > 0) // check element present or not
            {
                driver.FindElement(closePopUpLocator).Click();
            }
        }
            
}
}
