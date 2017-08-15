using System;

namespace Stripe.Client.Sdk.Models
{
    public class StripeRequest<TResponse>
    {
        public Guid IdempotencyKey { get; set; }

        public string UrlPath { get; set; }

        public object Data { get; set; }

        public StripeRequest()
        {
            IdempotencyKey = Guid.NewGuid();
        }
    }

    public class StripeRequest<TRequest, TResponse> : StripeRequest<TResponse>
    {
        public TRequest Model { get; set; }
    }
}