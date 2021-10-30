using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mantisbt.Test
{
    [SetUpFixture]
    class AllSetUpFixure
    {
        [OneTimeTearDown]
        public void TearDown()
        {
            AppManager.Instance.Browser?.Quit();
        }
    }
}
