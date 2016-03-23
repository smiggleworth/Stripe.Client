using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class FileUploadListFilter : ListFilter
    {
        [JsonIgnore]
        public DateTime? CreatedOn { get; set; }

        [JsonIgnore]
        public DateFilter CreatedFilter { get; set; }

        public object Created
        {
            get { return CreatedOn.HasValue ? (object) CreatedOn.Value.ToEpoch() : CreatedFilter; }
        }

        public string Purpose { get; set; }
    }
}