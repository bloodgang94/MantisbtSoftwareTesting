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
        }

        [Test]
        public void CreateNewProject_ProjectSuccessCreated()
        {
            //Получаем через soap
            var expectedProject = AppManager.Instance.SoapHelper.GetProjects().ToList();
            expectedProject.Add(_projectModel);
            AppManager.Instance.ManageProjectPage.CreateNewProj().AddNewProject(_projectModel);
            //Получаем через soap
            Assert.That(AppManager.Instance.SoapHelper.GetProjects().ToList(), Is.EquivalentTo(expectedProject).Using(new ProjectComparer()));
        }

    }
}
