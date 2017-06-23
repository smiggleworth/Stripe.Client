namespace Stripe.Client.Sdk.Models
{
    public class Receiver
    {
        /// <summary>
        ///     The address of the receiver source.This is the value that should be communicated to the customer to send their
        ///     funds to.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     The total amount that was charged by you.The amount charged is expressed in the source’s currency.
        /// </summary>
        public int AmountCharged { get; set; }


        /// <summary>
        ///     The total amount received by the receiver source. amount_received = amount_returned + amount_charged is true at all
        ///     time.The amount received is expressed in the source’s currency.
        /// </summary>
        public int AmountReceived { get; set; }

        /// <summary>
        ///     The total amount that was returned to the customer.The amount returned is expressed in the source’s currency.
        /// </summary>
        public int AmountReturned { get; set; }
    }
}