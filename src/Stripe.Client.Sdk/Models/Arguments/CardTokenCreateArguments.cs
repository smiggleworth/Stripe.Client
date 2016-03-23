using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CardTokenCreateArguments
    {
        public string Customer { get; set; }

        [ChildModel]
        public CardCreateArguments Card { get; set; }
    }
}