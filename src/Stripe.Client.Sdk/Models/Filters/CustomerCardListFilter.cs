using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class CustomerCardListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }
    }
}