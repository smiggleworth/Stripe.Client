using System.Collections.Generic;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IRefundClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<Refund>> GetRefund(string id, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<Refund>>> GetRefunds(RefundListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Refund>> CreateRefund(RefundCreateArguments arguments, CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Refund>> UpdateRefund(RefundUpdateArguments arguments, CancellationToken cancellationToken = default(CancellationToken));
    }
}