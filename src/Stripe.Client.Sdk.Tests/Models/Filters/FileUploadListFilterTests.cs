using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Models.Filters
{
    [Ignore]
    [TestClass]
    public class FileUploadListFilterTests
    {
        private FileUploadListFilter _filter;

        [TestInitialize]
        public void Init()
        {
            _filter = GenFu.GenFu.New<FileUploadListFilter>();
        }

        [TestMethod]
        public void FileUploadListFilter_TheFieldIsRequired()
        {
            // Arrange 
            // _filter.TheField = null;

            // Act
            Func<IEnumerable<KeyValuePair<string, string>>> func = () => StripeClient.GetModelKeyValuePairs(_filter);

            // Assert
            func.Enumerating().ShouldThrow<ValidationException>();
        }

        [TestMethod]
        public void FileUploadListFilter_DoesNotHaveRequiredFields()
        {
            // Arrange 
            _filter = new FileUploadListFilter();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(0);
        }

        [TestMethod]
        public void FileUploadListFilter_GetAllKeys()
        {
            // Arrange

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(_filter).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(3)
                         .And.NotContain(x => x.Key == "account_id")
                         .And.Contain(x => x.Key == "ending_before")
                         .And.Contain(x => x.Key == "starting_after")
                         .And.Contain(x => x.Key == "limit");
        }
    }
}