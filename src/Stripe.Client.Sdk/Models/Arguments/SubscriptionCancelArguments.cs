using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SubscriptionCancelArguments
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        [JsonIgnore]
        [Required]
        public string SubscriptionId { get; set; }

        /// <summary>
        ///     A flag that if set to true will delay the cancellation of the subscription until the end of the current period.
        /// </summary>
        public bool? AtPeriodEnd { get; set; }
    }
}