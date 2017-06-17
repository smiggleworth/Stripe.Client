using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountCreateArguments
    {
        /// <summary>
        /// The country the account holder resides in or that the business is legally established in. For example, if you are in the United States and the business you're creating an account for is legally represented in Canada, you would use "CA" as the country for the account being created. This should be an ISO 3166-1 alpha-2 country code.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The email address of the account holder. For Standard accounts, Stripe will email your user with instructions for how to set up their account. For Custom accounts, this is only to make the account easier to identify to you: Stripe will never directly reach out to your users.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Whether you'd like to create a Custom or Standard account. Custom accounts have extra parameters available to them, and require that you, the platform, handle all communication with the account holder. Standard accounts are normal Stripe accounts: Stripe will email the account holder to setup a username and password, and handle all account management directly with them. Possible values are custom and standard.
        /// </summary>
        public string Type { get; set; }
    }
}