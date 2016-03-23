using System;

namespace Stripe.Client.Sdk.Models
{
    public class StripeRequest<TResponse>
    {
        public StripeRequest()
        {
            IdempotencyKey = Guid.NewGuid();
        }

        public Guid IdempotencyKey { get; set; }

        public string UrlPath { get; set; }
    }

    public class StripeRequest<TRequest, TResponse> : StripeRequest<TResponse>
    {
        public TRequest Model { get; set; }
    }
}