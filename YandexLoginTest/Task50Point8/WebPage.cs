using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task50Point8
{
    public class WebPage
    {
        private static protected String URL = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
        private static protected By DOWNLOAD_BUTTON = By.CssSelector("#cricle-btn");
        private static protected By PERCENT_CIRCLE = By.ClassName("percenttext");
        private protected WebDriver driver;
        public WebPage(WebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(URL);
        }
        public WebPage downloadClick()
        {
            driver.FindElement(DOWNLOAD_BUTTON)?.Click();
            return this;
        }
        public WebPage reload()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.PollingInterval = TimeSpan.FromSeconds(3);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(PERCENT_CIRCLE);
                    int percent = Convert.ToInt32(elementToBeDisplayed.Text.TrimEnd('%'));
                    if (percent >= 50)
                    {
                        return elementToBeDisplayed.Displayed;
                    }
                    else
                    {
                       return false;
                    }
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
           driver.Navigate().Refresh();
           return this;

        }
    }
}
