using System;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Converters;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class Review : IStripeModel
    {
        /// <summary>
        ///     String representing the object’s type.Objects of the same type share the same value. (value is "review")
        /// </summary>
        public string Object { get; set; }


        //The charge associated with this review.
        [JsonIgnore]
        public string ChargeId { get; set; }


        /// <summary>
        ///     The charge associated with this review.
        /// </summary>
        [JsonIgnore]
        public Charge ChargeModel { get; set; }

        /// <summary>
        ///     The charge associated with this review.
        /// </summary>
        public object Charge
        {
            set { Expandable<Charge>.Deserialize(value, s => ChargeId = s, o => ChargeModel = o); }
        }

        /// <summary>
        ///     Time at which the object was created.
        /// </summary>
        [JsonConverter(typeof(EpochConverter))]
        public DateTime Created { get; set; }

        /// <summary>
        ///     Flag indicating whether the object exists in live mode or test mode.
        /// </summary>
        public bool Livemode { get; set; }

        /// <summary>
        ///     If true, the review needs action.
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        ///     The reason the review is currently open or closed. One of rule, manual, approved, refunded, refunded_as_fraud, or
        ///     disputed.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///     Unique identifier for the object.
        /// </summary>
        public string Id { get; set; }
    }
}