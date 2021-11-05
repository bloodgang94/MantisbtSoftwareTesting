using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.Models;
using Mantisbt.Service;
using OpenQA.Selenium;

namespace Mantisbt.PageObject.Admin
{
    public class ManageProjectPage : WebPage
    {
        public IList<IWebElement> Table => _app.Browser.FindElements(By.XPath(
            "//i[@class='fa fa-puzzle-piece ace-icon']/ancestor::div[@class='widget-box widget-color-blue2']//tbody/tr"));
        public ManageProjectPage(AppManager app) : base(app) { }

        public ManageProjectCreatePage CreateNewProj()
        {
            _app.Browser.FindElement(By.XPath("//button[.='Создать новый проект']")).Click();
            return new ManageProjectCreatePage(_app);
        }

        public ManageProjectEditPage OpenProject(int id)
        {
            _app.Browser.FindElement(By.XPath($"//td/a[contains(@href, 'id={id}')]")).Click();
            return  new ManageProjectEditPage(_app);
        }

        public IEnumerable<Project> GetProjectInTable()
        {
            List<Project> projectsList = new List<Project>();
           
            foreach (var value in Table)
            {
                var tds = value.FindElements(By.XPath("./td"));
                projectsList.Add(new Project(){ Name = tds[0].Text, State = int.Parse(tds[1].Text), Visibility = int.Parse(tds[3].Text), Description = tds[4].Text });
            }

            return projectsList;
        }
    }
}
