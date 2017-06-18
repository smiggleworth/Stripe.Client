using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;

namespace Stripe.Client.Sdk.Clients
{
    public interface IStripeClient : IDisposable
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<TResponse>> Get<TResponse>(StripeRequest<TResponse> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<TResponse>> Get<TRequest, TResponse>(StripeRequest<TRequest, TResponse> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<TResponse>> Post<TResponse>(StripeRequest<TResponse> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<TResponse>> Post<TRequest, TResponse>(StripeRequest<TRequest, TResponse> stripeRequest,
            CancellationToken cancellationToken);


        Task<StripeResponse<TResponse>> Upload<TRequest, TResponse>(StripeRequest<TRequest, TResponse> stripeRequest,
            CancellationToken cancellationToken)
            where TRequest : IFileUpload;

        Task<StripeResponse<TResponse>> Delete<TResponse>(StripeRequest<TResponse> stripeRequest,
            CancellationToken cancellationToken);
    }
}