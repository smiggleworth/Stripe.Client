using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class StatusTransitionFilter
    {
        [JsonIgnore]
        public DateTime? CancelledDateTime { get; set; }

        [JsonIgnore]
        public DateFilter CancelledFilter { get; set; }

        [ChildModel]
        public object Cancelled
        {
            get { return CancelledDateTime.HasValue ? (object)CancelledDateTime.Value.ToEpoch() : CancelledFilter; }
        }

        [JsonIgnore]
        public DateTime? FulfilledDateTime { get; set; }

        [JsonIgnore]
        public DateFilter FulfilledFilter { get; set; }

        [ChildModel]
        public object Fulfilled
        {
            get { return FulfilledDateTime.HasValue ? (object)FulfilledDateTime.Value.ToEpoch() : FulfilledFilter; }
        }

        [JsonIgnore]
        public DateTime? PaidDateTime { get; set; }

        [JsonIgnore]
        public DateFilter PaidFilter { get; set; }

        [ChildModel]
        public object Paid
        {
            get { return PaidDateTime.HasValue ? (object)PaidDateTime.Value.ToEpoch() : PaidFilter; }
        }

        [JsonIgnore]
        public DateTime? ReturnedDateTime { get; set; }

        [JsonIgnore]
        public DateFilter ReturnedFilter { get; set; }

        [ChildModel]
        public object Returned
        {
            get { return ReturnedDateTime.HasValue ? (object)ReturnedDateTime.Value.ToEpoch() : ReturnedFilter; }
        }
    }
}