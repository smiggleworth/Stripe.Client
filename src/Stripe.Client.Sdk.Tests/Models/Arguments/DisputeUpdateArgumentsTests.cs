using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class DisputeUpdateArgumentsTests
    {
        private DisputeUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<DisputeUpdateArguments>();
        }

        [TestMethod]
        public void DisputeUpdateArguments_DisputeIdIsRequired()
        {
            // Arrange 
            _args.DisputeId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }


        [TestMethod]
        public void DisputeUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Evidence = GenFu.GenFu.New<Evidence>();
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(29)
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]")
                .And.Contain(x => x.Key == "evidence[access_activity_log]")
                .And.Contain(x => x.Key == "evidence[billing_address]")
                .And.Contain(x => x.Key == "evidence[cancellation_policy]")
                .And.Contain(x => x.Key == "evidence[cancellation_policy_disclosure]")
                .And.Contain(x => x.Key == "evidence[cancellation_rebuttal]")
                .And.Contain(x => x.Key == "evidence[customer_communication]")
                .And.Contain(x => x.Key == "evidence[customer_email_address]")
                .And.Contain(x => x.Key == "evidence[customer_name]")
                .And.Contain(x => x.Key == "evidence[customer_purchase_ip]")
                .And.Contain(x => x.Key == "evidence[customer_signature]")
                .And.Contain(x => x.Key == "evidence[duplicate_charge_documentation]")
                .And.Contain(x => x.Key == "evidence[duplicate_charge_explanation]")
                .And.Contain(x => x.Key == "evidence[duplicate_charge_id]")
                .And.Contain(x => x.Key == "evidence[product_description]")
                .And.Contain(x => x.Key == "evidence[receipt]")
                .And.Contain(x => x.Key == "evidence[refund_policy]")
                .And.Contain(x => x.Key == "evidence[refund_policy_disclosure]")
                .And.Contain(x => x.Key == "evidence[refund_refusal_explanation]")
                .And.Contain(x => x.Key == "evidence[service_date]")
                .And.Contain(x => x.Key == "evidence[service_documentation]")
                .And.Contain(x => x.Key == "evidence[shipping_address]")
                .And.Contain(x => x.Key == "evidence[shipping_carrier]")
                .And.Contain(x => x.Key == "evidence[shipping_date]")
                .And.Contain(x => x.Key == "evidence[shipping_documentation]")
                .And.Contain(x => x.Key == "evidence[shipping_tracking_number]")
                .And.Contain(x => x.Key == "evidence[uncategorized_file]")
                .And.Contain(x => x.Key == "evidence[uncategorized_text]");
        }
    }
}