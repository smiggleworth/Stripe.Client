namespace Stripe.Client.Sdk.Constants
{
    public static class RefundReason
    {
        public const string Unknown = null;
        public const string Duplicate = "duplicate";
        public const string Fradulent = "fraudulent";
        public const string RequestedByCustomer = "requested_by_customer";
    }
}