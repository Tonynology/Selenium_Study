using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeleniumNunitConcept
{
    class DynamicTables
    {
        [Test]
            public void dynamicTables()
        {
            IWebDriver driver = new ChromeDriver(); //runtime polymorphism - method to be called is resolved during run time

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            SelectElement select = new SelectElement(driver.FindElement(By.Name("example_length")));
            select.SelectByText("50");

            int pageCount = driver.FindElements(By.XPath("//div[@class='dataTables_paginate paging_simple_numbers']/span/a")).Count;
            //Console.WriteLine(pageCount); //2

            int totalSalary = 0;

            for (int i = 1; i <= pageCount; i++)
            {
                int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;

                for (int j = 1; j <= rowCount; j++)
                {
                    string salary = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + j + "]/td[6]")).Text;
                    Console.WriteLine(salary);

                    //$162,700 -> 162,700 -> 162700
                    //Console.WriteLine(Regex.Match(salary, @"[0-9]+\.?[0-9,]*").Value.Replace(",", ""));
                    totalSalary += Int32.Parse(Regex.Match(salary, @"[0-9]+\.?[0-9,]*").Value.Replace(",", ""));
                }
                driver.FindElement(By.XPath("//a[text()='Next']")).Click();
            }
            //How to show with comma?
            Console.WriteLine("$" + totalSalary);
        }
    }
}
