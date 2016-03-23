using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class InvoiceItemUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string InvoiceItemId { get; internal set; }

        public int? Amount { get; set; }

        public string Description { get; set; }


        public bool? Discountable { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}