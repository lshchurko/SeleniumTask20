using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace Task50Point9
{
    public class WebTablePage
    {
        private static protected String URL = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
        private static protected By DROP_DOWN = By.Name("example_length");
        private static protected string DROPDOWN_OPTION = "10";
        private protected IWebDriver driver;
        //private static protected By PAGE_BUTTON = By.CssSelector("a.paginate_button[data-dt-idx='3']");
        private static protected By PAGE_BUTTON = By.CssSelector("a.paginate_button");
       // protected string xpth = "";
        //public int pageId;
        public WebTablePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(URL);
           // this.pageId = pageId;
           // string xpth = "//a[contains(@data-dt-idx,'"+pageId+"')]";

        }
         public WebTablePage DropDownSelect()
        {
            SelectElement make = new SelectElement(driver.FindElement(DROP_DOWN));
            make.SelectByText(DROPDOWN_OPTION);
            return this;
        }

        public Table DropDownSelectTable()
        {
            SelectElement make = new SelectElement(driver.FindElement(DROP_DOWN));
            make.SelectByText(DROPDOWN_OPTION);
            return new Table(driver);
        }
        public void NextPageTable(int x, int y)

        {
            var webPages = driver.FindElements(PAGE_BUTTON).Count;
            for (int pId = 1; pId < webPages; pId++ )
            {
                Thread.Sleep(1000);
                var button = driver.FindElement(By.XPath("//a[contains(@data-dt-idx,'" + pId + "')]"));
                button.Click();
                var nextTable = new Table(driver);
                nextTable.CList(x,y);
            }
      

        }
    }
}
