using Stripe.Client.Sdk.Attributes;

namespace Stripe.Client.Sdk.Models.Arguments {
    public class OwnerArguments
    {
        /// <summary>
        ///     Owner’s address.
        /// </summary>
        [ChildModel]
        public Address Address { get; set; }

        /// <summary>
        ///     Owner’s email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Owner’s full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Owner’s phone number (including extension).
        /// </summary>
        public string Phone { get; set; }
    }
}