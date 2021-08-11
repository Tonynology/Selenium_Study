using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNunitConcept
{
    class task1_mouseHover
    {
        [Test]
        public void MouseHover()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://account.magento.com/customer/account/login";

            IWebElement element = driver.FindElement(By.XPath("//a[normalize-space()='Sign in with Adobe ID']"));

            string beforeRgbColor = element.GetCssValue("background-color");
            Console.WriteLine(beforeRgbColor);

            //mouse hover build & perform
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();

            string rgbColor = element.GetCssValue("background-color");
            Console.WriteLine(rgbColor);

            //Assert.AreEqual("rgba(75, 75, 75, 1)", rgbColor);

            //5. Click on Sign in with adobe
            driver.FindElement(By.XPath("//a[normalize-space()='Sign in with Adobe ID']")).Click();

            //6. Click on Continue with Apple
            driver.FindElement(By.XPath("//a[@class='spectrum-ActionButton SocialButton SocialButton--apple']")).Click();

            //7. get the link
            string text = driver.FindElement(By.XPath("//input[@id='account_name_text_field']")).Text;
            Console.WriteLine(text);

            //8. Get the link (href) detail for "Forgotten your Apple ID or password?"
            string href = driver.FindElement(By.XPath("//a[@id='iforgot-link']")).GetAttribute("href");
            Console.WriteLine(href);

            //9. Click on "Forgotten your Apple ID or password?" and Gotonewtab
            driver.FindElement(By.XPath("//a[@id='iforgot-link']")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //10. get the current url and title
            string title = driver.Title;
            string currUrl = driver.Url;
            Console.WriteLine(title, currUrl);

            driver.Quit();
        }
    }
}
