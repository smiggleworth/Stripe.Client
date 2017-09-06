using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class InvoiceUpdateArguments
    {
        [Required]
        [JsonIgnore]
        public string InvoiceId { get; set; }

        public int? ApplicationFee { get; set; }

        public bool? Closed { get; set; }

        public string Description { get; set; }

        public bool? Forgiven { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string StatementDescriptor { get; set; }

        public decimal? TaxPercent { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialEnd { get; set; }

        public int? Quantity { get; set; }
    }
}