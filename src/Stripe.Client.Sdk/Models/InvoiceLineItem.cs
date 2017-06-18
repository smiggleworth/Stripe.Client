using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class InvoiceLineItem : IStripeModel
    {
        public string Object { get; set; }

        public bool LiveMode { get; set; }

        public int Amount { get; set; }

        public string Currency { get; set; }

        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        [JsonProperty("customer")]
        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Date { get; set; }

        public bool Proration { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public string InvoiceId { get; set; }

        [JsonIgnore]
        public Invoice InvoiceModel { get; set; }

        public object Invoice
        {
            set { Expandable<Invoice>.Deserialize(value, s => InvoiceId = s, o => InvoiceModel = o); }
        }

        public Dictionary<string, string> Metadata { get; set; }

        public Plan Plan { get; set; }

        public int? Quantity { get; set; }

        public string Subscription { get; set; }

        public Period Period { get; set; }

        public string Type { get; set; }
        public string Id { get; set; }
    }
}