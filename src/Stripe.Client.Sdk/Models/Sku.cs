using System.Collections.Generic;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Models
{
    public class Sku : IStripeModel
    {
        public string Currency { get; set; }

        public Inventory Inventory { get; set; }

        public int Price { get; set; }

        public string Product { get; set; }

        public bool? Active { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        ///     The URL of an image for this SKU, meant to be displayable to the customer.
        /// </summary>
        public string Image { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [ChildModel]
        public PackageDimensions PackageDimensions { get; set; }

        public string Id { get; set; }
    }
}