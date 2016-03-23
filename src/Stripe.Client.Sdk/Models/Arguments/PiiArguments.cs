using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class PiiArguments
    {
        [Required]
        public string PersonalIdNumber { get; set; }
    }
}