using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string BillingState { get; set; }
        public decimal Price_analyses { get; set; }
        public decimal Price_shipping { get; set; }
        public Patient Patient { get; set; }
        public Prescriber Prescriber { get; set; }
        public virtual List<string> Analyses { get; set; }
        public virtual List<string> Tubes { get; set; }
    }
}
