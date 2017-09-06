using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class SubscriptionItem
    {
        /// <summary>
        ///     Unique identifier for the object.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     String representing the object’s type.Objects of the same type share the same value. (value is "subscription_item")
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        ///     Time at which the object was created.Measured in seconds since the Unix epoch.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime created { get; set; }

        /// <summary>
        ///     Tthe plan the customer is subscribed to.
        /// </summary>
        public Plan plan { get; set; }

        /// <summary>
        ///     The quantity of the plan to which the customer should be subscribed.
        /// </summary>
        public int quantity { get; set; }
    }
}