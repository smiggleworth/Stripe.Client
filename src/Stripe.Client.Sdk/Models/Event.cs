using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class Event : IStripeModel
    {
        public string Type { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Created { get; set; }

        public EventData Data { get; set; }

        public bool LiveMode { get; set; }

        public string Account { get; set; }

        public int PendingWebhooks { get; set; }

        public string Request { get; set; }
        public string Id { get; set; }
    }
}