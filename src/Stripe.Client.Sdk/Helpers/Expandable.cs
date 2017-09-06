using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Resolvers;

namespace Stripe.Client.Sdk.Helpers
{
    public static class Expandable<T> where T : IStripeModel
    {
        private static Lazy<JsonSerializer> SnakeCaseJsonSerializer => new Lazy<JsonSerializer>(() => JsonSerializer.CreateDefault(new JsonSerializerSettings
        {
            ContractResolver = new SnakeCaseContractResolver()
        }));

        public static void Deserialize(object value, Action<string> updateId, Action<T> updateObject)
        {
            var o = value as JObject;
            if (o != null)
            {
                var item = o.ToObject<T>(SnakeCaseJsonSerializer.Value);
                updateId(item.Id);
                updateObject(item);
            }
            else if (value is string)
            {
                updateId((string)value);
                updateObject(default(T));
            }
        }
    }
}