using System.Linq;

namespace Stripe.Client.Sdk.Helpers
{
    public class PathHelper
    {
        public static string GetPath(params string[] parts)
        {
            return string.Join("/", parts.Select(x => x.TrimStart('/').TrimEnd('/').Trim()));
        }
    }
}