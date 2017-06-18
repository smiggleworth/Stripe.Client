﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountBankAccountUpdateArguments
    {
        [Required]
        [JsonIgnore]
        public string BankAccountId { get; set; }

        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }

        public bool DefaultForCurrency { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}