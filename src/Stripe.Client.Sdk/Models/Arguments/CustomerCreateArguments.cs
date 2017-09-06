using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CustomerCreateArguments
    {
        public int? AccountBalance { get; set; }

        public string Coupon { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string Plan { get; set; }

        public int? Quantity { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Source => !string.IsNullOrWhiteSpace(CardToken) ? (object)CardToken : CardCreateArguments;

        [ChildModel]
        public ShippingArguments Shipping { get; set; }

        public decimal? TaxPercent { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialEnd { get; set; }
    }
}