using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Subscription
{
    public class PlanClient : IPlanClient
    {
        private readonly IStripeClient _client;

        public PlanClient(IStripeClient client)
        {
            _client = client;
        }

        public async Task<StripeResponse<Plan>> GetPlan(string planId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Plan>
            {
                UrlPath = PathHelper.GetPath(Paths.Plans, planId)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<Plan>>> GetPlans(PlanListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PlanListFilter, Pagination<Plan>>
            {
                UrlPath = Paths.Plans,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Plan>> CreatePlan(PlanCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PlanCreateArguments, Plan>
            {
                UrlPath = Paths.Plans,
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<Plan>> UpdatePlan(PlanUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<PlanUpdateArguments, Plan>
            {
                UrlPath = PathHelper.GetPath(Paths.Plans, arguments.PlanId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<DeletedObject>> DeletePlan(string planId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<DeletedObject>
            {
                UrlPath = PathHelper.GetPath(Paths.Plans, planId)
            };
            return await _client.Delete(request, cancellationToken);
        }
    }
}