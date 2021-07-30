using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNunitConcept
{
    class AirlineTest
    {
        [Test]
        public void airlineTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.malaysiaairlines.com/in/en.html";

            driver.FindElement(By.XPath("//input[@aria-label='fromLocation selectize input']")).Click();
            driver.FindElement(By.XPath("//div[@data-group='With Malaysia Airlines']/div[@data-value='MAA']")).Click();
            driver.FindElement(By.XPath("//input[@aria-label='toLocation selectize input']")).Click();
            driver.FindElement(By.XPath("//div[@data-group='online']/div[@data-value='AKL']")).Click();

            driver.FindElement(By.XPath("//div[contains(@class, 'ui-datepicker-group-first')]/table[1]/tbody[1]/tr[5]/td[5]/a[1]")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'ui-datepicker-group-last')]/table[1]/tbody[1]/tr[4]/td[4]/a[1]")).Click();

            driver.FindElement(By.XPath("//div[@class='total-passengers']")).Click();
            driver.FindElement(By.XPath("//div[@class='passenger-details-selected']/div[contains(@class, 'adult-cat')]//button[@aria-label='Increment Adult']")).Click();
            driver.FindElement(By.XPath("//div[@class='passenger-details-selected']/div[contains(@class, 'child-cat')]//button[@aria-label='Increment Children']")).Click();
            driver.FindElement(By.XPath("//div[@class='passenger-details-selected']/div[contains(@class, 'child-cat')]//button[@aria-label='Increment Children']")).Click();
            driver.FindElement(By.XPath("//div[@class='passenger-details-selected']/div[contains(@class, 'child-cat')]//button[@aria-label='Increment Children']")).Click();

            driver.FindElement(By.XPath("//div[contains(@class, 'selectize-control cabin-class')]")).Click();
            driver.FindElement(By.XPath("//div[text()='Business']")).Click();

            //driver.Quit();
        }

    }
}
