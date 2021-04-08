using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReading.Models
{
    public class CustomerMeterReadingModels : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reading> MeterReadings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=c:\meterreading.db");
        }

    }
}
