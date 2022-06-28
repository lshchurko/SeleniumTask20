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
    public class Row
    {
        //protected int RowId;
        public string Name;
        public string Position;
        public string Office;
        public string Age;
        public string StartDate;
        public string Salary;
        private protected IWebDriver driver;
        //protected string xpth = "//tr"+[rowId]+"/td";
        protected string xpth = "";
        public int rowId;
        //IWebElement rw;

        public Row (IWebDriver driver, int rowId)
        {
            this.driver = driver;
            this.rowId = rowId;
            string xpth = "//tr["+rowId+"]/td";
            Name = driver.FindElements(By.XPath(xpth))[0].Text;
            Position = driver.FindElements(By.XPath(xpth))[1].Text;
            Office = driver.FindElements(By.XPath(xpth))[2].Text;
            Age = driver.FindElements(By.XPath(xpth))[3].Text;
            StartDate = driver.FindElements(By.XPath(xpth))[4].Text;
            Salary = driver.FindElements(By.XPath(xpth))[5].Text;
          //  rw = driver.FindElements(By.XPath("//tr"))[rowId];
        }
       
        string str = "";
        public string SortedRow(int x, int y)
        {
            if (Convert.ToInt32(Age)> x && Convert.ToInt32(Salary.Trim(new char[] {'$','y','/' }).Replace(@",", "")) <= y)
            {
                str = "Name " + Name + " , Position" + Position + " ,Office"+ Office;
            }
            return str;
        }
      
    }
}
