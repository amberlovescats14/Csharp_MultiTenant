using System;
using System.Collections.Generic;

namespace MultiTenant.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public Tenant Tenant { get; set; }
        public List<Speaker> Speakers { get; set; }

        public Session()
        {
        }
    }
}
