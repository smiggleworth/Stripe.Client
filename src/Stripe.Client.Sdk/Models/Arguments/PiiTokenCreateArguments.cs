using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PiiTokenCreateArguments
    {
        [Required]
        public PiiArguments Pii { get; set; }
    }
}