using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.PageObject;
using Mantisbt.PageObject.Admin;
using Mantisbt.PageObject.Menu;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Mantisbt
{
    public class AppManager
    {
        private const string Path = "http://localhost/mantisbt-2.25.2/";
        private static readonly Lazy<AppManager> Lazy =
            new Lazy<AppManager>(() => new AppManager());
        public static AppManager Instance => Lazy.Value;
        public IWebDriver Browser { get; }
        public LoginPage LoginPage { get; }
        public Menu Menu { get; }
        public SideBar SideBar { get; }
        public ManageProjectPage ManageProjectPage { get; }
        public ManageProjectCreatePage ManageProjectCreatePage { get; }

        private AppManager()
        {
            Browser = new FirefoxDriver("C:\\");
            Browser.Navigate().GoToUrl(Path);
            LoginPage = new LoginPage(this);
            Menu = new Menu(this);
            SideBar = new SideBar(this);
            ManageProjectPage = new ManageProjectPage(this);
            ManageProjectCreatePage = new ManageProjectCreatePage(this);
        }
    }
}
