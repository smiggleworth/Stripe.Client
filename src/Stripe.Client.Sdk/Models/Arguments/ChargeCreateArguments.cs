using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ChargeCreateArguments
    {
        public int Amount { get; set; }

        public int? ApplicationFee { get; set; }

        public bool? Capture { get; set; }

        [Required]
        public string Currency { get; set; }

        public string Customer { get; set; }

        public string Description { get; set; }

        public string Destination { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string ReceiptEmail { get; set; }

        [ChildModel]
        public ShippingArguments Shipping { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public CardCreateArguments CardCreateArguments { get; set; }

        [ChildModel]
        public object Source
        {
            get { return !string.IsNullOrWhiteSpace(CardToken) ? CardToken : (object)CardCreateArguments; }
        }

        public string StatementDescriptor { get; set; }
    }
}