using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class ApplicationFeeRefundListFilter : ListFilter
    {
        /// <summary>
        ///     The ID of the application fee whose refunds will be retrieved.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [Required]
        [JsonIgnore]
        public string ApplicationFeeId { get; set; }
    }
}