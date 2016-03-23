using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Serialization;
using Stripe.Client.Sdk.Extensions;

namespace Stripe.Client.Sdk.Resolvers
{
    [ExcludeFromCodeCoverage]
    public class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToSnakeCase();
        }
    }
}