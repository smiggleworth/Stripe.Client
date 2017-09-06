﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class InvoiceLineItemListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string InvoiceId { get; internal set; }

        public string Customer { get; set; }
    }
}