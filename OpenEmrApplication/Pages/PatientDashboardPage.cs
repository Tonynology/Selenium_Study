using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEmrApplication.Pages
{
    class PatientDashboardPage
    {
        private By patFrameLocator = By.XPath("//iframe[contains(@src,'new.php')]");
        private IWebDriver driver;

        public PatientDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchToPatFrame(string frame)
        {
            driver.SwitchTo().Frame(driver.FindElement(patFrameLocator));
        }
    }
}
