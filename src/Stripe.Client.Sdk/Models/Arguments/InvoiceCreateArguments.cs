using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class InvoiceCreateArguments
    {
        [Required]
        public string Customer { get; set; }

        public int? ApplicationFee { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string StatementDescriptor { get; set; }

        public string Subscription { get; set; }

        public decimal? TaxPercent { get; set; }
    }
}