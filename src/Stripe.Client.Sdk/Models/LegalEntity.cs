namespace Stripe.Client.Sdk.Models
{
    public class LegalEntity
    {
        public Pagination<AdditionalOwner> AdditionalOwners { get; set; }

        public Address Address { get; set; }

        public string BusinessName { get; set; }

        public BirthDay Dob { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address PersonalAddress { get; set; }

        public bool PersonalIdNumberProvided { get; set; }

        public bool SsnLast4Provided { get; set; }

        public string Type { get; set; }

        public LegalEntityVerification Verification { get; set; }
    }
}