namespace Stripe.Client.Sdk.Models
{
    public class StripeError
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public string Code { get; set; }

        public string Param { get; set; }

        public string Error { get; set; }

        public string ErrorDescription { get; set; }

        public string Charge { get; set; }

        public string DeclineCode { get; set; }
    }
}
