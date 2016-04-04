using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Arguments
{
    public class ChargeCaptureArguments
    {
        [JsonIgnore]
        [Required]
        public string ChargeId { get; set; }

        public int? Amount { get; set; }

        public int? ApplicationFee { get; set; }

        public string ReceiptEmail { get; set; }

        public string StatementDescriptor { get; set; }
    }
}