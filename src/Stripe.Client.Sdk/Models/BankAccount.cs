using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class BankAccount : IStripeModel
    {
        public string Object { get; set; }

        public string Account { get; set; }

        /// <summary>
        ///     The name of the person or business that owns the bank account.
        /// </summary>
        public string AccountHolderName { get; set; }

        /// <summary>
        ///     The type of entity that holds the account. This can be either individual or company.
        /// </summary>
        public string AccountHolderType { get; set; }

        /// <summary>
        ///     Name of the bank associated with the routing number,
        /// </summary>
        public string BankName { get; set; }

        public string Country { get; set; }

        /// <summary>
        ///     Three-letter ISO code for the currency paid out to the bank account.
        /// </summary>
        public string Currency { get; set; }

        public string Customer { get; set; }

        public bool DefaultForCurrency { get; set; }

        /// <summary>
        ///     Uniquely identifies this particular bank account. You can use this attribute to check whether two bank accounts are
        ///     the same.
        /// </summary>
        public string Fingerprint { get; set; }

        public string Last4 { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string RoutingNumber { get; set; }

        /// <summary>
        ///     Possible values are new, validated, verified, verification_failed, or errored. A bank account that hasn’t had any
        ///     activity or validation performed is new. If Stripe can determine that the bank account exists, its status will be
        ///     validated. Note that there often isn’t enough information to know (e.g. for smaller credit unions), and the
        ///     validation is not always run. If customer bank account verification has succeeded, the bank account status will be
        ///     verified. If the verification failed for any reason, such as microdeposit failure, the status will be
        ///     verification_failed. If a transfer sent to this bank account fails, we’ll set the status to errored and will not
        ///     continue to send transfers until the bank details are updated.
        /// </summary>
        public string Status { get; set; }

        public string Id { get; set; }
    }
}