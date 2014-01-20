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
        [Required]
        public string DeviceSerialNumber { get; set; }       
        [StringLength(14)]
        public string DeviceUser { get; set; }
        [Required]
        public int DeviceDictionaryId { get; set; }
        [ForeignKey("DeviceDictionaryId")]
        public virtual DeviceDictionary DeviceDictionary {get;set;}
        [Required]
        public string Batch { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}