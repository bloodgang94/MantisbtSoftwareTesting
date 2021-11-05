using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.MantisService;
using Mantisbt.Models;
using Mantisbt.PageObject;
using NUnit.Framework;

namespace Mantisbt.Test.Admin
{
    [TestFixture]
    class DeleteProjectTest
    {
        private readonly Project _projectModel = new Project() 
            { 
                Name = Guid.NewGuid().ToString(),
                State = 10,
                IsInheritCriteria  = true, 
                Visibility = 50, 
                Description = "test"
            };

        [OneTimeSetUp]
        public void OpenMenu()
        {
            AppManager.Instance.SideBar.Manage.Click();
            AppManager.Instance.Menu.Manage.Click();

            //Если проектов нет, то добавляем
            if (!AppManager.Instance.SoapHelper.GetProjects().Any())
            {
                AppManager.Instance.SoapHelper.AddNewProject(new ProjectData()
                {
                    name = "test", description = "test", enabled = true
                });
                AppManager.Instance.Browser.Navigate().Refresh();
            }
        }

        [Test]
        public void DeleteProject_ProjectSuccessDeleted()
        {
            //Получаем через soap
            var expectedProject = AppManager.Instance.SoapHelper.GetProjects().OrderBy(x => x.Id).ToList();
            AppManager.Instance.ManageProjectPage.OpenProject(expectedProject.First().Id).DeleteProject();
            expectedProject.Remove(expectedProject.First());
            //Получаем через soap
            Assert.That(AppManager.Instance.SoapHelper.GetProjects().ToList(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }
    }
}
