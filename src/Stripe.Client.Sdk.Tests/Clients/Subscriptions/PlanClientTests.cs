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
    public class PlanClientTests
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;
        private IPlanClient _client;
        private IStripeClient _stripe;

        [TestInitialize]
        public void Init()
        {
            _stripe = Substitute.For<IStripeClient>();
            _client = new PlanClient(_stripe);
        }

        [TestMethod]
        public async Task GetPlanTest()
        {
            // Arrange
            var id = "plan-id";
            _stripe.Get(Arg.Is<StripeRequest<Plan>>(a => a.UrlPath == "plans/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Plan>()));

            // Act
            var response = await _client.GetPlan(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task GetPlansTest()
        {
            // Arrange
            var filter = new PlanListFilter();
            _stripe.Get(
                Arg.Is<StripeRequest<PlanListFilter, Pagination<Plan>>>(a => a.UrlPath == "plans" && a.Model == filter),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Pagination<Plan>>()));

            // Act
            var response = await _client.GetPlans(filter, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task CreatePlanTest()
        {
            // Arrange
            var args = new PlanCreateArguments();
            _stripe.Post(
                Arg.Is<StripeRequest<PlanCreateArguments, Plan>>(a => a.UrlPath == "plans" && a.Model == args),
                _cancellationToken).Returns(Task.FromResult(new StripeResponse<Plan>()));

            // Act
            var response = await _client.CreatePlan(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task UpdatePlanTest()
        {
            // Arrange
            var args = new PlanUpdateArguments
            {
                PlanId = "plan-id"
            };
            _stripe.Post(
                       Arg.Is<StripeRequest<PlanUpdateArguments, Plan>>(
                           a => a.UrlPath == "plans/" + args.PlanId && a.Model == args), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<Plan>()));

            // Act
            var response = await _client.UpdatePlan(args, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public async Task DeletePlanTest()
        {
            // Arrange
            var id = "plan-id";
            _stripe.Delete(Arg.Is<StripeRequest<DeletedObject>>(a => a.UrlPath == "plans/" + id), _cancellationToken)
                   .Returns(Task.FromResult(new StripeResponse<DeletedObject>()));

            // Act
            var response = await _client.DeletePlan(id, _cancellationToken);

            // Assert
            response.Should().NotBeNull();
        }
    }
}