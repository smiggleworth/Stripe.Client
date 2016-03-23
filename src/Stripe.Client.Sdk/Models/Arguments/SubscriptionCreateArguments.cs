using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SubscriptionCreateArguments
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string Plan { get; set; }

        public string Coupon { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? TrialEnd { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Source
        {
            get { return !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object) CardCreateArguments; }
        }

        public int? Quantity { get; set; }

        public decimal? ApplicationFeePercent { get; set; }

        public decimal? TaxPercent { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? BillingCycleAnchor { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}