using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CustomerCardUpdateArguments : CardUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        [JsonIgnore]
        [Required]
        public string CardId { get; set; }
    }
}