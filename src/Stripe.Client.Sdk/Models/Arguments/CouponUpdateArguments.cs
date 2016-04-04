using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class CouponUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string CouponId { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}