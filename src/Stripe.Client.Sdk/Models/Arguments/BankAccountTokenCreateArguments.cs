using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class BankAccountTokenCreateArguments
    {
        [ChildModel]
        public BankAccountTokenArguments BankAccount { get; set; }

        public string Customer { get; set; }
    }
}