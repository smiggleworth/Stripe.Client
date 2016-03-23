using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class BankAccount : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public string Account { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public bool DefaultForCurrency { get; set; }

        public string Last4 { get; set; }

        public string Status { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string BankName { get; set; }

        public string Fingerprint { get; set; }

        public string RoutingNumber { get; set; }
    }
}