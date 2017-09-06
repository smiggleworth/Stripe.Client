using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class OrderUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string OrderId { get; set; }

        public string Coupon { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string SelectedShippingMethod { get; set; }

        public string Status { get; set; }
    }
}