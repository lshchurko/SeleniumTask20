using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task70
{
    public class LoginPage:WebPage
    {
        const string MAIL_INPUT_XPATH = "//*[@id='passp-field-login']";
        IWebElement _mailInput = null;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _mailInput = FindElementsBy("Xpath", MAIL_INPUT_XPATH)[0];
        }

        public PasswordPage OpenPasswordPage(string mail)
        {
            _mailInput.SendKeys(mail);
            _mailInput.Submit();
            return new PasswordPage(_driver);
        }

    }
}
