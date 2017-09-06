using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class CustomerListFilter : ListFilter
    {
        [JsonIgnore]
        public DateTime? CreatedDateTime { get; set; }

        [JsonIgnore]
        public DateFilter CreatedFilter { get; set; }

        [ChildModel]
        public object Created => CreatedDateTime.HasValue ? (object)CreatedDateTime.Value.ToEpoch() : CreatedFilter;
    }
}