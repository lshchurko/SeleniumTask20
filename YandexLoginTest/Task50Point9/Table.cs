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
    public class Table
    {
        private protected IWebDriver driver;
        //protected int rowID;
        List<Row> _rows;

        List<Row> Rows
        {
            get { return _rows; }
        }
        public Table(IWebDriver driver)
        {
            this.driver = driver;
           // _rows = driver.FindElements(By.XPath("//tr")).ToList();
        }

    
        public void CreateList()
        {
            var result1 = driver.FindElements(By.XPath("//tr")).ToList();//Rows;//Rows.Where(a => a.Age == "66").ToList();
            // result1.ForEach(x => Console.WriteLine(x.Name + ' ' + x.Position + ' ' + x.Office));
            //var result1 = 
            Console.WriteLine(driver.FindElements(By.XPath("//tr")).Count().ToString());
            result1.ForEach(x => Console.WriteLine(x.Text));
        }

        public void CList(int x, int y)
        {
            for (int rowId = 1; rowId < driver.FindElements(By.XPath("//tr")).Count(); rowId ++)
            {
                Row bbb = new Row(driver,rowId);
                //Console.WriteLine(bbb.Age.ToString());
                bbb.SortedRow(x,y);
                Console.WriteLine(bbb.SortedRow(x,y).ToString());
            }
            //return aaa;
        }

    }
}

