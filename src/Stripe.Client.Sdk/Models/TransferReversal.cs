using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class TransferReversal : IStripeModel
    {
        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        [JsonIgnore]
        public string BalanceTransactionId { get; set; }

        [JsonIgnore]
        public BalanceTransaction BalanceTransactionModel { get; set; }

        public object BalanceTransaction
        {
            set
            {
                Expandable<BalanceTransaction>.Deserialize(value, s => BalanceTransactionId = s,
                    o => BalanceTransactionModel = o);
            }
        }

        public Dictionary<string, string> Metadata { get; set; }

        [JsonIgnore]
        public string TransferId { get; set; }

        [JsonIgnore]
        public Transfer TransferModel { get; set; }

        public object Transfer
        {
            set { Expandable<Transfer>.Deserialize(value, s => TransferId = s, o => TransferModel = o); }
        }

        public string Id { get; set; }
    }
}