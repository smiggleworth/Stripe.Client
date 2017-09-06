using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountRejectArguments
    {
        /// <summary>
        ///     The identifier of the account to be rejected.
        /// </summary>
        [Required]
        [JsonIgnore]
        public string AccountId { get; set; }

        /// <summary>
        ///     The reason for rejecting the account. May be one of fraud, terms_of_service, or other.
        /// </summary>
        [Required]
        public string Reason { get; set; }
    }
}