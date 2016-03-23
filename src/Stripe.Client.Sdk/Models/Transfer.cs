using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Transfer : IStripeModel
    {
        public string Object { get; set; }

        public int Amount { get; set; }

        public int AmountReversed { get; set; }

        public string ApplicationFee { get; set; }

        [JsonIgnore]
        public string BalanceTransactionId { get; set; }

        [JsonIgnore]
        public BalanceTransaction BalanceTransactionModel { get; set; }

        internal object BalanceTransaction
        {
            set
            {
                Expandable<BalanceTransaction>.Deserialize(value, s => BalanceTransactionId = s,
                    o => BalanceTransaction = o);
            }
        }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Date { get; set; }


        public string Description { get; set; }

        // todo : split into different models
        public object Destination { get; set; }

        public object DestinationPayment { get; set; }

        public string FailureCode { get; set; }

        public string FailureMessage { get; set; }

        public bool LiveMode { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public Pagination<TransferReversal> Reversals { get; set; }

        public bool Rerversed { get; set; }

        public object SourceTransaction { get; set; }

        public string SourceType { get; set; }

        public string StatementDescriptor { get; set; }

        public string Type { get; set; }
        public string Id { get; set; }
    }
}