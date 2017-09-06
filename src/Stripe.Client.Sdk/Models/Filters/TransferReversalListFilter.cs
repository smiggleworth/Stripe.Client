using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class TransferReversalListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string TransferId { get; set; }
    }
}