using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;

namespace Stripe.Client.Sdk.Models
{
    public class AccountVerification
    {
        public string DisabledReason { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime DueBy { get; set; }

        public string[] FieldsNeeded { get; set; }
    }
}