namespace Stripe.Client.Sdk.Models.Filters
{
    public abstract class ListFilter
    {
        public int? Limit { get; set; }

        public string StartingAfter { get; set; }

        public string EndingBefore { get; set; }
    }
}