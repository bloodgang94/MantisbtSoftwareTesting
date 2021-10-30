using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.Models;
using OpenQA.Selenium;

namespace Mantisbt.PageObject
{
    public class VerifyPage : WebPage
    {
        public VerifyPage(AppManager app): base(app) { }

        public void Confirm(string url, Account account)
        {
            _app.Browser.Navigate().GoToUrl(url);
            _app.Browser.FindElement(By.Id("realname")).SendKeys(account.Login);
            _app.Browser.FindElement(By.Id("password")).SendKeys(account.Password);
            _app.Browser.FindElement(By.Id("password-confirm")).SendKeys(account.Password);
            _app.Browser.FindElement(By.TagName("button")).Click();
        }
    }
}
