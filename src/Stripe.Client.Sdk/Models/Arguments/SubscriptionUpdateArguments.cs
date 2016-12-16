using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SubscriptionUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        [JsonIgnore]
        [Required]
        public string SubscriptionId { get; set; }

        public string Coupon { get; set; }

        public string Plan { get; set; }

        public bool Prorate { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? ProrationDate { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Source => !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object)CardCreateArguments;

        public decimal? ApplicationFeePercent { get; set; }

        public decimal? TaxPercent { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public int? Quantity { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialEnd { get; set; }
    }
}