using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class ProductListFilter : ListFilter
    {
        public bool? Active { get; set; }

        /// <summary>
        ///     List of Product Ids
        /// </summary>
        public List<string> Ids { get; set; }

        public bool? Shippable { get; set; }

        public string Url { get; set; }
    }
}