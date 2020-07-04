using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;

//!! THIS GOT A LITTLE EXCESSIVE.
// if you are using Migrations you dont need to create all these methods.... Configuration.cs will be generated
namespace MultiTenant.Models
{
    [DbConfigurationType(typeof(DataConfiguration))]
    public class MultiTenantContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }

    internal class DataConfiguration : DbConfiguration
    {
        // constructor
        public DataConfiguration()
        {
            SetDatabaseInitializer(new MultiTenantContextInitializer());
        }
    }

    // this is the seeding method
    internal class MultiTenantContextInitializer : CreateDatabaseIfNotExists<MultiTenantContext>
    {
        protected override void Seed(MultiTenantContext context)
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
            tenants.ForEach(t => context.Tenants.Add(t));


            // this would be used to download an array of objects from a file in the root of the project
            // get list of Classes, just to double check we are recieving the file name
            var list = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var sessionJson = GetEmbeddedResourceAsString("MultiTenant.speaker.json");


            context.SaveChanges();
        }

        // gets the json as string from file
        private string GetEmbeddedResourceAsString(string resource)
        {
            var result = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();

                }
            }
        }


    }
}
