using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    public enum StateEnum
    {
        Prescribed = 1,
        Ordered = 2,
        Preparation = 3,
        Sent = 4,
        Delivered = 5,
        Samplessent = 6,
        Samplesreceived = 7,
        Cancelled = 8,
        Onhold = 9,
        Closed=10
    }
}
