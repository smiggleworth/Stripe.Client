using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class UpcomingInvoiceArguments 
    {
        public string Customer { get; set; }

        public string Subscription { get; set; }

        public string SubscriptionPlan { get; set; }

        public bool? SubscriptionProrate { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? SubscriptionProrationDate { get; set; }

        public string SubscriptionQuantity { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime? SubscriptionTrialEnd { get; set; }
    }
}