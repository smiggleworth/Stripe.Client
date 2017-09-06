using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Discount : IStripeModel
    {
        public string Object { get; set; }

        public Coupon Coupon { get; set; }

        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Start { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? End { get; set; }

        public string Id { get; set; }
    }
}