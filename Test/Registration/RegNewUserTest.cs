using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Mantisbt.Help;
using Mantisbt.Models;
using Mantisbt.RestApi;
using NUnit.Framework;
using RestSharp;

namespace Mantisbt.Test.Registration
{
    [TestFixture]
    class RegNewUserTest
    {
        private readonly RestClient _restClient;

        public RegNewUserTest()
        {
            _restClient = new RestClient("http://localhost:8025/api/v2/");
        }

        [OneTimeSetUp]
        public void DisableCaptcha()
        {
            AppManager.Instance.Browser.Navigate().GoToUrl(AppManager.Instance.Path);
            Ftp.BackupConfigFile();
        }

        [Test]
        public void RegisterNewAccount_UserSuccessLogin()
        {
            var account = new Account()
            {
                Login = TestContext.CurrentContext.Random.GetString(5),
                Email = TestContext.CurrentContext.Random.GetString(15) + "@mail.ru",
                Password = "password",
            };

            AppManager.Instance.LoginPage.RegisterNewAccount().RegisterNow(account);

            Thread.Sleep(5000);
            var request = new RestRequest("messages", Method.GET);
            var models = _restClient.Execute<MailHogModel>(request).Data;
            var raw = Decode.DecodeQuotedPrintable(models.Items.Skip(1).First().Content.Body, Encoding.UTF8);
            var decode = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(raw));

            var regex = new Regex(
                @"http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?");

            var confirmUrl = regex.Match(decode).Value;

            AppManager.Instance.VerifyPage.Confirm(confirmUrl, account);
            AppManager.Instance.LoginPage.Authorization(account.Login, account.Password);

            Assert.That(AppManager.Instance.MyPage.Profile.Text, Does.Contain(account.Login));

        }

        [OneTimeTearDown]
        public void RestoreConfig()
        {
           Ftp.RestoreConfigFile();
           AppManager.Instance.Browser.Navigate().GoToUrl(AppManager.Instance.Path + "logout_page.php");
        }

        
    }
}
