using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace YandexLoginTest
{
    public class YandexLogTest
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void LoginTest1()
        {
            driver.Navigate().GoToUrl("https://yandex.ru/");
            Thread.Sleep(2000);
            IWebElement enterButton = driver.FindElement(By.CssSelector("body > div.body__wrapper > div.desk-notif__wrapper > div > div.desk-notif-card.desk-notif-card_type_login.desk-notif-card_bg_default.desk-notif-card_login-new_yes.desk-notif-card_theme_default.i-bem.desk-notif-card_js_inited > div > div > a.home-link.desk-notif-card__login-new-item.desk-notif-card__login-new-item_enter.home-link_black_yes.home-link_hover_inherit > div.desk-notif-card__login-new-item-title"));
            Thread.Sleep(2000);
            enterButton.Click();
            IWebElement mailInput = driver.FindElement(By.XPath("//*[@id='passp-field-login']"));
            mailInput.SendKeys("lenaschurko@coherentsolutions.com");
            mailInput.Submit();
            Thread.Sleep(2000);
            IWebElement passInput = driver.FindElement(By.XPath("//*[@id='passp-field-passwd']"));
            Thread.Sleep(2000);
            passInput.SendKeys("09qr!12");
            passInput.Submit();
            Thread.Sleep(2000);
            //IWebElement notNowButton = driver.FindElement(By.CssSelector("#root > div > div.passp-page > div.passp-flex-wrapper > div > div > div.passp-auth-content > div.passp-route-forward > div > div > form > div:nth-child(3) > button"));
           // notNowButton.Click();
            Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div[1]/div[1]/div/a[1]/span")).Displayed);
            driver.Close();
        }
    }
}