using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PackageDimensionArguments
    {
        /// <summary>
        /// Height, in inches. Maximum precision is 2 decimal places.
        /// </summary>
        [Required]
        public decimal Height { get; set; }

        /// <summary>
        /// Length, in inches. Maximum precision is 2 decimal places.
        /// </summary>
        [Required]
        public decimal Length { get; set; }

        /// <summary>
        /// Weight, in ounce. Maximum precision is 2 decimal places.
        /// </summary>
        [Required]
        public decimal Weight { get; set; }

        /// <summary>
        /// Width, in inches. Maximum precision is 2 decimal places.
        /// </summary>
        [Required]
        public decimal Width { get; set; }

    }
}