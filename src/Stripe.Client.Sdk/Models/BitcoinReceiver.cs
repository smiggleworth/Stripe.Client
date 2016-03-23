using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class BitcoinReceiver
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public string Active { get; set; }
        public int Amount { get; set; }
        public int AmountReceived { get; set; }
        public int BitcoinAmount { get; set; }
        public int BitcoinAmountReceived { get; set; }
        public string BitcoinUri { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool Filled { get; set; }
        public string InboundAddress { get; set; }
        public bool Livemode { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string Payment { get; set; }
        public string RefundAddress { get; set; }
        public Pagination<Transaction> Transactions { get; set; }
        public bool UncapturedFunds { get; set; }
        public bool UsedForPayment { get; set; }
    }
}