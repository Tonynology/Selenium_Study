using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNunitConcept
{
    class SeleniumAdvance
    {
        [Test]
        public void MultipleTabsOrWindows()
        {
            IWebDriver driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = " ";
        }
        [Test]
        public void ValidCredentialTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //implicit wait = 30s

            driver.Url = "https://magento.com/";
            driver.FindElement(By.XPath("//span[text()='Sign in']")).Click();     
            driver.FindElement(By.Id("email")).SendKeys("balaji0017@gmail.com");
            driver.FindElement(By.Id("pass")).SendKeys("balaji0017@12345");
            //click to continue
            driver.FindElement(By.Name("send")).Click();

            //condition
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50)); //50 seconds
            wait.Until(x => x.FindElement(By.LinkText("Log Out")));  //polling time

            string actualValue = driver.Title;
            Console.WriteLine(actualValue);

            //verification
            Assert.AreEqual("Account Information", actualValue);

        }

    }
}
