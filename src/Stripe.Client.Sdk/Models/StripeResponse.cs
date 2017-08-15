namespace Stripe.Client.Sdk.Models
{
    public class StripeResponse<T>
    {
        public T Model { get; set; }

        public StripeError Error { get; set; }

        public bool Success => Error == null;
    }
}