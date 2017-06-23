namespace Stripe.Client.Sdk.Models
{
    public class Redirect
    {
        /// <summary>
        ///     The URL you provide to redirect the customer to after they authenticated their payment.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     The status of the redirect, either pending, succeeded or failed.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     The URL provided to you to redirect a customer to as part of a redirect authentication flow.
        /// </summary>
        public string Url { get; set; }
    }
}