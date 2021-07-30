using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumWebDriverConcept
{
    class Program1
    {
        static void Main1(string[] args)
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

            driver.Quit();


            ////registration form
            //IWebElement signInElement = driver.FindElement(By.Id("gnav_557"));
            //signInElement.Click();

            //IWebElement createaccountelement = driver.FindElement(By.Id("register"));
            //createaccountelement.Click();

            //IWebElement firstnameelement = driver.FindElement(By.Id("firstname"));
            //firstnameelement.SendKeys("taehoon");

            //IWebElement lastnameelement = driver.FindElement(By.Id("lastname"));
            //lastnameelement.SendKeys("moon");

            //IWebElement signupemailelement = driver.FindElement(By.Id("email_address"));
            //signupemailelement.SendKeys("tonycontinue@gmail.com");

            //IWebElement companynameelement = driver.FindElement(By.Id("self_defined_company"));
            //companynameelement.SendKeys("soller");

            //IWebElement signuppasswordelement = driver.FindElement(By.Id("password"));
            //signuppasswordelement.SendKeys("123456");

            //IWebElement signuppasswordconfirmelement = driver.FindElement(By.Id("password-confirmation"));
            //signuppasswordconfirmelement.SendKeys("123456");

            //driver.Quit();
        }
    }
}
