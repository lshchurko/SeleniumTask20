using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YandexLoginTest
{
    public class PasswordPage:Page
    {
        const string PASS_INPUT_XPATH = "//*[@id='passp-field-passwd']";
        IWebElement _passInput = null;

        public PasswordPage(IWebDriver driver) : base(driver)
        {
            _passInput = FindElementsBy("Xpath", PASS_INPUT_XPATH)[0];
        }

        public AccountPage OpenAccountPage(string password)
        {
            _passInput.SendKeys(password);
            _passInput.Submit();
            return new AccountPage(_driver);
        }
    }
}
