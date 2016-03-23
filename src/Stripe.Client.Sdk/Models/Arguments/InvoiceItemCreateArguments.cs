using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class InvoiceItemCreateArguments
    {
        [Required]
        public string Customer { get; set; }

        public int Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        public string Invoice { get; set; }

        public string Subscription { get; set; }

        public string Description { get; set; }

        public bool? Discountable { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}