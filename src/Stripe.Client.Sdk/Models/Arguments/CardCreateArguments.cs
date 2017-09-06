using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CardCreateArguments : IPaymentTypeArguments
    {
        public virtual string Object => "card";

        [Required]
        [Range(1, 12)]
        public int ExpMonth { get; set; }

        [Required]
        [Range(1970, int.MaxValue)]
        public int ExpYear { get; set; }

        [Required]
        public string Number { get; set; }

        public string AddressCity { get; set; }

        public string AddressCountry { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressState { get; set; }

        public string AddressZip { get; set; }

        public string Cvc { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string Name { get; set; }

        public decimal? TaxPercent { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialEnd { get; set; }

        public string Currency { get; internal set; }

        public bool? DefaultForCurrency { get; set; }
    }
}