﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using MultiTenant.Models;
using System.Collections.Generic;

namespace MultiTenant
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            // ONE WAY TO SEED DATA
            //using(var context = new MultiTenantContext())
            //{
            //    context.Speakers.Add(new Speaker()
            //    {
            //        LastName = "Jones"
            //    });
            //    context.Sessions.Add(new Session()
            //    {
            //        Title = "Manager"
            //    });
            //    context.SaveChanges();
            //}

            //using( var context = new MultiTenantContext())
            //{
            //    var tenants = new List<Tenant>
            //     {
            //        new Tenant()
            //        {
            //            Name = "SVCC",
            //            Domain = "www.siliconevalley-codecamp.com",
            //            Id = 1,
            //            Default = true
            //        },
            //        new Tenant()
            //        {
            //            Name = "ANGU",
            //            Domain = "angularu.com",
            //            Id = 3,
            //            Default = false
            //        },
            //        new Tenant()
            //        {
            //            Name = "CSSC",
            //            Domain = "codestarsummit.com",
            //            Id = 2,
            //            Default = false
            //        }
            //    };
            //    context.Tenants.AddRange(tenants);
            //    context.SaveChanges();
            //}
        }
    }
}
