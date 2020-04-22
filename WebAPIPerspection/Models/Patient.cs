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
    public class Patient : Person
    {
        [DataMember]
        public string Home_phone { get; set; }
        [DataMember]
        [Required]
        public string Birth_date { get; set; }
        [DataMember]
        [Column("Sex")]
        [Required]
        public string Sex { get; set; }
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public int Weight { get; set; }
    }
}
