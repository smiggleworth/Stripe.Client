using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class InventoryArguments
    {
        /// <summary>
        /// Inventory type. Possible values are finite, bucket (not quantified), and infinite.
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// The count of inventory available. Required if type is finite.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// An indicator of the inventory available. Possible values are in_stock, limited, and out_of_stock. Will be present if and only if type is bucket.
        /// </summary>
        public string Value { get; set; }
    }
}