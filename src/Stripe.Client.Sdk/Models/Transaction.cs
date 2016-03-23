using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class Transaction
    {
        public string Id { get; set; }

        public string Object
        {
            get { return "transaction"; }
        }
        public int Amount { get; set; }

        public int BitcoinAmount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public string Receiver { get; set; }
    }
}