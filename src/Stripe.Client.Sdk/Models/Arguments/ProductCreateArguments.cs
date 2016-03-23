using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ProductCreateArguments
    {
        public bool? Active { get; set; }

        public bool? Shippable { get; set; }

        /// <summary>
        /// A list of up to 5 alphanumeric attributes that each SKU can provide values for (e.g. ["color", "size"]).
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// An array of Connect application names or identifiers that should not be able to order the SKUs for this product.
        /// </summary>
        public List<string> DeactivateOn { get; set; }

        /// <summary>
        /// A list of up to 8 URLs of images for this product, meant to be displayable to the customer.
        /// </summary>
        public List<string> Images { get; set; }

        [ChildModel]
        public PackageDimensions PackageDimensions { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The identifier for the product. Must be unique. If not provided, an identifier will be randomly generated.
        /// </summary>
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}