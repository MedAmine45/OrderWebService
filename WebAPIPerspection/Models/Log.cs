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
    [Table("Log")]
    public class Log
    {
        //[DataMember]
        [Key]
        public long LogID { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Billing_state { get; set; }
        [DataMember]
        public string Invoice_state { get; set; }
        [DataMember]
        [Required]
        public string By { get; set; }
        [DataMember]
        [Required]
        public DateTime On { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
