using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class Plan : IStripeModel
    {
        public string Object { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Interval { get; set; }

        public int IntervalCount { get; set; }

        public bool LiveMode { get; set; }

        public string StatementDescriptor { get; set; }

        public int? TrialPeriodDays { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
        public string Id { get; set; }
    }
}