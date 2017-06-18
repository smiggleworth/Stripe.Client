using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Invoice : IStripeModel
    {
        public string Object { get; set; }

        public bool LiveMode { get; set; }

        public int AmountDue { get; set; }

        public int AttemptCount { get; set; }

        public bool Attempted { get; set; }

        public bool? Closed { get; set; }

        public string Currency { get; set; }

        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? Date { get; set; }

        public bool? Forgiven { get; set; }

        public Pagination<InvoiceLineItem> Lines { get; set; }

        public bool Paid { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime PeriodEnd { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime PeriodStart { get; set; }

        public int StartingBalance { get; set; }

        public int Subtotal { get; set; }

        public int Total { get; set; }

        public int? ApplicationFee { get; set; }

        [JsonIgnore]
        public string ChargeId { get; set; }

        [JsonIgnore]
        public Charge ChargeModel { get; set; }

        public object Charge
        {
            set { Expandable<Charge>.Deserialize(value, s => ChargeId = s, o => ChargeModel = o); }
        }

        public string Description { get; set; }

        public Discount Discount { get; set; }

        public int? EndingBalance { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? NextPaymentAttempt { get; set; }

        public string ReceiptNumber { get; set; }

        public string StatementDescriptor { get; set; }

        public string Subscription { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? WebhooksDeliveredAt { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public int? Tax { get; set; }

        public decimal? TaxPercent { get; set; }
        public string Id { get; set; }
    }
}