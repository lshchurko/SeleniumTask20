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
    public class Task6Test
    {
        WebDriver driver1;

        [SetUp]
        public void Setup()
        {
            driver1 = new ChromeDriver();
        }

        [Test]
        public void TestConfirmAccept()
        {
            driver1.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            IWebElement button = driver1.FindElement(By.CssSelector("button.btn.btn-default.btn-lg"));
            button.Click();

            try
            {
                IAlert alert = driver1.SwitchTo().Alert();
                alert.Accept();
                IWebElement message =driver1.FindElement(By.Id("confirm-demo"));
                Assert.AreEqual("You pressed OK!", message.Text);
            }
            catch (NoAlertPresentException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        [Test]
        public void TestConfirmDismiss()
        {
            driver1.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            IWebElement button = driver1.FindElement(By.CssSelector("button.btn.btn-default.btn-lg"));
            button.Click();

            try
            {
                IAlert alert = driver1.SwitchTo().Alert();
                alert.Dismiss();
                IWebElement message = driver1.FindElement(By.Id("confirm-demo"));
                Assert.AreEqual("You pressed Cancel!", message.Text);
            }
            catch (NoAlertPresentException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        [Test]
        public void TestSimpleAlert()
        {
            driver1.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
            IWebElement button = driver1.FindElement(By.CssSelector("button.btn.btn-default"));
            button.Click();
            try
            {
                IAlert alert=driver1.SwitchTo().Alert();
                string textOnAlert = alert.Text;
                alert.Accept();
                Assert.AreEqual("I am an alert box!",textOnAlert);
            }
            catch(NoAlertPresentException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        [TearDown]
        public void TestCleanUp()
        {
            driver1.Quit();
        }
    }
}
