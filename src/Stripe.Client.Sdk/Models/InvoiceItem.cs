using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class InvoiceItem
    {

        public string Id { get; set; }

        public string Object => "invoiceitem";
        public int Amount { get; set; }

        public string Currency { get; set; }

        public string Customer { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool Discountable { get; set; }

        public string Invoice { get; set; }

        public bool Livemode { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public Period Period { get; set; }

        public Plan Plan { get; set; }

        public bool Proration { get; set; }

        public string Quantity { get; set; }

        public string Subscription { get; set; }
    }
}
