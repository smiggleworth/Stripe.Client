using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AdditionalOwnerArguments
    {
        [ChildModel]
        public AddressArguments Address { get; set; }

        [ChildModel]
        public DateOfBirthArguments Dob { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        ///     An Id returned by a file upload with the purpose
        /// </summary>
        public string Verification { get; set; }
    }
}