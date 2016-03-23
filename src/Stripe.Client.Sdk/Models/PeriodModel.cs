using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class PeriodModel
    {
        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Start { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? End { get; set; }
    }
}