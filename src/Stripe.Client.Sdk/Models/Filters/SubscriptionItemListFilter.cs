using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class SubscriptionItemListFilter : ListFilter
    {
        /// <summary>
        ///     The ID of the subscription whose items will be retrieved.
        /// </summary>
        [Required]
        public string subscription { get; set; }
    }
}