using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApiServer.DataAccessLayer;

namespace WebApiServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            Database.SetInitializer(new StudentDataInitializer());
            using (var context=new StudentDataContext())
            {
                context.Database.Initialize(force:true);
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
