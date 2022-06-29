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

namespace Task70
{
    public class AccountPage:WebPage
    {
        const string USERNAME_CLASSNAME = "username__first-letter";
        const string EXIT_BUTTON = "//*[text()='Выйти']";
        IWebElement _username = null;

        public AccountPage(IWebDriver driver) : base(driver)
        {
            _username = FindElementsBy("ClassName", USERNAME_CLASSNAME)[0];
        }
        public IWebElement AccountUsername()
        {
            return _username;
        }
        public bool Waiter(IWebDriver driver, IWebElement elementWeb )
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = elementWeb;
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
            return element;
        }
        public MainPage Logout()
        {
            _username.Click();
            var _exit = FindElementsBy("Xpath", EXIT_BUTTON)[0];
            _exit.Click();
            return new MainPage(_driver);
        }

    }
}
