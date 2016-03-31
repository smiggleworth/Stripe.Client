using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;
using System;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class RecipientListFilter : ListFilter
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

        public string Type { get; set; }

        public bool? Verified { get; set; }
    }
}