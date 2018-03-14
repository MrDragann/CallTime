using System;
using System.Web.Mvc;

namespace CallTime.Web.Infrastructure
{
    public class AuthorizeViewPage : WebViewPage
    {
        public AuthorizeViewPage()
        {
            User = new WebUser();
        }

        public new WebUser User { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class AuthorizeViewPage<TModel> : WebViewPage<TModel>
    {
        public AuthorizeViewPage()
        {
            User = new WebUser();
        }

        public new WebUser User { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}