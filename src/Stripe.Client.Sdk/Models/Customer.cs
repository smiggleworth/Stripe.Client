using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Customer : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public bool LiveMode { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public int AccountBalance { get; set; }

        public string Currency { get; set; }

        [JsonIgnore]
        public string DefaultCardId { get; set; }

        [JsonIgnore]
        public Card DefaultCard { get; set; }

        public object DefaultSource
        {
            set { Expandable<Card>.Deserialize(value, s => DefaultCardId = s, o => DefaultCard = o); }
        }

        public bool Delinquent { get; set; }

        public string Description { get; set; }

        public Discount Discount { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public Pagination<Card> Sources { get; set; }

        public Pagination<Subscription> Subscriptions { get; set; }

        public bool? Deleted { get; set; }
    }
}