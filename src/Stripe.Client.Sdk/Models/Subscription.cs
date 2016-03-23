using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Subscription : IStripeModel
    {
        public string Object { get; set; }

        public bool CancelAtPeriodEnd { get; set; }

        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        internal object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        public Plan Plan { get; set; }

        public int Quantity { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? Start { get; set; }

        public string Status { get; set; }

        public decimal? ApplicationFeePercent { get; set; }

        public decimal? TaxPercent { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? CanceledAt { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? PeriodEnd { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? PeriodStart { get; set; }

        public Discount Discount { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? EndedAt { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? TrialEnd { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? TrialStart { get; set; }

        public string Id { get; set; }
    }
}