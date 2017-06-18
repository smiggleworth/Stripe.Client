using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SubscriptionItemCreateArguments
    {
        /// <summary>
        ///     The identifier of the plan to add to the subscription.
        /// </summary>
        [Required]
        public string Plan { get; set; }

        /// <summary>
        ///     The identifier of the subscription to modify.
        /// </summary>
        [Required]
        public string Subscription { get; set; }

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

        /// <summary>
        ///     The quantity you’d like to apply to the subscription item you’re creating.
        /// </summary>
        public int Quantity { get; set; }
    }
}