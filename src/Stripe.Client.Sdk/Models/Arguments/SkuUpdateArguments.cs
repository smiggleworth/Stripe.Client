using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SkuUpdateArguments
    {
        [Required]
        [JsonIgnore]
        public string SkuId { get; set; }

        public string Currency { get; set; }

        /// <summary>
        /// Inventory Description
        /// </summary>
        public string Inventory { get; set; }

        public int? Price { get; set; }

        public string Product { get; set; }

        public bool? Active { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// The URL of an image for this SKU, meant to be displayable to the customer.
        /// </summary>
        public string Image { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [ChildModel]
        public PackageDimensionArguments PackageDimensions { get; set; }
    }
}