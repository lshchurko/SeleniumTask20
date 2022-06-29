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
using System.IO;


namespace Task70
{
    [TestFixture]
    public class Tests
    {
        WebDriver driver;
        MainPage mainPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCaseSource("YandexLoginTestData")]
        public void LoginTest1(string mail, string password)
        {
            mainPage = new MainPage(driver);
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //ss.SaveAsFile(@"D:\test1.png", ScreenshotImageFormat.Png);
            ss.SaveAsFile(@"./Screenshot/test1.png", ScreenshotImageFormat.Png);
            LoginPage loginPage = mainPage.OpenLoginPage();
            PasswordPage passwordPage = loginPage.OpenPasswordPage(mail);
            Thread.Sleep(2000); // explicit waiter
            AccountPage accountPage = passwordPage.OpenAccountPage(password);
            var element = accountPage.Waiter(driver, accountPage.AccountUsername());
            Assert.IsTrue(element);
        }
        [TearDown]
        public void TestCleanUp()
        {
            driver.Quit();
        }

        private static IEnumerable YandexLoginTestData
        {
            get { return GetYandexLoginTestData(); }
        }
        private static IEnumerable GetYandexLoginTestData()
        {
            string currentDirectory = Path.GetFullPath("Task70");
           var doc = XDocument.Load(@"currentDirectory\testdata.xml");
           //var doc = XDocument.Load(@"C:\Users\lenaschurko\source\repos\Task20\SeleniumTask20\Task70\testdata.xml");
            return
                from vars in doc.Descendants("vars")
                let mail = vars.Attribute("mail").Value
                let password = vars.Attribute("password").Value

                select new object[] { mail, password };
        }
    }
}
