using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public long LogID { get; set; }
        public string State { get; set; }
        public string Billing_state { get; set; }
        public string Invoice_state { get; set; }
        [Required]
        public string By { get; set; }
        [Required]
        public DateTime On { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
