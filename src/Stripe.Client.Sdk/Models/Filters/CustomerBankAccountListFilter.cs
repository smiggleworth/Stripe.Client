using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class CustomerBankAccountListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }
    }
}