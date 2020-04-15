using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [Table("Analyse")]
    public class Analyse
    {
        [Key]
        public long AnalyseID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Tubes { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Tube_violet { get; set; }
        public int Tube_rouge { get; set; }
        public int Tube_gris { get; set; }
        public int Urine_matin { get; set; }

        public int Selles { get; set; }

        public virtual Prescription Prescription { get; set; }



    }
}
