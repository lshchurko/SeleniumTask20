using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexLoginTest
{
    public abstract class Page
    {
            protected IWebDriver _driver;

            public Page(IWebDriver driver)
            {
                _driver = driver;
            }
            public List<IWebElement> FindElementsBy(string bytype, string locator)
            {
                List<IWebElement> element = null;
            if (bytype == "Xpath")
            {
                element = _driver.FindElements(By.XPath(locator)).ToList();
            }
            else if (bytype == "CSSselctor")
            {
                element = _driver.FindElements(By.CssSelector(locator)).ToList();
            }
            else if (bytype == "Name")
            {
                element = _driver.FindElements(By.Name(locator)).ToList();
            }
            else if (bytype == "ClassName")
            {
                element = _driver.FindElements(By.ClassName(locator)).ToList();
            }
            else if (bytype == "TagName")
            {
                element = _driver.FindElements(By.TagName(locator)).ToList();
            }
            return element;
            }
     }
        
}
