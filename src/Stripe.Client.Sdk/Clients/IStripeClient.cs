using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;

namespace Stripe.Client.Sdk.Clients
{
    public interface IStripeClient : IDisposable
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<T>> Get<T>(StripeRequest<T> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<T>> Post<T>(StripeRequest<T> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<T>> Upload<T>(StripeRequest<T> stripeRequest,
            CancellationToken cancellationToken);

        Task<StripeResponse<T>> Delete<T>(StripeRequest<T> stripeRequest,
            CancellationToken cancellationToken);
    }
}