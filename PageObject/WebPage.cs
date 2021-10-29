using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantisbt.PageObject
{
    public class WebPage
    {
        protected readonly AppManager _app;

        public string Title => _app.Browser.Title;

        public WebPage(AppManager app)
        {
            _app = app;
        }
    }
}
