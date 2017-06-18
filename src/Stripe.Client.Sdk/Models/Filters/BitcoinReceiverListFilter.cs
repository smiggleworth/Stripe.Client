namespace Stripe.Client.Sdk.Models.Filters
{
    public class BitcoinReceiverListFilter : ListFilter
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BitcoinReceiverListFilter" /> is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool? Active { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BitcoinReceiverListFilter" /> is filled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if filled; otherwise, <c>false</c>.
        /// </value>
        public bool? Filled { get; set; }
    }
}