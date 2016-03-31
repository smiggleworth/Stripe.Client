using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class RecipientCardUpdateArguments : CardUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string RecipientId { get; set; }

        [JsonIgnore]
        [Required]
        public string CardId { get; set; }
    }
}