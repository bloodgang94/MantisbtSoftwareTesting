using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.Models;
using Mantisbt.PageObject;
using NUnit.Framework;

namespace Mantisbt.Test.Admin
{
    [TestFixture]
    class CreateProjectTest
    {
        private readonly Project _projectModel = new Project() 
            { 
                Name = Guid.NewGuid().ToString(),
                State = "выпущен",
                IsInheritCriteria  = true, 
                Visibility = "приватный", 
                Description = "test"
            };

        [OneTimeSetUp]
        public void OpenMenu()
        {
            AppManager.Instance.SideBar.Manage.Click();
            AppManager.Instance.Menu.Manage.Click();
        }

        [Test]
        public void CreateNewProject_ProjectSuccessCreated()
        {
            var expectedProject = AppManager.Instance.ManageProjectPage.GetProjectInTable().ToList();
            expectedProject.Add(_projectModel);
            AppManager.Instance.ManageProjectPage.CreateNewProj().AddNewProject(_projectModel);

            Assert.That(AppManager.Instance.ManageProjectPage.GetProjectInTable(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }

    }
}
