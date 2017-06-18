using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class BalanceTransaction : IStripeModel
    {


        public string Object { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime AvailableOn { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public string Currency { get; set; }

        public int Fee { get; set; }

        public List<FeeModel> FeeDetails { get; set; }

        public int Net { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// Transaction type: adjustment, application_fee, application_fee_refund, charge, payment, payment_failure_refund, payment_refund, refund, transfer, transfer_refund, payout, payout_cancel, payout_failure, or validation.
        /// </summary>
        public string Type { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
        public string Id { get; set; }
    }
}