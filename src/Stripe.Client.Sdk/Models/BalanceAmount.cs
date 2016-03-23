using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class BalanceAmount
    {
        public int Amount { get; set; }

        public string Currency { get; set; }

        public Dictionary<string, string> SourceTypes { get; set; }
    }
}