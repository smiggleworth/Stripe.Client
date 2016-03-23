namespace Stripe.Client.Sdk.Models.Arguments
{
    public class OrderItemCreateArguments
    {
        public int Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The OrderId of the SKU being ordered.
        /// </summary>
        public string Parent { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }
    }
}