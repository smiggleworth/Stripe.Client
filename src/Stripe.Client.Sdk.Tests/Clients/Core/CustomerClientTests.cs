using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Core
{
    [TestClass]
    public class CustomerClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private ICustomerClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new CustomerClient(_stripe);
        }

        [TestMethod]
        public async Task GetCustomerTest()
        {
            // Arrange
            var id = "customer-id";
            _stripe.Get(Arg.Is<StripeRequest<Customer>>(a => a.UrlPath == "customers/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Customer>()));

            // Act
            var response = await _client.GetCustomer(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCustomersTest()
        {
            // Arrange
            var filter = new CustomerListFilter();
            _stripe.Get(
                    Arg.Is<StripeRequest<CustomerListFilter, Pagination<Customer>>>(
                        a => a.UrlPath == "customers" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Customer>>()));

            // Act
            var response = await _client.GetCustomers(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateCustomerTest()
        {
            // Arrange
            var args = new CustomerCreateArguments();
            _stripe.Post(
                    Arg.Is<StripeRequest<CustomerCreateArguments, Customer>>(
                        a => a.UrlPath == "customers" && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Customer>()));

            // Act
            var response = await _client.CreateCustomer(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateCustomerTest()
        {
            // Arrange
            var args = new CustomerUpdateArguments
            {
                CustomerId = "customer-id"
            };
            _stripe.Post(
                    Arg.Is<StripeRequest<CustomerUpdateArguments, Customer>>(
                        a => a.UrlPath == "customers/" + args.CustomerId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Customer>()));

            // Act
            var response = await _client.UpdateCustomer(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteCustomerTest()
        {
            // Arrange
            var id = "customer-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "customers/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteCustomer(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetBankAccountTest()
        {
            // Arrange
            var customerId = "customer-id";
            var id = "bank-account-id";
            _stripe.Get(
                Arg.Is<StripeRequest<BankAccount>>(a => a.UrlPath == "customers/" + customerId + "/sources/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<BankAccount>()));

            // Act
            var response = await _client.GetBankAccount(id, customerId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetBankAccountsTest()
        {
            // Arrange
            var filter = new CustomerBankAccountListFilter
            {
                CustomerId = "customer-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<CustomerBankAccountListFilter, Pagination<BankAccount>>>(
                    a => a.UrlPath == "customers/" + filter.CustomerId + "/sources" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<BankAccount>>()));

            // Act
            var response = await _client.GetBankAccounts(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateBankAccountTest()
        {
            // Arrange
            var args = new CustomerBankAccountCreateArguments
            {
                CustomerId = "customer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<CustomerBankAccountCreateArguments, BankAccount>>(
                    a => a.UrlPath == "customers/" + args.CustomerId + "/sources" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<BankAccount>()));

            // Act
            var response = await _client.CreateBankAccount(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateBankAccountTest()
        {
            // Arrange
            var args = new CustomerBankAccountUpdateArguments
            {
                BankAccountId = "some-value",
                CustomerId = "customer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<CustomerBankAccountUpdateArguments, BankAccount>>(
                    a => a.UrlPath == "customers/" + args.CustomerId + "/sources/" + args.BankAccountId && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<BankAccount>()));

            // Act
            var response = await _client.UpdateBankAccount(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCardTest()
        {
            // Arrange
            var customerId = "ACC_1234";
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<Card>>(a => a.UrlPath == "customers/" + customerId + "/sources/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));

            // Act
            var response = await _client.GetCard(id, customerId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCardsTest()
        {
            // Arrange
            var filter = new CustomerCardListFilter
            {
                CustomerId = "customer-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<CustomerCardListFilter, Pagination<Card>>>(
                    a => a.UrlPath == "customers/" + filter.CustomerId + "/sources" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Card>>()));

            // Act
            var response = await _client.GetCards(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateCardTest()
        {
            // Arrange
            var args = new CustomerCardCreateArguments
            {
                CustomerId = "customer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<CustomerCardCreateArguments, Card>>(
                    a => a.UrlPath == "customers/" + args.CustomerId + "/sources" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));

            // Act
            var response = await _client.CreateCard(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateCardTest()
        {
            // Arrange
            var args = new CustomerCardUpdateArguments
            {
                CardId = "card-id",
                CustomerId = "customer-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<CustomerCardUpdateArguments, Card>>(
                    a => a.UrlPath == "customers/" + args.CustomerId + "/sources/" + args.CardId && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));

            // Act
            var response = await _client.UpdateCard(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteCardTest()
        {
            // Arrange
            var customerId = "ACC_1234";
            var id = "ID_VALUE";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "customers/" + customerId + "/sources/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteCard(id, customerId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteDiscountTest()
        {
            // Arrange
            var id = "customer-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "customers/" + id + "/discount"),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteDiscount(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}