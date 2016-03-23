using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class ActiveSubscriptionListFilter : ListFilter
    {
        [Required]
        [JsonIgnore]
        public string CustomerId { get; set; }
    }
}