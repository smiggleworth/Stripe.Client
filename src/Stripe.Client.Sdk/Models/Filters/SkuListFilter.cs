using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class SkuListFilter : ListFilter
    {
        public bool? Active { get; set; }

        /// <summary>
        ///     List of Sku Ids
        /// </summary>
        public List<string> Ids { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

        public bool? InStock { get; set; }

        /// <summary>
        ///     The OrderId of the product whose SKUs will be retrieved.
        /// </summary>
        public string Product { get; set; }
    }
}