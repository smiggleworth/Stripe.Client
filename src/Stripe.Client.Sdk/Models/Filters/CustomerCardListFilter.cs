using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class CustomerCardListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }
    }
}