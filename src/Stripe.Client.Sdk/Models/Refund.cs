using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Refund : IStripeModel
    {
        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
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

        [JsonIgnore]
        public string ChargeId { get; set; }

        [JsonIgnore]
        public Charge ChargeModel { get; set; }

        public object Charge
        {
            set { Expandable<Charge>.Deserialize(value, s => ChargeId = s, o => ChargeModel = o); }
        }

        public Dictionary<string, string> Metadata { get; set; }

        public string Reason { get; set; }

        public string ReceiptNumber { get; set; }

        public string Description { get; set; }
        public string Id { get; set; }
    }
}