using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriverConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //implicit wait = 30s

            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";

            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//frame[@name='login_page']")));


            driver.FindElement(By.Name("fldLoginUserId")).SendKeys("user1234");

            //click on continue
            driver.FindElement(By.XPath("//img[@alt='continue']")).Click();

            //comeout of frame
            driver.SwitchTo().DefaultContent();

            //driver.FindElement(By.Id("authUser")).SendKeys("admin");
            //driver.FindElement(By.Id("clearPass")).SendKeys("pass");


            //SelectElement select = new SelectElement(driver.FindElement(By.Name("languageChoice")));
            //select.SelectByText("Korean");

            ////driver.FindElement(By.ClassName("btn-login")).Click();  //not recommended
            //driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //driver.FindElement(By.Id("username")).Click();
            //driver.FindElement(By.XPath("//li[text()='Logout']")).Click();

            //admin
            //pass
            //English (Indian)
            //click login

        }
    }
}
