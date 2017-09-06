using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Tests.Models.Arguments
{
    [TestClass]
    public class PiiTokenCreateArgumentsTests
    {
        private PiiTokenCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<PiiTokenCreateArguments>();
        }

        [TestMethod]
        public void PiiTokenCreateArguments_PiiIsRequired()
        {
            // Arrange 
            _args.Pii = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void PiiTokenCreateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Pii = GenFu.GenFu.New<PiiArguments>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(1).And.NotContain(x => x.Key == "pii[personal_id_number]");
        }
    }
}