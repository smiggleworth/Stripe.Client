using System.Collections.Generic;
using Stripe.Client.Sdk.Constants;
using Stripe.Client.Sdk.Helpers;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace Stripe.Client.Sdk.Clients.Connect
{
    public class ApplicationFeeClient : IApplicationFeeClient
    {
        private readonly IStripeClient _client;

        public ApplicationFeeClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<ApplicationFee>> GetApplicationFee(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFee>
            {
                UrlPath = PathHelper.GetPath(Paths.ApplicationFees, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<ApplicationFee>>> GetApplicationFees(
            ApplicationFeeListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFeeListFilter, Pagination<ApplicationFee>>
            {
                UrlPath = Paths.ApplicationFees,
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<ApplicationFeeRefund>> GetApplicationFeeRefund(string id,
            string applicationFeeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFeeRefund>
            {
                UrlPath = PathHelper.GetPath(Paths.ApplicationFees, applicationFeeId, Paths.Refunds, id)
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<ApplicationFeeRefund>>> GetApplicationFeeRefunds(
            ApplicationFeeRefundListFilter filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFeeRefundListFilter, Pagination<ApplicationFeeRefund>>
            {
                UrlPath = PathHelper.GetPath(Paths.ApplicationFees, filter.ApplicationFeeId, Paths.Refunds),
                Model = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<ApplicationFeeRefund>> CreateApplicationFeeRefund(
            ApplicationFeeRefundCreateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFeeRefundCreateArguments, ApplicationFeeRefund>
            {
                UrlPath = PathHelper.GetPath(Paths.ApplicationFees, arguments.ApplicationFeeId, Paths.Refunds),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }

        public async Task<StripeResponse<ApplicationFeeRefund>> UpdateApplicationFeeRefund(
            ApplicationFeeRefundUpdateArguments arguments,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<ApplicationFeeRefundUpdateArguments, ApplicationFeeRefund>
            {
                UrlPath =
                    PathHelper.GetPath(Paths.ApplicationFees, arguments.ApplicationFeeId, Paths.Refunds, arguments.ApplicationFeeRefundId),
                Model = arguments
            };
            return await _client.Post(request, cancellationToken);
        }
    }
}