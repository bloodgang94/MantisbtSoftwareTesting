using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Mantisbt.PageObject.Admin
{
    public class ManageProjectEditPage : WebPage
    {
        public ManageProjectEditPage(AppManager app) : base(app) { }

        public ManageProjectPage DeleteProject()
        {
           for(int i=0; i < 2; i++)
               _app.Browser.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
           return new ManageProjectPage(_app);
        }
    }
}
