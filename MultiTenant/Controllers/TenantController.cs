using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant.Models;

namespace MultiTenant.Controllers
{
    public class TenantController : Controller
    {
        public ActionResult Index()
        {
            var tenants = new List<Tenant>
            {
                new Tenant()
                {
                    Name = "SVCC",
                    Domain = "www.siliconevalley-codecamp.com",
                    Id = 1,
                    Default = true
                },
                new Tenant()
                {
                    Name = "ANGU",
                    Domain = "angularu.com",
                    Id = 3,
                    Default = false
                },
                new Tenant()
                {
                    Name = "CSSC",
                    Domain = "codestarsummit.com",
                    Id = 2,
                    Default = false
                }
            };
            return View(tenants);
        }
    }
}
