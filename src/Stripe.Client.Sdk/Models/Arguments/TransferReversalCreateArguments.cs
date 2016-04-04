using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class TransferReversalCreateArguments
    {
        [JsonIgnore]
        [Required]
        public string TransferId { get; set; }

        public int? Amount { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public bool RefundApplicationFee { get; set; }
    }
}