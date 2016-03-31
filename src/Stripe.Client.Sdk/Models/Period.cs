using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;

namespace Stripe.Client.Sdk.Models
{
    public class Period
    {
        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Start { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? End { get; set; }
    }
}