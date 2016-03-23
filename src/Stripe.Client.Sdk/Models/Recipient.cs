using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Recipient : IStripeModel
    {
        public string Object { get; set; }

        public bool LiveMode { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Type { get; set; }

        public RecipientActiveAccount ActiveAccount { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string Name { get; set; }

        public Pagination<Card> Cards { get; set; }

        public bool Verified { get; set; }

        [JsonIgnore]
        public string DefaultCardId { get; set; }

        [JsonIgnore]
        public Card DefaultCardModel { get; set; }

        public object DefaultCard
        {
            set { Expandable<Card>.Deserialize(value, s => DefaultCardId = s, o => DefaultCardModel = o); }
        }

        public string Id { get; set; }
    }
}