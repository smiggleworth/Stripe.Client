using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountCardUpdateArguments : CardUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string CardId { get; set; }

        [JsonIgnore]
        [Required]
        public string AccountId { get; set; }

        public bool? DefaultForCurrency { get; set; }
    }
}