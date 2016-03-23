using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class RecipientCardListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string RecipientId { get; set; }
    }
}