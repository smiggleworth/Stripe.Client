using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountCardCreateArguments
    {
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [Required]
        [ChildModel]
        public object ExternalAccount => !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object)CardCreateArguments;

        public bool? DefaultForCurrency { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}