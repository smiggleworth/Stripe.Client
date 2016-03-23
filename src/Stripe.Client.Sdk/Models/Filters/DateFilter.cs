using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class DateFilter
    {
        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Gt { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Gte { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Lt { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Lte { get; set; }
    }
}