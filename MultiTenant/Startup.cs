using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin;
using MultiTenant.Models;
using Owin;

[assembly: OwinStartup(typeof(MultiTenant.Startup))]
namespace MultiTenant
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                if (tenant == null) throw new ApplicationException("Tenant not found");

                ctx.Environment.Add("MultiTenant", tenant);
                await next();

            });
        }

        private Tenant GetTenantBasedOnUrl(string urlHost)
        {
            if (string.IsNullOrEmpty(urlHost)) throw new ApplicationException("urlHose was Null");
            using( var context = new MultiTenantContext())
            {
                var tenants = context.Tenants.ToList();
                var currentTenant = tenants.FirstOrDefault(a => a.Domain.ToLower().Equals(urlHost)) ??
                    tenants.FirstOrDefault(a => a.Default);
                if (currentTenant == null) throw new ApplicationException("No tenant found.");
                return currentTenant;
            }
        }
    }
}
