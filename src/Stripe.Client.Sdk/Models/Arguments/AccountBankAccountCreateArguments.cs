using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountBankAccountCreateArguments
    {
        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public string BankAccountToken { get; set; }

        [JsonIgnore]
        public BankAccountCreateArguments BankAccountCreateArguments { get; set; }

        [Required]
        [ChildModel]
        public object ExternalAccount
        {
            get
            {
                return !string.IsNullOrWhiteSpace(BankAccountToken) ? (object)BankAccountToken : BankAccountCreateArguments;
            }
        }

        public bool? DefaultForCurrency { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}