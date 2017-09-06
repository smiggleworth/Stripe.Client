using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class ApplicationFeeRefund : IStripeModel
    {
        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public string BalanceTransaction { get; set; }

        public string Fee { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
        public string Id { get; set; }
    }
}