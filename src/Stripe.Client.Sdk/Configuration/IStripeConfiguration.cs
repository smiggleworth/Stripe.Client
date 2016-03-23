namespace Stripe.Client.Sdk.Configuration
{
    public interface IStripeConfiguration
    {
        string SecretKey { get; }
        string PublishableKey { get; }
        string AccountId { get; }
    }
}