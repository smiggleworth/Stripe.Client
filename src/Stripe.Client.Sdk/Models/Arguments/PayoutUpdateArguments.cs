using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PayoutUpdateArguments
    {
        /// <summary>
        ///  The identifier of the payout to be updated.
        /// </summary>
        [Required]
        [JsonIgnore]
        public string Id { get; set; }

        /// <summary>
        ///   A set of key/value pairs that you can attach to a payout object. It can be useful for storing additional information about the payout in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
    }
}