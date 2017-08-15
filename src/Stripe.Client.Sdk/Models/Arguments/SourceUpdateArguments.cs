using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments {
    public class SourceUpdateArguments
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [Required]
        [JsonIgnore]
        public string Id { get; set; }

        /// <summary>
        ///     A set of key/value pairs that you can attach to a source object. It can be useful for storing additional
        ///     information about the source in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Information about the owner of the payment instrument that may be used or required by particular source types.
        /// </summary>
        [ChildModel]
        public OwnerArguments Owner { get; set; }

    }
}