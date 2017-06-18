using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class OrderCreateArguments
    {
        [Required]
        public string Currency { get; set; }

        public string Coupon { get; set; }

        public string Customer { get; set; }

        public string Email { get; set; }

        [ChildModel]
        public List<OrderItemCreateArguments> Items { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [ChildModel]
        public ShippingArguments Shipping { get; set; }
    }
}