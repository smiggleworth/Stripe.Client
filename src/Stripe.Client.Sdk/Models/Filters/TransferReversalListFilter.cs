using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Client.Sdk.Models.Filters
{
    public class TransferReversalListFilter : ListFilter
    {
        [JsonIgnore]
        [Required]
        public string TransferId { get; set; }
    }
}