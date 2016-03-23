using Newtonsoft.Json;
using System.Collections.Generic;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Card : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        public string Brand { get; set; }

        public int ExpMonth { get; set; }

        public int ExpYear { get; set; }

        public string Funding { get; set; }

        public string Last4 { get; set; }

        public string AddressCity { get; set; }

        public string AddressCountry { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine1Check { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressState { get; set; }

        public string AddressZip { get; set; }

        public string AddressZipCheck { get; set; }

        public string Country { get; set; }

        public string CvcCheck { get; set; }

        public string DynamicLast4 { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string Name { get; set; }

        public string TokenizationMethod { get; set; }

        public string Fingerprint { get; set; }

        [JsonIgnore]
        public string RecipientId { get; set; }

        [JsonIgnore]
        public Recipient RecipientModel { get; set; }

        public object Recipient
        {
            set { Expandable<Recipient>.Deserialize(value, s => RecipientId = s, o => RecipientModel = o); }
        }

        [JsonIgnore]
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer CustomerModel { get; set; }

        public object Customer
        {
            set { Expandable<Customer>.Deserialize(value, s => CustomerId = s, o => CustomerModel = o); }
        }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public Account AccountModel { get; set; }

        public object Account
        {
            set { Expandable<Account>.Deserialize(value, s => AccountId = s, o => AccountModel = o); }
        }

        public string Currency { get; set; }

        public bool DefaultForCurrency { get; set; }
    }
}