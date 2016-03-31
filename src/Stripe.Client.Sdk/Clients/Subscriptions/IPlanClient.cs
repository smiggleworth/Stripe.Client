using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Subscriptions
{
    public interface IPlanClient
    {
        Task<StripeResponse<Plan>> GetPlan(string planId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Plan>>> GetPlans(PlanListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Plan>> CreatePlan(PlanCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Plan>> UpdatePlan(PlanUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<DeletedObject>> DeletePlan(string planId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}