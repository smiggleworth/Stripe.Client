namespace Stripe.Client.Sdk.Models
{
    public class OAuthToken
    {
        public string TokenType { get; set; }

        public string Scope { get; set; }

        public bool LiveMode { get; set; }

        public string StripeUserId { get; set; }

        public string StripePublishableKey { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

        public string Error { get; set; }

        public string ErrorDescription { get; set; }
    }
}