using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class RefundCreateArguments
    {
        [JsonIgnore]
        [Required]
        public string ChargeId { get; set; }

        public int? Amount { get; set; }

        public bool? RefundApplicationFee { get; set; }

        public bool? ReverseTransfer { get; set; }

        public string Reason { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}