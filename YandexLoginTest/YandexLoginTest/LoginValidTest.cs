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

//OLD version
namespace YandexLoginTest
{
    [TestFixture]
    public class YandexLogTest
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TestCaseSource("YandexLoginTestData")]
        public void LoginTest1(string mail, string password)
        {
            driver.Navigate().GoToUrl("https://yandex.ru/");
            IWebElement enterButton = driver.FindElement(By.CssSelector("body > div.body__wrapper > div.desk-notif__wrapper > div > div.desk-notif-card.desk-notif-card_type_login.desk-notif-card_bg_default.desk-notif-card_login-new_yes.desk-notif-card_theme_default.i-bem.desk-notif-card_js_inited > div > div > a.home-link.desk-notif-card__login-new-item.desk-notif-card__login-new-item_enter.home-link_black_yes.home-link_hover_inherit > div.desk-notif-card__login-new-item-title"));
            Thread.Sleep(2000); // explicit waiter
            enterButton.Click();
            IWebElement mailInput = driver.FindElement(By.XPath("//*[@id='passp-field-login']"));
            mailInput.SendKeys(mail);
            mailInput.Submit();
           Thread.Sleep(2000); // explicit waiter
            IWebElement passInput = driver.FindElement(By.XPath("//*[@id='passp-field-passwd']"));
            Thread.Sleep(2000); // explicit waiter
            passInput.SendKeys(password);
            passInput.Submit();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            var element = wait.Until(condition =>
                {
                    try
                    {
                        var elementToBeDisplayed = driver.FindElement(By.ClassName("username__first-letter"));
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
            //IWebElement notNowButton = driver.FindElement(By.CssSelector("#root > div > div.passp-page > div.passp-flex-wrapper > div > div > div.passp-auth-content > div.passp-route-forward > div > div > form > div:nth-child(3) > button"));
            // notNowButton.Click();
            Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div[1]/div[1]/div/a[1]/span")).Displayed);
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
