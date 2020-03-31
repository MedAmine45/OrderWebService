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
        paidonline = 2,
        paidbycheck = 3,
        paidbytransfer = 4,
        receivednotpaid = 5
    }
}
