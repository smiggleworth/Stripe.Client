using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class AccountUpdateArgumentsTests
    {
        private AccountUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            GenFu.GenFu.Configure<DateOfBirthArguments>()
                .Fill(x => x.Day, () => 10)
                .Fill(x => x.Month, () => 10)
                .Fill(x => x.Year, () => 1976);

            GenFu.GenFu.Configure<AddressArguments>().Fill(x => x.Country, () => "US");

            GenFu.GenFu.Configure<AdditionalOwnerArguments>()
                .Fill(x => x.Address, () => GenFu.GenFu.New<AddressArguments>())
                .Fill(x => x.Dob, () => GenFu.GenFu.New<DateOfBirthArguments>());

            _args = GenFu.GenFu.New<AccountUpdateArguments>();
        }

        [TestMethod]
        public void AccountUpdateArguments_AccountIdIsRequired()
        {
            // Arrange 
            _args.AccountId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void AccountUpdateArguments_DeclineChargeOnWhenSet()
        {
            // Arrange 
            _args.DeclineChargeOn = new DeclineChargeOnArguments
            {
                AvsFailure = true,
                CvcFailure = true
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "decline_charge_on[avs_failure]")
                .And.Contain(x => x.Key == "decline_charge_on[cvc_failure]");
        }

        [TestMethod]
        public void AccountUpdateArguments_LegalEntityWhenSet()
        {
            // Arrange 
            _args.LegalEntity = GenFu.GenFu.New<LegalEntityArguments>();
            _args.LegalEntity.Dob = new DateOfBirthArguments
            {
                Day = 21,
                Month = 10,
                Year = 1978
            };
            _args.LegalEntity.PersonalAddress = GenFu.GenFu.New<AddressArguments>();
            _args.LegalEntity.PersonalAddressKana = GenFu.GenFu.New<AddressArguments>();
            _args.LegalEntity.PersonalAddressKanji = GenFu.GenFu.New<AddressArguments>();

            _args.LegalEntity.AdditionalOwners = new List<AdditionalOwnerArguments>
            {
                GenFu.GenFu.New<AdditionalOwnerArguments>(),
                GenFu.GenFu.New<AdditionalOwnerArguments>(),
                GenFu.GenFu.New<AdditionalOwnerArguments>()
            };

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "legal_entity[additional_owners][0][first_name]")
                .And.Contain(x => x.Key == "legal_entity[additional_owners][1][first_name]")
                .And.Contain(x => x.Key == "legal_entity[additional_owners][2][first_name]")
                .And.Contain(x => x.Key == "legal_entity[business_name]")
                .And.Contain(x => x.Key == "legal_entity[business_name_kana]")
                .And.Contain(x => x.Key == "legal_entity[business_name_kanji]")
                .And.Contain(x => x.Key == "legal_entity[business_tax_id]")
                .And.Contain(x => x.Key == "legal_entity[business_vat_id]")
                .And.Contain(x => x.Key == "legal_entity[dob][day]")
                .And.Contain(x => x.Key == "legal_entity[dob][month]")
                .And.Contain(x => x.Key == "legal_entity[dob][year]")
                .And.Contain(x => x.Key == "legal_entity[first_name]")
                .And.Contain(x => x.Key == "legal_entity[first_name_kana]")
                .And.Contain(x => x.Key == "legal_entity[first_name_kanji]")
                .And.Contain(x => x.Key == "legal_entity[gender]")
                .And.Contain(x => x.Key == "legal_entity[last_name]")
                .And.Contain(x => x.Key == "legal_entity[last_name_kana]")
                .And.Contain(x => x.Key == "legal_entity[last_name_kanji]")
                .And.Contain(x => x.Key == "legal_entity[maiden_name]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][city]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][country]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][line1]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][line2]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][postal_code]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][state]")
                .And.Contain(x => x.Key == "legal_entity[personal_address][town]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][city]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][country]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][line1]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][line2]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][postal_code]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][state]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kana][town]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][city]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][country]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][line1]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][line2]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][postal_code]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][state]")
                .And.Contain(x => x.Key == "legal_entity[personal_address_kanji][town]")
                .And.Contain(x => x.Key == "legal_entity[personal_id_number]")
                .And.Contain(x => x.Key == "legal_entity[phone_number]")
                .And.Contain(x => x.Key == "legal_entity[ssn_last_4]")
                .And.Contain(x => x.Key == "legal_entity[type]");
        }


        [TestMethod]
        public void AccountUpdateArguments_MetadataWhenSet()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]");
        }

        [TestMethod]
        public void AccountUpdateArguments_TosAcceptanceWhenSet()
        {
            // Arrange 
            _args.TosAcceptance = GenFu.GenFu.New<TermsOfServiceAcceptanceArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "tos_acceptance[date]")
                .And.Contain(x => x.Key == "tos_acceptance[ip]")
                .And.Contain(x => x.Key == "tos_acceptance[user_agent]");
        }

        [TestMethod]
        public void AccountUpdateArguments_TransferScheduleWhenSet()
        {
            // Arrange 
            _args.TransferSchedule = GenFu.GenFu.New<TransferScheduleArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().Contain(x => x.Key == "transfer_schedule[delay_days]")
                .And.Contain(x => x.Key == "transfer_schedule[interval]")
                .And.Contain(x => x.Key == "transfer_schedule[monthly_anchor]")
                .And.Contain(x => x.Key == "transfer_schedule[weekly_anchor]");
        }

        [TestMethod]
        public void AccountUpdateArguments_GetOtherKeys()
        {
            // Arrange 

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(12)
                .And.Contain(x => x.Key == "business_logo")
                .And.Contain(x => x.Key == "business_name")
                .And.Contain(x => x.Key == "business_primary_color")
                .And.Contain(x => x.Key == "business_url")
                .And.Contain(x => x.Key == "debit_negative_balances")
                .And.Contain(x => x.Key == "default_currency")
                .And.Contain(x => x.Key == "email")
                .And.Contain(x => x.Key == "product_description")
                .And.Contain(x => x.Key == "statement_descriptor")
                .And.Contain(x => x.Key == "support_email")
                .And.Contain(x => x.Key == "support_phone")
                .And.Contain(x => x.Key == "support_url");
        }
    }
}