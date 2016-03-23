using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class RecipientCreateArguments
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public string TaxId { get; set; }

        [JsonIgnore]
        public string BankAccountToken { get; set; }

        [JsonIgnore]
        public RecipientBankAccountArguments RecipientBankAccountArguments { get; set; }

        [ChildModel]
        public object BankAccount
        {
            get
            {
                return !string.IsNullOrWhiteSpace(BankAccountToken)
                    ? BankAccountToken
                    : (object) RecipientBankAccountArguments;
            }
        }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Card
        {
            get { return !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object) CardCreateArguments; }
        }

        public string Email { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}