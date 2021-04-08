using MeterReading.Models;
using MeterReading.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MeterReading.Controllers
{
    public class HomeController : Controller
    {
        private CustomerMeterReadingModels Db;       
        [HttpPost]
        public ActionResult UploadFile(IFormFile fileUpload)
        {
            List<Reading> meterReadingList = new List<Reading>();
            List<Customer> customers = Db.Customers.ToList();
            bool validEntry = false;

            using (var rd = new StreamReader("fileUpload"))
            {
                while (!rd.EndOfStream)
                {
                    Reading meterReading = new Reading();
                    var splits = rd.ReadLine().Split(',');

                    meterReading.AccountId = int.Parse(splits[0]);
                    meterReading.MeterReadingDate = DateTime.Parse(splits[1]);
                    meterReading.Meter = splits[2];

                    meterReadingList.Add(meterReading);
                }
            }
            foreach(var meterReading in meterReadingList)
            {
                VerfyInput(meterReading, customers, validEntry);
                if (validEntry)
                {
                    var file = new Reading
                    {
                        AccountId = meterReading.AccountId,
                        MeterReadingDate = meterReading.MeterReadingDate,
                        Meter = meterReading.Meter
                    };
                    Db.MeterReadings.Add(file);
                }
            }
            var feedback = "File uploaded.";
            if (!validEntry)
            {
                feedback = "File upload failed.";
            }
            Db.SaveChanges();
            return Json(feedback);
        }

        private bool VerfyInput(Reading meterReading, List<Customer> customers, bool ValidEntry)
        {           
            bool customerExists = customers.Any(x => x.AccountId == meterReading.AccountId);
            if(meterReading.AccountId != 0 && customerExists)
            {
                return ValidEntry = true;
            }
            if(meterReading.Meter.Length == 5)
            {
                return ValidEntry = true;
            }
            return ValidEntry;
        }
    }
}
