using Azure.Storage.Blobs;

namespace SeetourAPI.Services
{
    public class AzureBlobStorageService: IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureStorageAccount") ?? "");
            _containerName = _configuration.GetSection("AzureBlobStorage").GetValue<string>("ContainerName") ?? "";
        }

        public async Task<string> UploadBlobAsync(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(file.FileName);
            await blobClient.UploadAsync(file.OpenReadStream());
            return blobClient.Uri.ToString();
        }

        public async Task<Stream> DownloadBlobAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }

        public async Task DeleteBlobAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
