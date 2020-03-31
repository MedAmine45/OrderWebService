using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    public class Patient : Person
    {
        public string Home_phone { get; set; }
    }
}
