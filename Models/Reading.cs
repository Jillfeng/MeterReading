using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReading.Models
{
    public class Reading
    {
        public int ReadingId { get; set; }
        public int AccountId { get; set; }
        public DateTime MeterReadingDate { get; set; }
        public string Meter { get; set; }

        public Customer Customer { get; set; }
    }
}
