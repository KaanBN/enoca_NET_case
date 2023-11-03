﻿using enoca_NET_case.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace enoca_NET_case.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
