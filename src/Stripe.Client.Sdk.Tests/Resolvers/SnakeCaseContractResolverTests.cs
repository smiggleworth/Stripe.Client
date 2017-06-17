using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Stripe.Client.Sdk.Extensions;
using Stripe.Client.Sdk.Resolvers;

namespace Stripe.Client.Sdk.Tests.Resolvers
{
    [TestClass]
    public class SnakeCaseContractResolverTests
    {
        [DataTestMethod]
        [DataRow("Last4", "last4")]
        [DataRow("Hello", "hello")]
        [DataRow("HelloWorld", "hello_world")]
        public void ResolveTest(string input, string output)
        {
            // Arrange
            var result = input.ToSnakeCase();

            // Assert
            result.Should().Be(output,"the string should be formatted with underscores.");
        }



        [TestMethod]
        public void ResolvePropertyName_ShouldSerialize()
        {
            // Arrange
            var model = GenFu.GenFu.New<Sample>();

            // Act
            var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver()
            });

            // Assert
            json.Should().Contain("some_prop")
                .And.Contain("prop_with_number1")
                .And.Contain("justprop");
        }

        [TestMethod]
        public void ResolvePropertyName_ShouldDeserialize()
        {
            // Arrange
            var json = "{\"a\":\"It's always...\", \"some_prop\":\"Marcia!\",\"prop_with_number1\":\"Marcia!!\",\"justprop\":\"Marcia!!!\"}";

            // Act
            var model = JsonConvert.DeserializeObject<Sample>(json, new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver()
            });

            // Assert
            model.A.Should().Be("It's always...");
            model.SomeProp.Should().Be("Marcia!");
            model.PropWithNumber1.Should().Be("Marcia!!");
            model.Justprop.Should().Be("Marcia!!!");
        }

        private class Sample
        {
            public string A { get; set; }
            public string SomeProp { get; set; }
            public string PropWithNumber1 { get; set; }
            public string Justprop { get; set; }
        }
    }
}