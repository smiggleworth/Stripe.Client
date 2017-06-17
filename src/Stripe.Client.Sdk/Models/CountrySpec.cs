using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class CountrySpec : IStripeModel
    {
        /// <summary>
        /// Unique identifier for the object. Represented as the ISO country code for this country.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// String representing the object’s type.Objects of the same type share the same value. ( value is "country_spec")
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        ///             The default currency for this country.This applies to both payment methods and bank accounts.
        /// </summary>
        public string DefaultCurrency { get; set; }

        /// <summary>
        ///  Currencies that can be accepted in the specific country (for transfers). Key = Country, Value = array of currencies
        /// </summary>
        public IDictionary<string, string[]> SupportedBankAccountCurrencies { get; set; }


        /// <summary>
        /// Currencies that can be accepted in the specified country(for payments).
        /// </summary>
        public string[] SupportedPaymentCurrencies { get; set; }

        /// <summary>
        ///         Payment methods available in the specified country.You will need to enable bitcoin and ACH payments on your account for those methods to appear in this list.The stripe payment method refers to charging through your platform.

        /// </summary>
        public string[] SupportedPaymentMethods { get; set; }

        /// <summary>
        /// Lists the types of verification data needed to keep an account open.Includes ‘minimum’ fields, which every account must eventually provide, as well as a ‘additional’ fields, which are only required for some merchants.
        /// </summary>
        public VerificationField VerificationFields { get; set; }

        public CountrySpec()
        {

        }
    }
}