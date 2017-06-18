using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ChargeUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string ChargeId { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> FraudDetails { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string ReceiptEmail { get; set; }

        [ChildModel]
        public ShippingArguments Shipping { get; set; }
    }
}