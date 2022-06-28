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

namespace Task50Point7
{
    public class EnterPage:WebPage
    {
        const string URL = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
        const string GET_NEW_USER_CSS = "button.btn.btn-default";
        IWebElement _newUserButton = null;
        public EnterPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(URL);
            _newUserButton = FindElementsBy("CSSselctor", GET_NEW_USER_CSS)[0];
        }
        public UserPage OpenUserPage()
        {
            _newUserButton?.Click();
            return new UserPage(_driver);
        }
    }
}
