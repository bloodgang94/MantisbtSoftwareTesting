using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantisbt.PageObject
{
    public class MyPage : WebPage
    {
        public IWebElement Profile => _app.Browser.FindElement(By.XPath("//div[@id='breadcrumbs']//a[contains(@href, 'account_page.php')]"));

        public MyPage(AppManager app): base(app) { }

       
    }
}
