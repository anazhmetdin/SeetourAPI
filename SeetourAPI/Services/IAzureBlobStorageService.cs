namespace SeetourAPI.Services
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadBlobAsync(IFormFile file);
        Task<Stream> DownloadBlobAsync(string fileName);
        Task DeleteBlobAsync(string fileName);
    }
}
