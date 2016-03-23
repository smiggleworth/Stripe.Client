using System.Collections.Generic;

namespace Stripe.Client.Sdk.Models
{
    public class Balance
    {
        public string Object { get; set; }

        public List<BalanceAmount> Available { get; set; }

        public bool LiveMode { get; set; }

        public List<BalanceAmount> Pending { get; set; }

        public Balance()
        {
            Available = new List<BalanceAmount>();
            Pending = new List<BalanceAmount>();
        }
    }
}