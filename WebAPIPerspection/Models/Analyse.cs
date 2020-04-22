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
    [Table("Analyse")]
    public class Analyse
    {
        //[DataMember]
        [Key]
        public long AnalyseID { get; set; }
        [DataMember]
        [Required]
        public string Code { get; set; }
        [DataMember]
        [Required]
        public string Tubes { get; set; }
        [DataMember]
        [Required]
        public decimal Price { get; set; }
        [DataMember]
        public int Tube_violet { get; set; }
        [DataMember]
        public int Tube_rouge { get; set; }
        [DataMember]
        public int Tube_gris { get; set; }
        [DataMember]
        public int Urine_matin { get; set; }
        [DataMember]
        public int Selles { get; set; }

        public virtual Prescription Prescription { get; set; }



    }
}
