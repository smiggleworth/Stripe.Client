using System.Collections.Generic;
using System.Linq;

namespace Stripe.Client.Sdk.Models
{
    public class Account : IStripeModel
    {
        public string Object { get; set; }

        public string BusinessName { get; set; }

        public string BusinessPrimaryColor { get; set; }

        public string BusinessUrl { get; set; }

        public bool ChargesEnabled { get; set; }

        public string Country { get; set; }

        public bool DebitNegativeBalances { get; set; }

        public DeclineChargeOn DeclineChargeOn { get; set; }

        public string DefaultCurrency { get; set; }

        public bool DetailsSubmitted { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public Pagination<dynamic> ExternalAccounts { get; set; }

        public LegalEntity LegalEntity { get; set; }

        public bool Managed { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public string ProductDescription { get; set; }

        public string StatementDescriptor { get; set; }

        public string SupportEmail { get; set; }

        public string SupportPhone { get; set; }

        public string SupportUrl { get; set; }

        public string Timezone { get; set; }

        public TermsOfServiceAcceptance TosAcceptance { get; set; }

        public TransferSchedule TransferSchedule { get; set; }

        public bool TransfersEnabled { get; set; }

        public AccountVerification Verification { get; set; }

        public string Id { get; set; }
    }
}