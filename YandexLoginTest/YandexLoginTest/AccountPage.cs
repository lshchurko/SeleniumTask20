using OpenQA.Selenium;

namespace YandexLoginTest
{
    public class AccountPage:Page
    {
        const string USERNAME_CLASSNAME = "username__first-letter";
        IWebElement _username = null;

        public AccountPage(IWebDriver driver) : base(driver)
        {
            _username = FindElementsBy("ClassName", USERNAME_CLASSNAME)[0];
        }
        public IWebElement AccountUsername()
        {
            return _username;
        }
    }
}
