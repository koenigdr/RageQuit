using RageQuit.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RageQuit
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            if(Context.User != null)
            {
                string username = Context.User.Identity.Name;
                IIdentity userIdentitiy = new GenericIdentity(username);
                string[] roles = { "nonAdmin" };
                using (RageQuitContext context = new RageQuitContext())
                {
                    List<User> userList = context.Users.Where(row => row.username.Equals(username)).ToList();
                    foreach (User user in userList)
                    {
                        if (user.isActive)
                        {
                            if(user.isAdmin)
                            {
                                roles[0] = "Admin";
                            }
                            IPrincipal newUserObj = new GenericPrincipal(userIdentitiy, roles);
                            Context.User = newUserObj;
                        }
                    }
                }
            }
        }
    }
}
