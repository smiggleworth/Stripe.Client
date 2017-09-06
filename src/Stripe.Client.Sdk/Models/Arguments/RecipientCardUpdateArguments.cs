using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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