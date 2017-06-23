using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class PayoutListFilter : ListFilter
    {
        [JsonIgnore]
        public DateTime? ArrivalDateTime { get; set; }

        [JsonIgnore]
        public DateFilter ArrivalDateFilter { get; set; }

        [ChildModel]
        public object ArrivalDate => ArrivalDateTime.HasValue ? (object)ArrivalDateTime.Value.ToEpoch() : ArrivalDateFilter;

        [JsonIgnore]
        public DateTime? CreatedDateTime { get; set; }

        [JsonIgnore]
        public DateFilter CreatedFilter { get; set; }

        [ChildModel]
        public object Created => CreatedDateTime.HasValue ? (object)CreatedDateTime.Value.ToEpoch() : CreatedFilter;
    }
}