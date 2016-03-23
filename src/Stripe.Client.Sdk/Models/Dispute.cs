using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;
using System.Collections.Generic;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Dispute : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public bool LiveMode { get; set; }

        public int? Amount { get; set; }

        [JsonIgnore]
        public string ChargeId { get; set; }

        [JsonIgnore]
        public Charge ChargeModel { get; set; }

        public object Charge
        {
            set { Expandable<Charge>.Deserialize(value, s => ChargeId = s, o => ChargeModel = o); }
        }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Created { get; set; }

        public string Currency { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        public List<BalanceTransaction> BalanceTransactions { get; set; }

        public bool IsChargeRefundable { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}
