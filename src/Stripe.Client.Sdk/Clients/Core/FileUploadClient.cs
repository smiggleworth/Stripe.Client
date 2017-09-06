using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public class FileUploadClient : IFileUploadClient
    {
        private readonly IStripeClient _client;
        private readonly string _path = "files";

        public FileUploadClient(IStripeClient client)
        {
            _client = client;
            _client.Expandables = Expandables = new List<string>();
        }

        public List<string> Expandables { get; set; }

        public async Task<StripeResponse<FileUpload>> GetFileUpload(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<FileUpload>
            {
                UrlPath = _path + "/" + id,
                Data = id
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<Pagination<FileUpload>>> GetFileUploads(FileUploadListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<Pagination<FileUpload>>
            {
                UrlPath = _path,
                Data = filter
            };
            return await _client.Get(request, cancellationToken);
        }

        public async Task<StripeResponse<FileUpload>> CreateFileUpload(FileUploadCreateArguments upload,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new StripeRequest<FileUpload>
            {
                UrlPath = _path,
                Data = upload
            };

            return await _client.Upload(request, cancellationToken);
        }
    }
}