using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class Coupon : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public bool LiveMode { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Duration { get; set; }

        public int? AmountOff { get; set; }

        public string Currency { get; set; }

        public int? DurationInMonths { get; set; }

        public int? MaxRedemptions { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public int? PercentOff { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? RedeemBy { get; set; }

        public int TimesRedeemed { get; private set; }

        public bool Valid { get; set; }
    }
}