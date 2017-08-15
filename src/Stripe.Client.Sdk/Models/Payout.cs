using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Payout
    {
        /// <summary>
        ///     Unique identifier for the object.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     String representing the object’s type.Objects of the same type share the same value. (value is "payout")
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        ///     Amount (in cents) to be transferred to your bank account or debit card.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        ///     Date the payout is expected to arrive in the bank. This factors in delays like weekends or bank holidays.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        ///     ID of the balance transaction that describes the impact of this payout on your account balance.
        /// </summary>
        [JsonIgnore]
        public string BalanceTransactionId { get; set; }

        /// <summary>
        ///     Balance transaction that describes the impact of this payout on your account balance.
        /// </summary>
        [JsonIgnore]
        public BalanceTransaction BalanceTransactionModel { get; set; }

        public object BalanceTransaction
        {
            set
            {
                Expandable<BalanceTransaction>.Deserialize(value, s => BalanceTransactionId = s, o => BalanceTransactionModel = o);
            }
        }

        /// <summary>
        ///     Time at which the object was created.Measured in seconds since the Unix epoch.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        ///     Three-letter ISO currency code, in lowercase.Must be a supported currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        ///     An arbitrary string attached to the object. Often useful for displaying to users.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     ID of the bank account or card the payout was sent to.
        /// </summary>
        public string DestinationId { get; set; }

        /// <summary>
        ///     The bank account or card the payout was sent to.
        /// </summary>
        public Source DestinationModel { get; set; }

        public object Destination
        {
            set { Expandable<Source>.Deserialize(value, s => DestinationId = s, o => DestinationModel = o); }
        }

        /// <summary>
        ///     If the payout failed or was canceled, this will be the ID of the balance transaction that reversed the initial
        ///     balance transaction, and puts the funds from the failed payout back in your balance.
        /// </summary>
        public string FailureBalanceTransactionId { get; set; }

        /// <summary>
        ///     If the payout failed or was canceled, this will be the balance transaction that reversed the initial balance
        ///     transaction, and puts the funds from the failed payout back in your balance.
        /// </summary>
        public BalanceTransaction FailureBalanceTransactionModel { get; set; }

        public object FailureBalanceTransaction
        {
            set { Expandable<BalanceTransaction>.Deserialize(value, s => FailureBalanceTransactionId = s, o => FailureBalanceTransactionModel = o); }
        }

        /// <summary>
        ///     Error code explaining reason for payout failure if available.See Types of payout failures for a list of failure
        ///     codes.
        /// </summary>
        public string FailureCode { get; set; }

        /// <summary>
        ///     Message to user further explaining reason for payout failure if available.
        /// </summary>
        public string FailureMessage { get; set; }

        /// <summary>
        ///     Flag indicating whether the object exists in live mode or test mode.
        /// </summary>
        public bool Livemode { get; set; }

        /// <summary>
        ///     Set of key/value pairs that you can attach to an object. It can be useful for storing additional information about
        ///     the object in a structured format.
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        ///     The method used to send this payout, which can be standard or instant.instant is only supported for payouts to
        ///     debit cards. (See Instant payouts for marketplaces for more information.)
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        ///     The source balance this payout came from.One of card, bank_account, bitcoin_receiver, or alipay_account.
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        ///     Extra information about a payout to be displayed on the user’s bank statement.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        ///     Current status of the payout (paid, pending, in_transit, canceled or failed). A payout will be pending until it is
        ///     submitted to the bank, at which point it becomes in_transit.It will then change to paid if the transaction goes
        ///     through.If it does not go through successfully, its status will change to failed or canceled.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Can be bank_account or card.
        /// </summary>
        public string Type { get; set; }
    }
}