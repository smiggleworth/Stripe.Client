using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class BalanceTransactionListFilter : ListFilter
    {
        [JsonIgnore]
        public DateTime? AvailableOnDateTime { get; set; }

        [JsonIgnore]
        public DateFilter AvailableOnFilter { get; set; }

        [ChildModel]
        public object AvailableOn => AvailableOnDateTime.HasValue ? (object)AvailableOnDateTime.Value.ToEpoch() : AvailableOnFilter;

        [JsonIgnore]
        public DateTime? CreatedDateTime { get; set; }

        [JsonIgnore]
        public DateFilter CreatedFilter { get; set; }

        [ChildModel]
        public object Created => CreatedDateTime.HasValue ? (object)CreatedDateTime.Value.ToEpoch() : CreatedFilter;

        public string Currency { get; set; }

        /// <summary>
        ///     Gets or sets the source identifier.
        /// </summary>
        /// <value>
        ///     The source identifier.
        /// </value>
        public string Source { get; set; }

        /// <summary>
        ///     Gets or sets the transfer identifier.
        /// </summary>
        /// <value>
        ///     The transfer identifier.
        /// </value>
        public string Transfer { get; set; }

        public string Type { get; set; }
    }
}