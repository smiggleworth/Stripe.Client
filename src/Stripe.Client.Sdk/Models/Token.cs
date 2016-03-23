using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class Token : IStripeModel
    {
        public string Object { get; set; }

        public BankAccount BankAccount { get; set; }

        public Card Card { get; set; }

        public string ClientIp { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Created { get; set; }

        public bool LiveMode { get; set; }

        public string Type { get; set; }

        public bool? Used { get; set; }
        public string Id { get; set; }
    }
}