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

namespace Task50Point8;
public class Program
{
    static void Main(string[] arg)
    {
        WebDriver driver;
        driver = new ChromeDriver();
        WebPage webpage = new WebPage(driver);
        webpage.downloadClick();
        webpage.reload();
        driver.Close();
    }
}
