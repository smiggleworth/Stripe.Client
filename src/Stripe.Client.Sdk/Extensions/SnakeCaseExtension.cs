namespace Stripe.Client.Sdk.Extensions
{
    public static class SnakeCaseExtension
    {
        public static string ToSnakeCase(this string propertyName)
        {
            for (var i = propertyName.Length - 1; i > 0; i--)
            {
                if (i > 0)
                {
                    var c = propertyName[i];
                    var p = propertyName[i - 1];
                    if (char.IsUpper(c) && !char.IsUpper(p))
                    {
                        propertyName = propertyName.Insert(i, "_");
                    }
                }
            }
            return propertyName.ToLower();
        }
    }
}