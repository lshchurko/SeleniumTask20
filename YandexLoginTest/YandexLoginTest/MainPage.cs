using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YandexLoginTest
{
    public class MainPage:Page
    {
        const string URL = "https://yandex.ru/";
        const string ENTER_BUTTON_CSS = "div.desk-notif-card__login-new-item-title";
        IWebElement _enterButton = null;

        public MainPage(IWebDriver driver):base (driver)
        {
            driver.Navigate().GoToUrl(URL);
            _enterButton = FindElementsBy("CSSselctor", ENTER_BUTTON_CSS)[0];
        }
        public LoginPage OpenLoginPage()
        {
            _enterButton?.Click();
            return new LoginPage(_driver);
        }
    }
}
