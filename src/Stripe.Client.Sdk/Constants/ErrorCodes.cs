namespace Stripe.Client.Sdk.Constants
{
    public static class ErrorCodes
    {
        /// <summary>
        ///     The card number is not a valid credit card number.
        /// </summary>
        public const string InvalidNumber = "invalid_number";

        /// <summary>
        ///     The card's expiration month is invalid.
        /// </summary>
        public const string InvalidExpiryMonth = "invalid_expiry_month";

        /// <summary>
        ///     The card's expiration year is invalid.
        /// </summary>
        public const string InvalidExpiryYear = "invalid_expiry_year";

        /// <summary>
        ///     The card's security code is invalid.
        /// </summary>
        public const string InvalidCvc = "invalid_cvc";

        /// <summary>
        ///     The card's swipe data is invalid.
        /// </summary>
        public const string InvalidSwipeData = "invalid_swipe_data";

        /// <summary>
        ///     The card number is incorrect.
        /// </summary>
        public const string IncorrectNumber = "incorrect_number";

        /// <summary>
        ///     The card has expired.
        /// </summary>
        public const string ExpiredCard = "expired_card";

        /// <summary>
        ///     The card's security code is incorrect.
        /// </summary>
        public const string IncorrectCvc = "incorrect_cvc";

        /// <summary>
        ///     The card's zip code failed validation.
        /// </summary>
        public const string IncorrectZip = "incorrect_zip";

        /// <summary>
        ///     The card was declined.
        /// </summary>
        public const string CardDeclined = "card_declined";

        /// <summary>
        ///     There is no card on a customer that is being charged.
        /// </summary>
        public const string Missing = "missing";

        /// <summary>
        ///     An error occurred while processing the card.
        /// </summary>
        public const string ProcessingError = "processing_error";
    }
}