using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriverConcept
{
    class Program_assignment_1_2
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //implicit wait = 30s

            ////assignment_1_task_1
            //driver.Url = "https://www.medibuddy.in/";
            //driver.FindElement(By.Id("wzrk-cancel")).Click();
            //driver.FindElement(By.XPath("//a[@ng-click='userSignin(true)']")).Click();
            //driver.FindElement(By.Id("mobile")).SendKeys("123-456-7890");
            //driver.FindElement(By.Id("name")).SendKeys("admin");
            //driver.FindElement(By.Id("email")).SendKeys("admin@gmail.com");
            //driver.FindElement(By.XPath("//button[@type='submit']")).Click();


            ////assignment_1_task_2
            //driver.Url = "https://www.gotomeeting.com/en-in";
            //driver.FindElement(By.LinkText("Start for Free")).Click();
            //driver.FindElement(By.Id("first-name")).SendKeys("admin_firstName");
            //driver.FindElement(By.Id("last-name")).SendKeys("admin_lastName");
            //driver.FindElement(By.Id("login__email")).SendKeys("admin@gmail.com");
            //driver.FindElement(By.Id("contact-number")).SendKeys("123-456-7890");
            //SelectElement select = new SelectElement(driver.FindElement(By.Name("JobTitle")));
            //select.SelectByText("Help Desk");
            //driver.FindElement(By.Id("login__password")).SendKeys("pass");
            //driver.FindElement(By.XPath("//input[@value='10 - 99']")).Click();
            //driver.FindElement(By.XPath("//button[text()='Sign Up']")).Click();


            //assignment_2_task_2
            driver.Url = "https://demo.openemr.io/b/openemr/interface/login/login.php?site=default";
            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("pass");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            driver.FindElement(By.XPath("//div[text()='Patient/Client']")).Click();
            driver.FindElement(By.XPath("//div[text()='Patients']")).Click();

            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='fin']")));
            driver.FindElement(By.XPath("//button[@id='create_patient_btn1']")).Click();

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));

            driver.FindElement(By.XPath("//input[@id='form_fname']")).SendKeys("taehoon");
            driver.FindElement(By.XPath("//input[@id='form_lname']")).SendKeys("moon");
            driver.FindElement(By.XPath("//input[@id='form_DOB']")).SendKeys("2021-07-20");

            SelectElement select = new SelectElement(driver.FindElement(By.Name("form_sex")));
            select.SelectByText("Male");

            driver.FindElement(By.Id("create")).Click();
            driver.SwitchTo().DefaultContent(); //what is default Content?
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='modalframe']")));

            driver.FindElement(By.XPath("//input[@type='button']")).Click();

            //*Print the text from alert box.

            driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();

            //*Get the added patient name and validate the added name.  ERROR ON HERE
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@name='pat']")));

            string title = driver.Title;
            Console.WriteLine(title);

            //assignment_3
            driver.Url = "https://www.online.citibank.co.in/";

            if (driver.FindElements(By.XPath("//img[@class='appClose']")).Count > 0)
            {
                driver.FindElement(By.XPath("//img[@class='appClose']")).Click();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.FindElement(By.XPath("//img[@title='LOGIN NOW']")).Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.FindElement(By.XPath("//div[@class='cl fl ls_login']")).Click();

            driver.SwitchTo().Window(driver.WindowHandles[2]);
            driver.FindElement(By.XPath("//a[text()='Close this window']")).Click();

            driver.Quit();

        }
    }
}
