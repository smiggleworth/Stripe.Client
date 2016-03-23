using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class RefundUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string RefundId { get; set; }

        [JsonIgnore]
        [Required]
        public string ChargeId { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}