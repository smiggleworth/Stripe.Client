using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class TransferListFilter : ListFilter
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

        [JsonIgnore]
        public DateTime? TransferDateTime { get; set; }

        [JsonIgnore]
        public DateFilter TransferDateFilter { get; set; }

        [ChildModel]
        public object Date
        {
            get { return TransferDateTime.HasValue ? (object)TransferDateTime.Value.ToEpoch() : TransferDateFilter; }
        }

        /// <summary>
        /// Only return transfers for the destination specified by this account OrderId.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Only return transfers for the recipient specified by this recipient OrderId.
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Only return transfers that have the given status: pending, paid, failed, in_transit, or canceled.
        /// </summary>
        public string Status { get; set; }
    }
}