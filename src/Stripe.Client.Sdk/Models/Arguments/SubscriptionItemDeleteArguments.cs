using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SubscriptionItemDeleteArguments
    {
        /// <summary>
        ///     The identifier of the subscription item to modify.
        /// </summary>
        [JsonIgnore]
        [Required]
        public string Id { get; set; }

        /// <summary>
        ///     Flag indicating whether to prorate switching plans during a billing cycle.
        /// </summary>
        public bool Prorate { get; set; }

        /// <summary>
        ///     If set, the proration will be calculated as though the subscription was updated at the given time.This can be used
        ///     to apply the same proration that was previewed with the upcoming invoice endpoint.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime ProrationDate { get; set; }
    }
}