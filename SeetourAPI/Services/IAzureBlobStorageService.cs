using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace SeetourAPI.Services
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadBlobAsync(IFormFile file);
        // Task<Stream> DownloadBlobAsync(string fileName);
        Task<bool> DeleteBlobAsync(string fileUrl);
        Task<List<string>> UploadBlobAsyncImgs(List<IFormFile> files);

    }
}