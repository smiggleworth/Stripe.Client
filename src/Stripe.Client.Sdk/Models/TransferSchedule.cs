namespace Stripe.Client.Sdk.Models
{
    public class TransferSchedule
    {
        public int DelayDays { get; set; }

        public string Interval { get; set; }

        public int MonthlyAnchor { get; set; }

        public string WeeklyAnchor { get; set; }
    }
}