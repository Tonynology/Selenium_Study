using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumNunitConcept
{
    class DynamicWebpage
    {
        //Assigment 6
        [Test]
        public void pepperfryTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "https://www.pepperfry.com/";
            //Console.WriteLine(driver.FindElements(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Count);

            if (driver.FindElements(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Count > 0)
            {
                driver.FindElement(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Click();
            }

            driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("bedsheets");
            driver.FindElement(By.XPath("//input[@id='searchButton']")).Click();

            driver.FindElement(By.XPath("//label[text()='Sleep Dove']")).Click();

            string ele = driver.FindElement(By.XPath("//label[text()='Sleep Dove']")).GetAttribute("for");
            //string eleProp = driver.FindElement(By.XPath("//label[text()='Sleep Dove']")).GetProperty("checked");
            Console.WriteLine(ele);
            //Console.WriteLine(eleProp);


            Console.WriteLine(driver.Title);
            Thread.Sleep(5000);

            driver.SwitchTo().Frame("webklipper-publisher-widget-container-notification-frame");
            driver.FindElement(By.Id("webklipper-publisher-widget-container-notification-close-div")).Click();
            driver.SwitchTo().DefaultContent();

            //mouse hovering. don't move mouse and keyboard during run time...
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.XPath("(//div[@unbxdattr='product'])[1]"))).Build().Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//a[text()='Add To Cart'])[1]")).Click();


            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[text()='Proceed to pay securely ']")).Click();
            driver.FindElement(By.LinkText("PLACE ORDER")).Click();

            driver.FindElement(By.Id("name")).SendKeys("John");
            driver.FindElement(By.Id("postcode")).SendKeys("400059");
            driver.FindElement(By.Id("street")).SendKeys("MetroPark");
            driver.FindElement(By.Id("city")).SendKeys("Mumbai");

            driver.FindElement(By.Id("btn_guestform_save_shipping")).Click();

            string actualErrorMsg = driver.FindElement(By.XPath("//div[contains(text(),'Enter valid 10 digit number')]")).Text;
            Assert.AreEqual("Enter valid 10 digit number", actualErrorMsg);

            driver.Quit();

        }

        [Test]
        public void phptravelsTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Url = "https://phptravels.net/home";


        }
    }
}
