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
    [Ignore]
    [TestClass]
    public class FileUploadCreateArgumentsTests
    {
        private FileUploadCreateArguments _args;

        [TestInitialize]
        public void Init()
        {
            _args = GenFu.GenFu.New<FileUploadCreateArguments>();
        }

        [TestMethod]
        public void FileUploadCreateArguments_TheFieldIsRequired()
        {
            // Arrange 
            // _args.TheField = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_args);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void FileUploadCreateArguments_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _args = new FileUploadCreateArguments();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void FileUploadCreateArguments_GetAllKeys()
        {
            // Arrange 

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_args).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0)
                .And.NotContain(x => x.Key == "id")
                .And.Contain(x => x.Key == "starting_after")
                .And.Contain(x => x.Key == "limit");
        }
    }
}