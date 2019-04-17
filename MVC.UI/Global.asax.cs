using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;
using System.Web.Security;
using MVC.Models;
using MVC.BLL;
using System.Web.Script.Serialization;
using System.Web.Optimization;
namespace MVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            AuthorizeRequest += new EventHandler(MvcApplication_AuthorizeRequest);
        }

        void MvcApplication_AuthorizeRequest(object sender, EventArgs e)
        {
            UserData userData = null;
            var id = Context.User.Identity as FormsIdentity;
            if (id != null && id.IsAuthenticated)
            {
                //  还原用户数据
                userData = (new JavaScriptSerializer()).Deserialize<UserData>(id.Ticket.UserData);
                if (id.Ticket != null && userData != null)
                    // 4. 构造我们的MyFormsPrincipal实例，重新给context.User赋值。
                    Context.User = new MyPrincipal(id.Ticket, userData);
                
               // var roles = id.Ticket.UserData.Split(',');
               // Context.User = new GenericPrincipal(id, roles);
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
