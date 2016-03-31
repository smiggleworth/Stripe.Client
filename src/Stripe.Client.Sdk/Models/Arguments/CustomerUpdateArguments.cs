using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CustomerUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string CustomerId { get; set; }

        public int? AccountBalance { get; set; }

        public string Coupon { get; set; }

        public string DefaultSource { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Source => !string.IsNullOrWhiteSpace(CardToken) ? (object)CardToken : CardCreateArguments;

        [ChildModel]
        public ShippingArguments Shipping { get; set; }
    }
}