using Newtonsoft.Json.Linq;
using Stripe.Client.Sdk.Models;
using System;

namespace Stripe.Client.Sdk.Helpers
{
    public static class Expandable<T> where T : IStripeModel
    {
        public static void Deserialize(object value, Action<string> updateId, Action<T> updateObject)
        {
            var o = value as JObject;
            if (o != null)
            {
                var item = o.ToObject<T>();
                updateId(item.Id);
                updateObject(item);
            }
            else if (value is string)
            {
                updateId((string) value);
                updateObject(default(T));
            }
        }
    }
}