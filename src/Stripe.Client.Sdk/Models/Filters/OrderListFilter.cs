using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class OrderListFilter : ListFilter
    {
        [JsonIgnore]
        public DateTime? CreatedDateTime { get; set; }

        [JsonIgnore]
        public DateFilter CreatedFilter { get; set; }

        [ChildModel]
        public object Created
        {
            get { return CreatedDateTime.HasValue ? (object)CreatedDateTime.Value.ToEpoch() : CreatedFilter; }
        }


        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the Order Ids.
        /// </summary>
        /// <value>
        /// The ids.
        /// </value>
        public List<string> Ids { get; set; }

        [ChildModel]
        public StatusTransitionFilter StatusTransitions { get; set; }
    }
}
