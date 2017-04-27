using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountCreateArguments
    {
        public string Country { get; set; }

        public string Email { get; set; }

        public bool? Managed { get; set; }
    }
}