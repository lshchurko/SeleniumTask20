using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace YandexLoginTest
{
    [TestFixture]
    public class Task1to4LoginTest
    {
        WebDriver driver;
        MainPage mainPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestCaseSource("YandexLoginTestData")]
        public void LoginTest1(string mail, string password)
        {
            mainPage = new MainPage(driver);
            LoginPage loginPage = mainPage.OpenLoginPage();
            PasswordPage passwordPage = loginPage.OpenPasswordPage(mail);
            Thread.Sleep(2000); // explicit waiter
            AccountPage accountPage = passwordPage.OpenAccountPage(password);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = accountPage.AccountUsername();
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

            });
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
            var doc = XDocument.Load(@"C:\Users\lenaschurko\source\repos\Task20\SeleniumTask20\YandexLoginTest\testdata.xml");
            return
                from vars in doc.Descendants("vars")
                let mail = vars.Attribute("mail").Value
                let password = vars.Attribute("password").Value

                select new object[] { mail, password };
        }
    }
}
