using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class TransferReversalUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string TransferReversalId { get; set; }

        [JsonIgnore]
        [Required]
        public string TransferId { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}