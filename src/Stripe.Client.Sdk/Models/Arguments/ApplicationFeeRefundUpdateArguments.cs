using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ApplicationFeeRefundUpdateArguments
    {
        [Required]
        [JsonIgnore]
        public string ApplicationFeeRefundId { get; set; }

        [Required]
        [JsonIgnore]
        public string ApplicationFeeId { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}