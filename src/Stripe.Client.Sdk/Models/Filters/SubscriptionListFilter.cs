namespace Stripe.Client.Sdk.Models.Filters
{
    public class SubscriptionListFilter : ListFilter
    {
        /// <summary>
        ///     The ID of the customer whose subscriptions will be retrieved.
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        ///     The ID of the plan whose subscriptions will be retrieved.
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        ///     The status of the subscriptions to retrieve. One of: trialing, active, past_due, unpaid, canceled, or all. Passing
        ///     in a value of canceled will return all canceled subscriptions, including those belonging to deleted customers.
        ///     Passing in a value of all will return subscriptions of all statuses.
        /// </summary>
        public string Status { get; set; }
    }
}