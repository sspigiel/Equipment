using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Models
{
    public class MyDbContext: DbContext
    {
        public DbSet<Device> Devices {get; set;}
        public DbSet<DeviceDictionary> Dictionaries { get; set; }
    }
}