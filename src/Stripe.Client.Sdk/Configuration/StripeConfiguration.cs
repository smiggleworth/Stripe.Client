namespace Stripe.Client.Sdk.Configuration
{
    public class StripeConfiguration : IStripeConfiguration
    {
        public string SecretKey { get; set; }
        public string PublishableKey { get; set; }
        public string AccountId { get; set; }
    }
}