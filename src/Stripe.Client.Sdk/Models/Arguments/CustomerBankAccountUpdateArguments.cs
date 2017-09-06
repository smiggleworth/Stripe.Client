using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CustomerBankAccountUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string BankAccountId { get; set; }

        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        public bool DefaultForCurrency { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}