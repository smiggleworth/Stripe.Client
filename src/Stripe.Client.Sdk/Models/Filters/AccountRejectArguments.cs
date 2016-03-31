using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class AccountRejectArguments
    {
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }


        [Required]
        public string Reason { get; set; }
    }
}