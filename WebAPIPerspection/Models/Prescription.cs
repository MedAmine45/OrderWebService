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
        public long PrescriptionId { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Billing_state { get; set; }

        [Required]
        public string Invoice_state { get; set; }

        public string Invoice_id { get; set; }
        [Required]
        public decimal Price_analyses { get; set; }
        [Required]
        public decimal Price_shipping { get; set; }
        [Required]
        public decimal Amount_paid { get; set; }
        [Required]
        public string Payment_method { get; set; }
        public Patient Patient { get; set; }
        public Prescriber Prescriber { get; set; }

        public virtual ICollection<Analyse> Analyses { get; set; }

        public string Dossier_glims { get; set; }
        public string Kit_shipping_no { get; set; }
        public string Sample_shipping_no { get; set; }
        public string Shipped_by { get; set; }
        public string Shipped_on { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

    }
}
