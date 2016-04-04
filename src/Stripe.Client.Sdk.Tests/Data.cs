using Stripe.Client.Sdk.Models.Filters;
using System;
using System.Collections.Generic;

namespace Stripe.Client.Sdk.Tests
{
    public class Data
    {
        public static Dictionary<string, string> Metadata = new Dictionary<string, string>
        {
            {"key1", "value 1"},
            {"key2", "value 2"},
        };

        public static Dictionary<string, string> Attributes = new Dictionary<string, string>
        {
            {"size", "medium"},
            {"color", "green"},
        };

        public static DateFilter DateFilter = new DateFilter
        {
            Gt = DateTime.UtcNow,
            Lt = DateTime.UtcNow,
            Gte = DateTime.UtcNow,
            Lte = DateTime.UtcNow
        };
    }
}
