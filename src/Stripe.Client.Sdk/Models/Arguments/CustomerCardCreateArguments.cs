using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CustomerCardCreateArguments
    {
        [Required]
        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [Required]
        [ChildModel]
        public object Source => !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object)CardCreateArguments;

        public Dictionary<string, string> Metadata { get; set; }
    }
}