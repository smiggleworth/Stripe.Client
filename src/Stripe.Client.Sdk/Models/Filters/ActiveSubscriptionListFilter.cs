using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class ActiveSubscriptionListFilter : ListFilter
    {
        [Required]
        [JsonIgnore]
        public string CustomerId { get; set; }
    }
}