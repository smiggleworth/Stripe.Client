using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe.Client.Sdk.Attributes;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Models;

namespace Stripe.Client.Sdk.Tests.Clients
{
    [TestClass]
    public class StripeClientTests
    {
        [TestMethod]
        public async Task GetUriTest()
        {
            // Arrange
            var stripeClient = new StripeClient(null, null);
            var uri = await stripeClient.GetUri("test", _testModel);

            // Act
            var path = uri.PathAndQuery.Split('?')[0];

            var queryString = QueryHelpers.ParseQuery(uri.Query);

            // Assert
            var match = (from key in queryString.Select(x => x.Key)
                         join e in _expected on new
                         {
                             Key = key,
                             Value = queryString[key][0]
                         } equals new
                         {
                             e.Key,
                             e.Value
                         }
                         select key).ToList();

            path.Should().Be("/v1/test");
            match.Should().HaveCount(_expected.Count());
        }

        [TestMethod]
        public void GetModelKeyValuePairs_WhenValuesAreSet_ShouldReturnAllPropertiesAsKeyValuePairs()
        {
            // Arrange 
            var model = GenFu.GenFu.New<TestModel>();

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(model).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(5);
        }

        [TestMethod]
        public void GetModelKeyValuePairs_WhenValuesAreNull_ShouldNotReturnInKeyValuePairs()
        {
            // Arrange 
            var model = GenFu.GenFu.New<TestModel>();
            model.BigName = null;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(model).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(4);
        }

        [TestMethod]
        public void GetModelKeyValuePairs_WhenValuesAreEmptyString_ShouldReturnIncludeInKeyValuePairs()
        {
            // Arrange 
            var model = GenFu.GenFu.New<TestModel>();
            model.BigName = string.Empty;

            // Act
            var keyValuePairs = StripeClient.GetModelKeyValuePairs(model).ToList();

            // Assert
            keyValuePairs.Should().HaveCount(5);
        }


        [TestMethod]
        public void DeserializeErrorTest()
        {
            // Arrange
            var json = File.ReadAllText("JSON/error.json");

            // Act
            var obj = StripeClient.Deserialize<StripeErrorEnvelope>(json);

            // Assert
            obj.Should().BeAssignableTo<StripeErrorEnvelope>();
            obj.Error.Should().BeAssignableTo<StripeError>();
            obj.Error.Type.Should().Be("some type");
            obj.Error.Message.Should().Be("I am a message");
        }

        [TestMethod]
        public void ExpandablesTest()
        {
            // Arrange
            var stripeClient = new StripeClient(null, null)
            {
                Expandables = new List<string>
                {
                    Expandables.Invoice,
                    Expandables.Customer,
                    Expandables.Charge
                }
            };

            // Act
            var keys = stripeClient.GetAllKeyValuePairs<object>(null);

            // Assert
            keys.Should()
                .Contain(x => x.Key == "expand[]" && x.Value == "invoice")
                .And.Contain(x => x.Key == "expand[]" && x.Value == "customer")
                .And.Contain(x => x.Key == "expand[]" && x.Value == "charge");
        }


        [TestMethod]
        public void DeserializeExpandable()
        {
            // Arrange
            var json = File.ReadAllText("JSON/expandable.json");

            // Act
            var obj = StripeClient.Deserialize<Customer>(json);


            obj.Should().NotBeNull();
            obj.DefaultCard.Should().NotBeNull();
            obj.DefaultCard.AddressLine1.Should().Be("test", obj.DefaultCard.AddressLine1);
            obj.DefaultCard.CustomerId.Should().Be("cus_9iMkevoQCYMIzC", obj.DefaultCard.CustomerId);
        }

        #region Fake Data

        private readonly TestModel _testModel = new TestModel
        {
            Name = "The Name",
            BigName = "The Big Name",
            Metadata = new Dictionary<string, string>
            {
                {"key1", "value 1"},
                {"key2", "value 2"},
                {"key3", "value 3"}
            },
            NestedModel = new TestModel
            {
                Name = "The Nested Name",
                BigName = "The Big Nested Name",
                TestChildModel = new TestModel
                {
                    Name = "Hello Model"
                },
                Metadata = new Dictionary<string, string>
                {
                    {"nestedkey1", "value 1"},
                    {"nestedkey2", "value 2"},
                    {"nestedkey3", "value 3"}
                }
            },
            TestChildString = "Hello Token",
            Children = new List<TestModel>
            {
                new TestModel
                {
                    BigName = "Big Child 1"
                },
                new TestModel
                {
                    BigName = "Big Child 2"
                }
            }
        };

        private readonly List<KeyValuePair<string, string>> _expected = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("name", "The Name"),
            new KeyValuePair<string, string>("big_name", "The Big Name"),
            new KeyValuePair<string, string>("metadata[key1]", "value 1"),
            new KeyValuePair<string, string>("metadata[key2]", "value 2"),
            new KeyValuePair<string, string>("metadata[key3]", "value 3"),
            new KeyValuePair<string, string>("nested_model[name]", "The Nested Name"),
            new KeyValuePair<string, string>("nested_model[big_name]", "The Big Nested Name"),
            new KeyValuePair<string, string>("nested_model[metadata][nestedkey1]", "value 1"),
            new KeyValuePair<string, string>("nested_model[metadata][nestedkey2]", "value 2"),
            new KeyValuePair<string, string>("nested_model[metadata][nestedkey3]", "value 3"),
            new KeyValuePair<string, string>("children[0][big_name]", "Big Child 1"),
            new KeyValuePair<string, string>("children[1][big_name]", "Big Child 2")
        };

        private class TestModel
        {
            public string Name { get; set; }

            public string BigName { get; set; }

            public string DontSetMe { get; set; }

            public Dictionary<string, string> Metadata { get; set; }

            [ChildModel]
            public TestModel NestedModel { get; set; }

            public string TestChildString { get; set; }

            public TestModel TestChildModel { get; set; }

            [ChildModel]
            public object TestChild => !string.IsNullOrWhiteSpace(TestChildString) ? TestChildString : (object)TestChildModel;

            [ChildModel]
            public List<TestModel> Children { get; set; }
        }

        #endregion Fake Data
    }
}