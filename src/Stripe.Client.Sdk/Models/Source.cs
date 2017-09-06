using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class Source : IStripeModel
    {
        /// <summary>
        ///     String representing the object’s type. Objects of the same type share the same value. (value is "source")
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        ///     Amount associated with the source.This is the amount for which the source will be chargeable once ready. Required
        ///     for single_use sources.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        ///     The client secret of the source.Used for client-side retrieval using a publishable key.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        ///     Information related to the code verification flow. Present if the source is authenticated by a verification code
        ///     (flow is code_verification)
        /// </summary>
        public CodeVerification CodeVerification { get; set; }

        /// <summary>
        ///     Time at which the object was created.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        ///     Three-letter ISO code for the currency associated with the source.This is the currency for which the source will be
        ///     chargeable once ready. Required for single_use sources.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     The authentication flow of the source.flow is one of redirect, receiver, code_verification, none.
        /// </summary>
        public string Flow { get; set; }

        /// <summary>
        ///     Flag indicating whether the object exists in live mode or test mode.
        /// </summary>
        private bool Livemode { get; set; }

        /// <summary>
        ///     Set of key/value pairs that you can attach to an object. It can be useful for storing additional information about
        ///     the object in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     Information about the owner of the payment instrument that may be used or required by particular source types.
        /// </summary>
        public Owner Owner { get; set; }

        /// <summary>
        ///     Information related to the receiver flow. Present if the source is a receiver (flow is receiver).
        /// </summary>
        public Receiver Receiver { get; set; }

        /// <summary>
        ///     Information related to the redirect flow.Present if the source is authenticated by a redirect (flow is redirect).
        /// </summary>
        public Redirect Redirect { get; set; }

        /// <summary>
        ///     The status of the charge, one of canceled, chargeable, consumed, failed, or pending.Only chargeable source objects
        ///     can be used to create a charge.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     The type of the source.The type is a payment method, one of card, three_d_secure, giropay, sepa_debit, ideal,
        ///     sofort, or bancontact.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Either reusable or single_use.Whether this source should be reusable or not. Some source types may or may not be
        ///     reusable by construction, while other may leave the option at creation.If an incompatible value is passed, an error
        ///     will be returned.
        /// </summary>
        public string Usage { get; set; }

        /// <summary>
        /// </summary>
        public string Id { get; set; }
    }
}