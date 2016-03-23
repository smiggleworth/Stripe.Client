namespace Stripe.Client.Sdk.Models.Arguments
{
    public class TransferScheduleArguments
    {
        /// <summary>
        /// The number of days charges for the account will be held before being paid out. May also be the string “minimum” for the lowest available value (based on country). Default is “minimum”. Does not apply when interval is “manual”.
        /// </summary>
        public int DelayDays { get; set; }

        /// <summary>
        /// How frequently funds will be paid out. One of manual (for only triggered via API call), daily, weekly, or monthly. Default is daily.
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// The day of the month funds will be paid out. Required and available only if interval is monthly.
        /// </summary>
        public int MonthlyAnchor { get; set; }

        /// <summary>
        /// The day of the week funds will be paid out, of the style ‘monday’, ‘tuesday’, etc. Required and available only if interval is weekly.
        /// </summary>
        public string WeeklyAnchor { get; set; }
    }
}