namespace Stripe.Client.Sdk.Models.Arguments
{
    public class FileUploadCreateArguments : IFileUpload
    {
        public string Purpose { get; set; }
        public byte[] File { get; set; }
    }
}