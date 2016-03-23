using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PlanUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string PlanId { get; set; }

        public string Name { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string StatementDescriptor { get; set; }
    }
}