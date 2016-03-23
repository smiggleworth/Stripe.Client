using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Object
        {
            get { return "product"; }
        }

        public bool Active { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        public string Caption { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        public List<string> DeactivateOn { get; set; }

        public string Description { get; set; }

        public List<string> Images { get; set; }

        public bool Livemode { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string Name { get; set; }

        public PackageDimensions PackageDimensions { get; set; }

        public bool Shippable { get; set; }

        public List<string> Skus { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime Updated { get; set; }

        public string Url { get; set; }
    }
}