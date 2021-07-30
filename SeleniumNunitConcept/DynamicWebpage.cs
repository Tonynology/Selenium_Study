using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNunitConcept
{
    class DynamicWebpage
    {
        //[Test]
        //public void pepperfryTest()
        //{
        //    IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    driver.Url = "https://www.pepperfry.com/";
        //    //Console.WriteLine(driver.FindElements(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Count);

        //    if (driver.FindElements(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Count > 0)
        //    {
        //        driver.FindElement(By.XPath("//div[@id='regPopUp']/a[@class='popup-close']")).Click();
        //    }

        //    driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("bedsheets");
        //    driver.FindElement(By.XPath("//input[@id='searchButton']")).Click();

        //    driver.FindElement(By.XPath("//label[text()='Sleep Dove']")).Click();

        //    //Doing a MouseHover  
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(x => x.FindElement(By.XPath("//div[@unbxdattr='product']")));

        //    //Clicking the SubMenu on MouseHover   
        //    driver.FindElement(By.XPath("//div[contains(@class,'clip-add-to-cart-btn-wrap')]/a[text()='Add To Cart']")).Click();

        //}

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
