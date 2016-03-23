using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;

namespace Stripe.Client.Sdk.Models
{
    public class Event : IStripeModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Created { get; set; }

        public EventData Data { get; set; }

        public bool LiveMode { get; set; }

        public string UserId { get; set; }

        public int PendingWebhooks { get; set; }

        public string Request { get; set; }
    }
}