using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class BankAccountTokenArguments
    {
        public string AccountHolderType { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Currency { get; set; }

        public string AccountHolderName { get; set; }

        public string RoutingNumber { get; set; }
    }
}