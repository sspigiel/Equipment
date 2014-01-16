using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Models
{
    public class Device
    {
        public int DeviceId { get;set; }
        [Required]
        public string DeviceManufacturer { get; set; }
        [Required]
        public string DeviceName { get; set; }
        [Required]
        public string DeviceSerialNumber { get; set; }
        [StringLength(14)]
        public string DeviceUser { get; set; }
    }
    public class DeviceDBContext: DbContext
    {
        public DbSet<Device> Devices {get; set;}
    }
}