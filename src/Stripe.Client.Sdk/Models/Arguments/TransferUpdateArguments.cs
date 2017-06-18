using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class TransferUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string TransferId { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}