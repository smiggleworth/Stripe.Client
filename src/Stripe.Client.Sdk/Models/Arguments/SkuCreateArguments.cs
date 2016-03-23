using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class SkuCreateArguments
    {
        public string Id { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        [ChildModel]
        public InventoryArguments Inventory { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Product { get; set; }

        public bool? Active { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// The URL of an image for this SKU, meant to be displayable to the customer.
        /// </summary>
        public string Image { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [ChildModel]
        public PackageDimensions PackageDimensions { get; set; }
    }
}