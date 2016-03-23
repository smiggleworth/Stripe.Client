using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class TransferCreateArguments
    {
        public int Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Destination { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string SourceTransaction { get; set; }

        public string StatementDescriptor { get; set; }

        public string SourceType { get; set; }
    }
}