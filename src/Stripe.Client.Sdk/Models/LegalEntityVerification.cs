using Newtonsoft.Json;
using Stripe.Client.Sdk.Helpers;

namespace Stripe.Client.Sdk.Models
{
    public class LegalEntityVerification
    {
        public string Details { get; set; }

        public string DetailsCode { get; set; }

        [JsonIgnore]
        public string DocumentId { get; set; }

        [JsonIgnore]
        public FileUpload DocumentModel { get; set; }

        public object Document
        {
            set { Expandable<FileUpload>.Deserialize(value, s => DocumentId = s, o => DocumentModel = o); }
        }

        public string Status { get; set; }
    }
}