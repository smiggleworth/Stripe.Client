using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class BalanceTransaction : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime AvailableOn { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public int Fee { get; set; }

        public List<FeeModel> FeeDetails { get; set; }

        public int Net { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
    }
}