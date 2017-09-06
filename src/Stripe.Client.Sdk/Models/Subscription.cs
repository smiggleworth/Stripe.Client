using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Subscription : IStripeModel
    {
        /// <summary>
        ///     String representing the object’s type. Objects of the same type share the same value. (value is "subscription")
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        ///     If the subscription has been canceled with the at_period_end flag set to true, cancel_at_period_end on the
        ///     subscription will be true. You can use this attribute to determine whether a subscription that has a status of
        ///     active is scheduled to be canceled at the end of the current period.
        /// </summary>
        public bool CancelAtPeriodEnd { get; set; }

        /// <summary>
        ///     If the subscription has been canceled, the date of that cancellation. If the subscription was canceled with
        ///     cancel_at_period_end, canceled_at will still reflect the date of the initial cancellation request, not the end of
        ///     the subscription period when the subscription is automatically moved to a canceled state.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? CanceledAt { get; set; }

        /// <summary>
        ///     ID of the customer who owns the subscription.
        /// </summary>
        [JsonIgnore]
        public string CustomerId { get; set; }

        /// <summary>
        ///     The customer who owns the subscription.
        /// </summary>
        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        /// <summary>
        ///     Hash describing the plan the customer is subscribed to
        /// </summary>
        public Plan Plan { get; set; }

        /// <summary>
        ///     The quantity of the plan to which the customer should be subscribed. For example, if your plan is $10/user/month,
        ///     and your customer has 5 users, you could pass 5 as the quantity to have the customer charged $50 (5 x $10) monthly.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        ///     Date the most recent update to this subscription started.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Start { get; set; }

        /// <summary>
        ///     Possible values are trialing, active, past_due, canceled, or unpaid. A subscription still in its trial period is
        ///     trialing and moves to active when the trial period is over. When payment to renew the subscription fails, the
        ///     subscription becomes past_due. After Stripe has exhausted all payment retry attempts, the subscription ends up with
        ///     a status of either canceled or unpaid depending on your retry settings. Note that when a subscription has a status
        ///     of unpaid, no subsequent invoices will be attempted (invoices will be created, but then immediately automatically
        ///     closed. Additionally, updating customer card details will not lead to Stripe retrying the latest invoice.). After
        ///     receiving updated card details from a customer, you may choose to reopen and pay their closed invoices.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     A non-negative decimal (with at most two decimal places) between 0 and 100. This represents the percentage of the
        ///     subscription invoice subtotal that will be transferred to the application owner’s Stripe account.
        /// </summary>
        public decimal? ApplicationFeePercent { get; set; }

        /// <summary>
        ///     If provided, each invoice created by this subscription will apply the tax rate, increasing the amount billed to the
        ///     customer.
        /// </summary>
        public decimal? TaxPercent { get; set; }


        /// <summary>
        ///     End of the current period that the subscription has been invoiced for. At the end of this period, a new invoice
        ///     will be created.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? CurrentPeriodEnd { get; set; }

        /// <summary>
        ///     Start of the current period that the subscription has been invoiced fo
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? CurrentPeriodStart { get; set; }

        /// <summary>
        ///     Describes the current discount applied to this subscription, if there is one. When billing, a discount applied to a
        ///     subscription overrides a discount applied on a customer-wide basis.
        /// </summary>
        public Discount Discount { get; set; }

        /// <summary>
        ///     If the subscription has ended (either because it was canceled or because the customer was switched to a
        ///     subscription to a new plan), the date the subscription ended.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? EndedAt { get; set; }

        /// <summary>
        ///     Set of key/value pairs that you can attach to an object. It can be useful for storing additional information about
        ///     the object in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     If the subscription has a trial, the end of that trial.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialEnd { get; set; }

        /// <summary>
        ///     If the subscription has a trial, the beginning of that trial.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime? TrialStart { get; set; }

        /// <summary>
        ///     Flag indicating whether the object exists in live mode or test mode.
        /// </summary>
        public bool Livemode { get; set; }

        /// <summary>
        ///     Unique identifier for the object.
        /// </summary>
        public string Id { get; set; }
    }
}