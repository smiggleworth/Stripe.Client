using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Client.Sdk.Models;
using Stripe.Client.Sdk.Models.Arguments;
using Stripe.Client.Sdk.Models.Filters;

namespace Stripe.Client.Sdk.Clients.Core
{
    public interface IFileUploadClient
    {
        List<string> Expandables { get; set; }

        Task<StripeResponse<FileUpload>> GetFileUpload(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<Pagination<FileUpload>>> GetFileUploads(FileUploadListFilter filter,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<StripeResponse<FileUpload>> CreateFileUpload(FileUploadCreateArguments upload,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}