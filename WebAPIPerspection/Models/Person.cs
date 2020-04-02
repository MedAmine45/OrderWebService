using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public long PersonId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Birth_date { get; set; }
        [Column("Sex")]
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Mobile_phone { get; set; }
    }
}
