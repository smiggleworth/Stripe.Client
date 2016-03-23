namespace Stripe.Client.Sdk.Models
{
    public class AdditionalOwner
    {
        public Address Address { get; set; }

        public BirthDay Dob { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public LegalEntityVerification Verification { get; set; }
    }
}