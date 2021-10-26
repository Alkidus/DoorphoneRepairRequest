using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class SubscriberContext : DbContext
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DomofonHandset> DomofonHandsets { get; set; }
        public DbSet<DomofonKey> DomofonKeys { get; set; }
        public DbSet<DomofonSystem> DomofonSystems { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<Serviceman> Servicemen { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        public SubscriberContext(DbContextOptions<SubscriberContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //public SubscriberContext() : base()
        //{
        //    Database.EnsureCreated();
        //}
    }
}
