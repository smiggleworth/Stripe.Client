using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class ApplicationFeeRefund : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public string BalanceTransaction { get; set; }

        public string Fee { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}