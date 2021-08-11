using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumNunitConcept
{
    class OpenEMRtest
    {
        //Assignment 3
        [Test]
        public void AddPatientTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("pass");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            driver.FindElement(By.XPath("//div[text()='Patient/Client']")).Click();
            driver.FindElement(By.XPath("//div[text()='Patients']")).Click();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='fin']")));
            // can be used like
            // driver.SwitchTo().Frame("fin");
            driver.FindElement(By.XPath("//button[@id='create_patient_btn1']")).Click();

            driver.SwitchTo().DefaultContent(); // Go to the main HTML.
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));
            driver.SwitchTo().Frame("pat");

            driver.FindElement(By.XPath("//input[@id='form_fname']")).SendKeys("taehoon");
            driver.FindElement(By.XPath("//input[@id='form_lname']")).SendKeys("moon");
            driver.FindElement(By.XPath("//input[@id='form_DOB']")).SendKeys("2021-07-20");

            SelectElement select = new SelectElement(driver.FindElement(By.Name("form_sex")));
            select.SelectByText("Male");

            driver.FindElement(By.Id("create")).Click();
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame("modalframe");
            driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            driver.SwitchTo().DefaultContent();

            // explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            //ignores all the exception
            wait.Until(x => x.SwitchTo().Alert());

            //// *** Fluent wait ***
            //DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            //wait.Timeout = TimeSpan.FromSeconds(50);
            //wait.PollingInterval = TimeSpan.FromSeconds(5);
            //wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));    //ignore no alert exception

            //print Alert box messages.
            string actualValueOfAlert = driver.SwitchTo().Alert().Text;
            Console.WriteLine(actualValueOfAlert);

            driver.SwitchTo().Alert().Accept(); //close Alert box.

            driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();


            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));

            string actualValueOfPatient= driver.FindElement(By.XPath("//h2[contains(text(), 'Medical')]")).Text;

            //Verification
            Assert.IsTrue(actualValueOfAlert.Contains("Assessment: Tobacco"));

            Assert.AreEqual("Medical Record Dashboard - Taehoon Moon", actualValueOfPatient);
        }
    }
}
