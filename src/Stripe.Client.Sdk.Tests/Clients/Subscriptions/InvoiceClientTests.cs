using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Subscription;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Subscriptions
{
    [TestClass]
    public class InvoiceClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IInvoiceClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new InvoiceClient(_stripe);
        }

        [TestMethod]
        public async Task GetInvoiceTest()
        {
            // Arrange
            var id = "invoice-id";
            _stripe.Get(Arg.Is<StripeRequest<Invoice>>(a => a.UrlPath == "invoices/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Invoice>()));

            // Act
            var response = await _client.GetInvoice(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetInvoiceLineItemsTest()
        {
            // Arrange
            var filter = new InvoiceLineItemListFilter
            {
                InvoiceId = "invoice-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<InvoiceLineItemListFilter, Pagination<InvoiceLineItem>>>(
                    a => a.UrlPath == "invoices/" + filter.InvoiceId + "/lines" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<InvoiceLineItem>>()));

            // Act
            var response = await _client.GetInvoiceLineItems(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetUpcomingInvoicesTest()
        {
            // Arrange
            var filter = new UpcomingInvoiceArguments
            {
                Customer = "customer-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<UpcomingInvoiceArguments, Pagination<Invoice>>>(
                    a => a.UrlPath == "invoices/upcoming" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Invoice>>()));

            // Act
            var response = await _client.GetUpcomingInvoices(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateInvoiceTest()
        {
            // Arrange
            var args = new InvoiceCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<InvoiceCreateArguments, Invoice>>(a => a.UrlPath == "invoices" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Invoice>()));

            // Act
            var response = await _client.CreateInvoice(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateInvoiceTest()
        {
            // Arrange
            var args = new InvoiceUpdateArguments
            {
                InvoiceId = "invoice-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<InvoiceUpdateArguments, Invoice>>(
                    a => a.UrlPath == "invoices/" + args.InvoiceId && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Invoice>()));

            // Act
            var response = await _client.UpdateInvoice(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task PayInvoiceTest()
        {
            // Arrange
            var invoiceId = "invoice-id";
            _stripe.Post(Arg.Is<StripeRequest<Invoice>>(a => a.UrlPath == "invoices/" + invoiceId + "/pay"),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Invoice>()));

            // Act
            var response = await _client.PayInvoice(invoiceId, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}