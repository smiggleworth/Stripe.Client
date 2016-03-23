using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;

namespace Stripe.Client.Sdk.Models
{
    public class FileUpload : IStripeModel
    {
        public string Id { get; set; }

        public string Object { get; set; }

        [JsonConverter(typeof (EpochConverter))]
        public DateTime Created { get; set; }

        public string Purpose { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}