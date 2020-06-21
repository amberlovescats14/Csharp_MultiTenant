﻿using System;
using System.Data.Entity;

namespace MultiTenant.Models
{
    public class MultiTenantContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }
}