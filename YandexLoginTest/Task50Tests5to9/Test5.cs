using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Task50Tests5and6
{
    [TestFixture]
    public class Test5
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver();
            driver = SingeltonWebPage.getDriver();
        }

        [TestCaseSource("Test5Data")]
        public void TestMultiSelect(string option1, string option2, string option3)
        {
            driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");
            SelectElement listOptions = new SelectElement(driver.FindElement(By.Name("States")));
            listOptions.SelectByValue(option1);
            listOptions.SelectByValue(option2);
            listOptions.SelectByValue(option3);

            List<string> exp_selected = new List<string> { option1, option2, option3 };
            List<string> act_selected = new List<string>();
            foreach (var option in listOptions.AllSelectedOptions)
            {
                act_selected.Add(option.Text);
            }
            Assert.AreEqual(exp_selected.ToArray(), act_selected.ToArray());
        }
        [TearDown]
        public void TestCleanUp()
        {
            driver.Quit();
        }

        private static IEnumerable Test5Data
        {
            get { return GetTest5Data(); }
        }
        private static IEnumerable GetTest5Data()
        {
            var doc1 = XDocument.Load(@"C:\Users\lenaschurko\source\repos\Task20\SeleniumTask20\YandexLoginTest\Task50Tests5to9\test5data.xml");
            return
                from vars1 in doc1.Descendants("vars1")
                let option1 = vars1.Attribute("option1").Value
                let option2 = vars1.Attribute("option2").Value
                let option3 = vars1.Attribute("option3").Value

                select new object[] { option1, option2, option3 };
        }
    }
}
