using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task50Point9;
public class Program
{
   static void Main(string[] arg)
    {
        WebDriver driver;
        driver = new ChromeDriver();
        WebTablePage page = new WebTablePage(driver);
        page.DropDownSelectTable();
        Thread.Sleep(2000);
        int x = 36;
        int y = 205500;
        page.NextPageTable(x,y);
        driver.Close();
    }
}


