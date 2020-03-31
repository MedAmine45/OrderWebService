using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    public class Prescriber : Person
    {
        public string Office_phone { get; set; }
    }
}
