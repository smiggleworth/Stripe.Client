namespace Stripe.Client.Sdk.Models
{
    public class Owner
    {
        /// <summary>
        ///     Owner’s address.
        /// </summary>
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

        /// <summary>
        ///     Verified owner’s address.
        /// </summary>
        public Address VerifiedAddress { get; set; }

        /// <summary>
        ///     Verified owner’s email address.
        /// </summary>
        public string VerifiedEmail { get; set; }

        /// <summary>
        ///     Verified owner’s full name.
        /// </summary>
        public string VerifiedName { get; set; }


        /// <summary>
        ///     Verified owner’s phone number (including extension).
        /// </summary>
        public string VerifiedPhone { get; set; }
    }
}