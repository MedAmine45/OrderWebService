using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIPerspection.Models
{
    public enum BillingState
    {
        topay = 1,
        paid = 2,
        checkexpected = 3,
        transferexpected = 4,
        wrongpayment = 5
    }
}
