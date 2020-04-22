using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    [DataContract]
    public class Prescriber : Person
    {
        [DataMember]
        public string Office_phone { get; set; }
    }
}
