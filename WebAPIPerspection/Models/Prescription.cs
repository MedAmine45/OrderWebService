using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [DataContract]
    [Table("Prescription")]
    public class Prescription
    {
        [DataMember]
        [Key]
        public long PrescriptionId { get; set; }
        [DataMember]
        [Required]
        public string State { get; set; }
        [DataMember]
        [Required]
        public string Billing_state { get; set; }
        [DataMember]
        [Required]
        public string Invoice_state { get; set; }
        [DataMember]
        public string Invoice_id { get; set; }
        [DataMember]
        [Required]
        public decimal Price_analyses { get; set; }
        [DataMember]
        [Required]
        public decimal Price_shipping { get; set; }
        [DataMember]
        [Required]
        public decimal Amount_paid { get; set; }
        [DataMember]
        [Required]
        public string Payment_method { get; set; }
        [DataMember]
        public Patient Patient { get; set; }
        [DataMember]
        public Prescriber Prescriber { get; set; }

        [DataMember]
        public virtual ICollection<Analyse> Analyses { get; set; }
        [DataMember]
        public string Dossier_glims { get; set; }
        [DataMember]
        public string Kit_shipping_no { get; set; }
        [DataMember]
        public string Sample_shipping_no { get; set; }
        [DataMember]
        public string Shipped_by { get; set; }
        [DataMember]
        public string Shipped_on { get; set; }

        [DataMember]
        public virtual ICollection<Log> Logs { get; set; }

    }
}
