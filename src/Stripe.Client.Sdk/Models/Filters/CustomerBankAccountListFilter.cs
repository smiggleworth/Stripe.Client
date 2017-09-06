using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class CustomerBankAccountListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }
    }
}