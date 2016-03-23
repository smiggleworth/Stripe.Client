using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PlanCreateArguments
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Interval { get; set; }

        public int? IntervalCount { get; set; }

        [Required]
        public string Name { get; set; }

        public int? TrialPeriodDays { get; set; }

        public string StatementDescriptor { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}