using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CouponCreateArguments
    {
        /// <summary>
        /// Unique string of your choice that will be used to identify this coupon when applying it to a customer. This is often a specific code you’ll give to your customer to use when signing up (e.g. FALL25OFF). If you don’t want to specify a particular code, you can leave the ID blank and we’ll generate a random code for you.
        /// </summary>
        public string Id { get; set; }

        public int? AmountOff { get; set; }

        public string Currency { get; set; }

        public int? PercentOff { get; set; }

        [Required]
        public string Duration { get; set; }

        public int? DurationInMonths { get; set; }

        public int? MaxRedemptions { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime? RedeemBy { get; set; }
    }
}