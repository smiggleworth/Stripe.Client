using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class Pagination<T>
    {
        public string Object { get; set; }

        public List<T> Data { get; set; }

        public bool HasMore { get; set; }

        public int TotalCount { get; set; }

        public string Url { get; set; }
    }
}