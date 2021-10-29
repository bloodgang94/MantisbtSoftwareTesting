using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantisbt.PageObject.Menu
{
    public class SideBar : WebPage
    {
        public IWebElement Manage => _app.Browser.FindElement(By.XPath("//a[contains(@href, 'manage_overview_page')]"));
        public SideBar(AppManager app) : base(app) { }

    }
}
