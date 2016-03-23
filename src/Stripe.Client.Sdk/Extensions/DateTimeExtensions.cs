using System;

namespace Stripe.Client.Sdk.Extensions
{
    public static class DateTimeExtensions
    {
        private static DateTime _epochStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this long seconds)
        {
            return _epochStartDateTime.AddSeconds(seconds);
        }

        public static long ToEpoch(this DateTime datetime)
        {
            return Convert.ToInt64(datetime.Subtract(_epochStartDateTime).TotalSeconds);
        }
    }
}