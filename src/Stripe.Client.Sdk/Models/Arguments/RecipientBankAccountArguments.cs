using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class RecipientBankAccountArguments
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string RoutingNumber { get; set; }

        [Required]
        public string AccountNumber { get; set; }
    }
}