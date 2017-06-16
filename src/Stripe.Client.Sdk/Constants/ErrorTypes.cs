namespace Stripe.Client.Sdk.Constants
{
    public static class ErrorTypes
    {
        /// <summary>
        ///     Failure to connect to Stripe's API.
        /// </summary>
        public const string ApiConnectionError = "api_connection_error";

        /// <summary>
        ///     API errors cover any other type of problem (e.g., a temporary problem with Stripe's servers) and are extremely
        ///     uncommon.
        /// </summary>
        public const string ApiError = "api_error";

        /// <summary>
        ///     Failure to properly authenticate yourself in the request.
        /// </summary>
        public const string AuthenticationError = "authentication_error";

        /// <summary>
        ///     Card errors are the most common type of error you should expect to handle. They result when the user enters a card
        ///     that can't be charged for some reason.
        /// </summary>
        public const string CardError = "card_error";

        /// <summary>
        ///     Invalid request errors arise when your request has invalid parameters.
        /// </summary>
        public const string InvalidRequestError = "invalid_request_error";

        /// <summary>
        ///     Too many requests hit the API too quickly.
        /// </summary>
        public const string RateLimitError = "rate_limit_error";

        /// <summary>
        ///     Errors triggered by our client-side libraries when failing to validate fields (e.g., when a card number or
        ///     expiration date is invalid or incomplete).
        /// </summary>
        public const string ValidationError = "validation_error";
    }
}