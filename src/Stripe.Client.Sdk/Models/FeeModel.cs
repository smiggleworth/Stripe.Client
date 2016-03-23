namespace Stripe.Client.Sdk.Models
{
    public class FeeModel
    {
        public int Amount { get; set; }

        public string Currency { get; set; }

        public string Type { get; set; }

        public string Application { get; set; }

        public string Description { get; set; }
    }
}