using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stripe.Client.Sdk.Clients;
using Stripe.Client.Sdk.Clients.Core;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Tests.Clients.Core
{
    [TestClass]
    public class EventClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IEventClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new EventClient(_stripe);
        }

        [TestMethod]
        public async Task GetEventTest()
        {
            // Arrange
            var id = "event-id";
            _stripe.Get(Arg.Is<StripeRequest<Event>>(a => a.UrlPath == "events/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Event>()));

            // Act
            var response = await _client.GetEvent(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetEventsTest()
        {
            // Arrange
            var filter = new EventListFilter();
            _stripe.Get(
                       Arg.Is<StripeRequest<EventListFilter, Pagination<Event>>>(
                           a => a.UrlPath == "events" && a.Model == filter), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Pagination<Event>>()));

            // Act
            var response = await _client.GetEvents(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}