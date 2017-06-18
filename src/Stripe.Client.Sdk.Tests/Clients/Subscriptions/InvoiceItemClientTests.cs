using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Subscriptions;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Subscriptions
{
    [TestClass]
    public class InvoiceItemClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IInvoiceItemClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new InvoiceItemClient(_stripe);
        }

        [TestMethod]
        public async Task GetInvoiceItemTest()
        {
            // Arrange
            var id = "invoiceitem-id";
            _stripe.Get(Arg.Is<StripeRequest<InvoiceItem>>(a => a.UrlPath == "invoiceitems/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<InvoiceItem>()));

            // Act
            var response = await _client.GetInvoiceItem(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetInvoiceItemsTest()
        {
            // Arrange
            var filter = new InvoiceItemListFilter();
            _stripe.Get(
                       Arg.Is<StripeRequest<InvoiceItemListFilter, Pagination<InvoiceItem>>>(
                           a => a.UrlPath == "invoiceitems" && a.Model == filter), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Pagination<InvoiceItem>>()));

            // Act
            var response = await _client.GetInvoiceItems(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateInvoiceItemTest()
        {
            // Arrange
            var args = new InvoiceItemCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<InvoiceItemCreateArguments, InvoiceItem>>(a => a.UrlPath == "invoiceitems" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<InvoiceItem>()));

            // Act
            var response = await _client.CreateInvoiceItem(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateInvoiceItemTest()
        {
            // Arrange
            var args = new InvoiceItemUpdateArguments
            {
                InvoiceItemId = "invoiceitem-id"
            };
            _stripe.Post(
                       Arg.Is<StripeRequest<InvoiceItemUpdateArguments, InvoiceItem>>(
                           a => a.UrlPath == "invoiceitems/" + args.InvoiceItemId && a.Model == args), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<InvoiceItem>()));

            // Act
            var response = await _client.UpdateInvoiceItem(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeleteInvoiceItemTest()
        {
            // Arrange
            var id = "invoiceitem-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "invoiceitems/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeleteInvoiceItem(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}