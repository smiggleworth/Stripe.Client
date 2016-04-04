using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class Charge : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public bool LiveMode { get; set; }

        public int Amount { get; set; }

        public bool? Captured { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public bool Paid { get; set; }

        public bool Refunded { get; set; }

        public Pagination<Refund> Refunds { get; set; }

        public Card Source { get; set; }

        public string Status { get; set; }

        public int AmountRefunded { get; set; }

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
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        public string Description { get; set; }

        public string StatementDescriptor { get; set; }

        public Dispute Dispute { get; set; }

        public string FailureCode { get; set; }

        public string FailureMessage { get; set; }

        [JsonIgnore]
        public string InvoiceId { get; set; }

        [JsonIgnore]
        public Invoice InvoiceModel { get; set; }

        public object Invoice
        {
            set { Expandable<Invoice>.Deserialize(value, s => InvoiceId = s, o => InvoiceModel = o); }
        }

        public Dictionary<string, string> Metadata { get; set; }

        public string ReceiptEmail { get; set; }

        public string ReceiptNumber { get; set; }
    }
}