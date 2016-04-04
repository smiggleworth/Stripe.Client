using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class RecipientCardListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string RecipientId { get; set; }
    }
}