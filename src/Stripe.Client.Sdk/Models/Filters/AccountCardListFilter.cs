using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class AccountCardListFilter : ListFilter
    {
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }
    }
}