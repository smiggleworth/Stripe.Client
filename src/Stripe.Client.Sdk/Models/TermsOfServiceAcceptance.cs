using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using System;

namespace Stripe.Client.Sdk.Models
{
    public class TermsOfServiceAcceptance
    {
        [JsonConverter(typeof(EpochConverter))]
        public DateTime Date { get; set; }

        public string Ip { get; set; }

        public string UserAgent { get; set; }
    }
}