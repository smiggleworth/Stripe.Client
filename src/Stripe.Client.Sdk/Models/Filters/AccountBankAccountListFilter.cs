using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class AccountBankAccountListFilter : ListFilter
    {
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }
    }
}