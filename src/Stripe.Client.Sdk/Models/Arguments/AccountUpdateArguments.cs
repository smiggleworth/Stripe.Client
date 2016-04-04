using Newtonsoft.Json;
using Stripe.Client.Sdk.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AccountUpdateArguments
    {
        [JsonIgnore]
        [Required]
        public string AccountId { get; set; }

        public string BusinessLogo { get; set; }

        public string BusinessName { get; set; }

        public string BusinessPrimaryColor { get; set; }

        public string BusinessUrl { get; set; }

        public bool DebitNegativeBalances { get; set; }

        [ChildModel]
        public DeclineChargeOnArguments DeclineChargeOn { get; set; }

        public string DefaultCurrency { get; set; }

        public string Email { get; set; }

        [ChildModel]
        public LegalEntityArguments LegalEntity { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string ProductDescription { get; set; }

        public string StatementDescriptor { get; set; }

        public string SupportEmail { get; set; }

        public string SupportPhone { get; set; }

        public string SupportUrl { get; set; }

        [ChildModel]
        public TermsOfServiceAcceptanceArguments TosAcceptance { get; set; }

        [ChildModel]
        public TransferScheduleArguments TransferSchedule { get; set; }

        [ChildModel]
        public AccountVerification Verification { get; set; }
    }

    public class AccountUpdateArguments<T> : AccountUpdateArguments
        where T : IPaymentTypeArguments
    {
        [JsonIgnore]
        public string Token { get; set; }

        /// <summary>
        /// A card or bank account to attach to the account. You can provide either a token, like the ones returned by Stripe.js, or a dictionary as documented in the external_account parameter for either card or bank account creation
        /// </summary>
        [JsonIgnore]
        public T ExternalAccountCreateArguments { get; set; }

        [ChildModel]
        [Required]
        public object ExternalAccount => !string.IsNullOrWhiteSpace(Token) ? (object)Token : ExternalAccountCreateArguments;
    }
}