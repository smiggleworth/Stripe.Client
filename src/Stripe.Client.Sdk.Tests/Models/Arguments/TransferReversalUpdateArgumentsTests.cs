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
    public class TransferReversalUpdateArgumentsTests
    {
        private TransferReversalUpdateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<TransferReversalUpdateArguments>();
        }

        [TestMethod]
        public void TransferReversalUpdateArguments_TranferIdIsRequired()
        {
            // Arrange 
            _args.TransferId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void TransferReversalUpdateArguments_TranferReversalIdIsRequired()
        {
            // Arrange 
            _args.TransferReversalId = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void TransferReversalUpdateArguments_GetAllKeys()
        {
            // Arrange 
            _args.Metadata = Data.Metadata;

            // Act
            var keyValuePairs = StripeClient.GetKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                .And.Contain(x => x.Key == "description")
                .And.Contain(x => x.Key == "metadata[key1]")
                .And.Contain(x => x.Key == "metadata[key2]");
        }
    }
}