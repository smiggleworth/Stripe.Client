using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public abstract class CardUpdateArguments
    {
        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressZip { get; set; }

        public string AddressCountry { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}