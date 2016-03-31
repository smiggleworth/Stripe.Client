using System.Configuration;

namespace Stripe.Client.Sdk.Configuration
{
    public class AppSettingsConfiguration : IStripeConfiguration
    {
        /// <summary>
        ///     Gets the secret key from AppSetting StripeSecretKey.
        /// </summary>
        /// <value>
        ///     The secret key.
        /// </value>
        public string SecretKey => ConfigurationManager.AppSettings["Stripe.SecretKey"];

        /// <summary>
        ///     Gets the publishable key from AppSetting StripePublishableKey.
        /// </summary>
        /// <value>
        ///     The publishable key.
        /// </value>
        public string PublishableKey => ConfigurationManager.AppSettings["Stripe.PublishableKey"];

        /// <summary>
        ///     Gets the account id from AppSetting StripeAccountId.
        /// </summary>
        /// <value>
        ///     The account identifier.
        /// </value>
        public string AccountId => ConfigurationManager.AppSettings["Stripe.AccountId"];
    }
}