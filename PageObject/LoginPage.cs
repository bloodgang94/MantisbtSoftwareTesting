using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantisbt.PageObject
{
    public class LoginPage : WebPage
    {
        public IWebElement UserName => _app.Browser.FindElement(By.Id("username"));
        public IWebElement Password => _app.Browser.FindElement(By.Id("password"));
        public IWebElement Enter => _app.Browser.FindElement(By.XPath("//input[@value='Вход']"));
        public LoginPage(AppManager app) : base(app) { }

        public void Authorization(string userName, string password)
        {
            UserName.SendKeys(userName);
            Enter.Click();
            Password.SendKeys(password);
            Enter.Click();
        }
    }
}
