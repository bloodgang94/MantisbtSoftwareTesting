using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.Models;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mantisbt.PageObject.Admin
{
    public class ManageProjectCreatePage : WebPage
    {
        public ManageProjectCreatePage(AppManager app) : base(app) { }

        public ManageProjectPage AddNewProject(Project project)
        {
            _app.Browser.FindElement(By.Id("project-name")).SendKeys(project.Name);
            new SelectElement(_app.Browser.FindElement(By.Id("project-status"))).SelectByValue(project.State.ToString());
            if(project.IsInheritCriteria) 
                _app.Browser.FindElement(By.XPath("//input[@id='project-inherit-global']/../span")).Click();
            new SelectElement(_app.Browser.FindElement(By.Id("project-view-state"))).SelectByValue(project.Visibility.ToString());
            _app.Browser.FindElement(By.Id("project-description")).SendKeys(project.Description);
            _app.Browser.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            var wait = new WebDriverWait(_app.Browser, new TimeSpan(0, 0, 10)); 
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => d.FindElement(By.XPath("//div[@class='table-responsive']")));

            return new ManageProjectPage(_app);
        }
    }
}
