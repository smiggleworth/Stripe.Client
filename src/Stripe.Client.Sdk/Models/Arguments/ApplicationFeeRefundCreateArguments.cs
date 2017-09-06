﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ApplicationFeeRefundCreateArguments
    {
        [JsonIgnore]
        [Required]
        public string ApplicationFeeId { get; set; }

        public int Amount { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}