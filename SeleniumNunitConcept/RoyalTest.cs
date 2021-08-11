using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumNunitConcept
{
    class RoyalTest
    {
        [Test]
        public void webElementTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.google.com/";

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//a"));
            int linkCount = elements.Count;

            String href0 = elements[0].GetAttribute("href");

            //IWebElement ele0 = elements[0];
            //IWebElement ele0 = driver.FindElement(By.XPath("(//a)[1]"));

        }

        //Assignment 5
        [Test]
        public void CreateAccountTest()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.royalcaribbean.com/";

            if(driver.FindElements(By.XPath("//*[@class='email-capture__close']")).Count > 0)
            {
                driver.FindElement(By.XPath("//*[@class='email-capture__close']")).Click();
            }

            driver.FindElement(By.Id("rciHeaderSignIn")).Click();
            driver.FindElement(By.LinkText("Create an account")).Click();

            driver.FindElement(By.XPath("//input[@data-placeholder='First name/Given name']")).SendKeys("firstname");
            driver.FindElement(By.XPath("//input[@data-placeholder='Last name/Surname']")).SendKeys("lastname");

            //click month
            driver.FindElement(By.XPath("//span[text()='Month']")).Click();
            driver.FindElement(By.XPath("//span[text()=' April ']")).Click();

            driver.FindElement(By.XPath("//span[text()='Day']")).Click();
            driver.FindElement(By.XPath("//span[text()=' 30 ']")).Click();

            driver.FindElement(By.XPath("//input[@data-placeholder='Year']")).SendKeys("1990");

            driver.FindElement(By.XPath("//span[text()='Country/Region of residence']")).Click();
            driver.FindElement(By.XPath("//span[text()=' India ']")).Click();

            driver.FindElement(By.XPath("//input[@data-placeholder='Email address']")).SendKeys("email@gmail.com");


            driver.FindElement(By.XPath("//input[@aria-labelledby='agreements']/..")).Click();
        }
    }
}
