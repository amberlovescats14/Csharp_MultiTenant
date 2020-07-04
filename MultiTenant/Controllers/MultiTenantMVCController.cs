using System;
using System.Web.Mvc;
using MultiTenant.Models;
using Microsoft.Owin;
using Owin;
using System.Web;

namespace MultiTenant.Controllers
{
    public class MultiTenantMVCController : Controller
    {
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if (!Request.GetOwinContext().TryGetValue("MultiTenant", out multiTenant)) throw new ApplicationException("Could not find Tenant");
                else return (Tenant)multiTenant;
            }
        }
    }
}
