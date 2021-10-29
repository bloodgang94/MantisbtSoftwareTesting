using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantisbt.PageObject.Menu
{
    public class Menu : WebPage
    {
        public IWebElement Manage => _app.Browser.FindElement(By.XPath("//a[contains(@href, 'manage_proj_page')]"));
        public Menu(AppManager app) : base(app) { }

        public void CreateNewProject()
        {
            _app.Browser.FindElement(By.XPath("//button[contains(text(), 'новый проект')]")).Click();
        }
    }
}
