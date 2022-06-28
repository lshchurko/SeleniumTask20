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

namespace Task50Point7;
public class Program
{
    static void Main(string[] arg)
    {
        WebDriver driver = SingeltonWebPage.getDriver();
        EnterPage enterpage = new EnterPage(driver);
        UserPage userpage = enterpage.OpenUserPage();
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
        wait.PollingInterval = TimeSpan.FromSeconds(10);
        const string USER_XPATH = "//*[@id='loading']/img";
        var element = wait.Until(condition =>
        {
            try
            {
                var elementToBeDisplayed = userpage.FindElementsBy("Xpath", USER_XPATH)[0];
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

        driver.Close();
    }
}
