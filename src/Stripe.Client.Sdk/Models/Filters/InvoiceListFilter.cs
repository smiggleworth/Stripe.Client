﻿using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

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
        public object Date => InvoiceDateTime.HasValue ? (object)InvoiceDateTime.Value.ToEpoch() : InvoiceDateFilter;
    }
}