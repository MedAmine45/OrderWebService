using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
   
    public class Patient : Person
    {
        public string Home_phone { get; set; }
        [Required]
        public string Birth_date { get; set; }
        [Column("Sex")]
        [Required]
        public string Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
