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
        prescribed = 1,
        ordered = 2,
        preparation = 3,
        kitsent = 4,
        kitdelivered = 5,
        samplessent = 6,
        samplesreceived = 7,
        cancelled = 8,
        onhold = 9
    }
}
