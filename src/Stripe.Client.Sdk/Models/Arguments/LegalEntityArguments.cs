using Stripe.Client.Sdk.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class LegalEntityArguments
    {
        [ChildModel]
        public List<AdditionalOwnerArguments> AdditionalOwners { get; set; }

        [ChildModel]
        public AddressArguments Address { get; set; }

        /// <summary>
        /// The Kana variation of the address of this legal entity (Japan only)
        /// </summary>
        [ChildModel]
        public AddressArguments AddressKana { get; set; }

        /// <summary>
        /// The Kanji variation of the address of this legal entity (Japan only)
        /// </summary>
        [ChildModel]
        public AddressArguments AddressKanji { get; set; }

        public string BusinessName { get; set; }

        /// <summary>
        /// The Kana variation of the legal name of the company (Japan only)
        /// </summary>
        public string BusinessNameKana { get; set; }

        /// <summary>
        /// The Kanji variation of the legal name of the company (Japan only)
        /// </summary>
        public string BusinessNameKanji { get; set; }

        public string BusinessTaxId { get; set; }

        public string BusinessVatId { get; set; }

        [ChildModel]
        public DateOfBirthArguments Dob { get; set; }

        public string FirstName { get; set; }

        /// <summary>
        /// The Kana variation of the first name of the individual responsible for the account (Japan only)
        /// </summary>
        public string FirstNameKana { get; set; }

        /// <summary>
        /// The Kanji variation of the first name of the individual responsible for the account (Japan only)
        /// </summary>
        public string FirstNameKanji { get; set; }

        /// <summary>
        /// The gender of the individual responsible for the account (International regulations require either “male” or “female”)
        /// </summary>
        public string Gender { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// The Kana variation of the first name of the individual responsible for the account (Japan only)
        /// </summary>
        public string LastNameKana { get; set; }


        /// <summary>
        /// The Kanji variation of the first name of the individual responsible for the account (Japan only)
        /// </summary>
        public string LastNameKanji { get; set; }

        public string MaidenName { get; set; }

        [ChildModel]
        public AddressArguments PersonalAddress { get; set; }

        /// <summary>
        /// The Kana variation of the representative of this legal entity, used for verification (Japan only)
        /// </summary>
        [ChildModel]
        public AddressArguments PersonalAddressKana { get; set; }

        /// <summary>
        /// The Kanji variation of the representative of this legal entity, used for verification (Japan only)
        /// </summary>
        [ChildModel]
        public AddressArguments PersonalAddressKanji { get; set; }

        public string PersonalIdNumber { get; set; }

        public string PhoneNumber { get; set; }

        [JsonProperty("ssn_last_4")]
        public string SsnLast4 { get; set; }

        public string Type { get; set; }

        public string Verification { get; set; }

        public  string TaxIdRegistrar { get; set; }
    }
}