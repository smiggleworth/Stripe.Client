using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Connect;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Connect
{
    [TestClass]
    public class RecipientClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IRecipientClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new RecipientClient(_stripe);
        }

        [TestMethod]
        public async Task GetRecipientTest()
        {
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<Recipient>>(a => a.UrlPath == "recipients/" + id), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Recipient>()));
            var response = await _client.GetRecipient(id, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetRecipientsTest()
        {
            var filter = new RecipientListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<RecipientListFilter, Pagination<Recipient>>>(
                    a => a.UrlPath == "recipients" && a.Model == filter), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Pagination<Recipient>>()));
            var response = await _client.GetRecipients(filter, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateRecipientTest()
        {
            var args = new RecipientCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<RecipientCreateArguments, Recipient>>(
                    a => a.UrlPath == "recipients" && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Recipient>()));
            var response = await _client.CreateRecipient(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateRecipientTest()
        {
            var args = new RecipientUpdateArguments
            {
                Id = "some-value"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<RecipientUpdateArguments, Recipient>>(
                    a => a.UrlPath == "recipients/" + args.Id && a.Model == args), _cancellationToken)
                .Returns(Task.FromResult(new StripeResponse<Recipient>()));
            var response = await _client.UpdateRecipient(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCardTest()
        {
            var recipientId = "ACC_1234";
            var id = "ID_VALUE";
            _stripe.Get(Arg.Is<StripeRequest<Card>>(a => a.UrlPath == "recipients/" + recipientId + "/cards/" + id),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));
            var response = await _client.GetCard(id, recipientId, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetCardsTest()
        {
            var filter = new RecipientCardListFilter
            {
                RecipientId = "recipient-id"
            };
            _stripe.Get(
                Arg.Is<StripeRequest<RecipientCardListFilter, Pagination<Card>>>(
                    a => a.UrlPath == "recipients/" + filter.RecipientId + "/cards" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Card>>()));
            var response = await _client.GetCards(filter, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreateCardTest()
        {
            var args = new RecipientCardCreateArguments
            {
                RecipientId = "recipient-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<RecipientCardCreateArguments, Card>>(
                    a => a.UrlPath == "recipients/" + args.RecipientId + "/cards" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));
            var response = await _client.CreateCard(args, _cancellationToken);
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdateCardTest()
        {
            var args = new RecipientCardUpdateArguments
            {
                CardId = "some-value",
                RecipientId = "parent-id"
            };
            _stripe.Post(
                Arg.Is<StripeRequest<RecipientCardUpdateArguments, Card>>(
                    a => a.UrlPath == "recipients/" + args.RecipientId + "/cards/" + args.CardId && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Card>()));
            var response = await _client.UpdateCard(args, _cancellationToken);
            response.Should().NotBeNull();
        }
    }
}