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
    [Table("Person")]
    public abstract class Person
    {
        //[DataMember]
        [Key]
        public long PersonId { get; set; }
        [DataMember]
        [Required]
        public string Firstname { get; set; }
        [DataMember]
        [Required]
        public string Lastname { get; set; }
        [DataMember]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataMember]
        [Required]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        [Required]
        public string Zip { get; set; }
        [DataMember]
        [Required]
        public string City { get; set; }
        [DataMember]
        [Required]
        public string Country { get; set; }
        [DataMember]
        [Required]
        public string Language { get; set; }
        [DataMember]
        public string Mobile_phone { get; set; }
    }
}
