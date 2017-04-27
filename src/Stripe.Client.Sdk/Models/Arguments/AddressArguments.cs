using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class AddressArguments
    {
        /// <summary>
        /// City/Suburb/Town/Village
        /// </summary>
        public string City { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        /// <summary>
        /// Address line 1 (Street address/PO Box/Company name)
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Address line 2 (Apartment/Suite/Unit/Building)
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// Zip, or Postal Code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// State, Province, or Country
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Town/cho-me
        /// </summary>
        public string Town { get; set; }
    }
}