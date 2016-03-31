using Newtonsoft.Json.Serialization;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Resolvers
{
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToSnakeCase();
        }
    }
}