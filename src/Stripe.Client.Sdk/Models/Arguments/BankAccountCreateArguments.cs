using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class BankAccountCreateArguments : IPaymentTypeArguments
    {
        [Required]
        public string Object => "bank_account";

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Currency { get; set; }

        public string AccountHolderName { get; set; }

        public string AccountHolderType { get; set; }

        public string RoutingNumber { get; set; }
    }
}