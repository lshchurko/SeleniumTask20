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
    public class UserPage:WebPage
    {
        //const string GET_LOADING_CSS = "#loading";
        const string GET_USER_CSS = "#loading";
        IWebElement _newUser = null;
        public UserPage(IWebDriver driver) : base(driver)
        {
            _newUser = FindElementsBy("CSSselctor", GET_USER_CSS)[0];
        }
        public IWebElement NewUser()
        {
            return _newUser;
        }
    }
}
