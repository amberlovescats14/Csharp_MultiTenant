using System;
namespace MultiTenant.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public bool Default { get; set; }
    }
}
