using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.Models;
using OpenQA.Selenium;

namespace Mantisbt.PageObject
{
    public class SignUpPage : WebPage
    {
        public SignUpPage(AppManager app): base(app) { }

        public void RegisterNow(Account account)
        {
            _app.LoginPage.UserName.SendKeys(account.Login);
            _app.Browser.FindElement(By.Id("email-field")).SendKeys(account.Email);
            _app.LoginPage.Enter.Click();
        }
    }
}
