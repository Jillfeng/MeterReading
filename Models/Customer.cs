using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReading.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Reading> MeterReadings { get; } = new List<Reading>();
    }
}
