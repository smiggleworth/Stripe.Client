﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

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
        public object ExternalAccount => !string.IsNullOrWhiteSpace(BankAccountToken) ? (object)BankAccountToken : BankAccountCreateArguments;

        public bool? DefaultForCurrency { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}