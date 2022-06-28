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

namespace Task50Point7
{
    public sealed class SingeltonWebPage
    {
        private static  WebDriver _driver=null;
        private SingeltonWebPage()
        {
            _driver = new ChromeDriver();
        }
        public static WebDriver getDriver()
        {
            if (_driver == null)
             {
                _driver= new ChromeDriver();
             }
            return _driver;
        }
    }
}
