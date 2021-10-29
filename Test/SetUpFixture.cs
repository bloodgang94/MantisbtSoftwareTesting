using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantisbt.Test.Admin
{
    [SetUpFixture]
    class SetUpFixture
    {
        [OneTimeSetUp]
        public void LoginAsAdmin()
        {
            AppManager.Instance.LoginPage.Authorization("root", "");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            AppManager.Instance.Browser.Quit();
        }
    }
}
