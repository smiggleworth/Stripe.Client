using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;
using System;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class InvoiceListFilter : ListFilter
    {
        public string Customer { get; set; }

        [JsonIgnore]
        public DateTime? InvoiceDateTime { get; set; }

        [JsonIgnore]
        public DateFilter InvoiceDateFilter { get; set; }

        [ChildModel]
        public object Date
        {
            get { return InvoiceDateTime.HasValue ? (object)InvoiceDateTime.Value.ToEpoch() : InvoiceDateFilter; }
        }
    }
}