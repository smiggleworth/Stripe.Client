using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class AccountCardListFilter : ListFilter
    {
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }
    }
}