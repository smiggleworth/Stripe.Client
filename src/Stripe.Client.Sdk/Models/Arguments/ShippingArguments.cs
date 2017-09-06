using System.ComponentModel.DataAnnotations;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ShippingArguments
    {
        [ChildModel]
        [Required]
        public AddressArguments Address { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}