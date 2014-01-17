using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment.Models
{
    public class Device
    {
        public int DeviceId { get;set; }
        public string DeviceSerialNumber { get; set; }
        [Required]
        [StringLength(14)]
        public string DeviceUser { get; set; }
        public int DeviceDictionaryId { get; set; }
        [ForeignKey("DeviceDictionaryId")]
        public virtual DeviceDictionary DeviceDictionary {get;set;}
        public string Batch { get; set; }
    }
}