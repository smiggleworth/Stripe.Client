namespace Stripe.Client.Sdk.Models
{
    public class StripeResponse<TModel>
    {
        public TModel Model { get; set; }

        public StripeError Error { get; set; }

        public bool Success
        {
            get { return Error == null; }
        }
    }
}
