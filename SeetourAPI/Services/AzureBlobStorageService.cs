using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

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

        #region UploadOneImage
        public async Task<string> UploadBlobAsync(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(file.FileName);
            await blobClient.UploadAsync(file.OpenReadStream());
            return blobClient.Uri.ToString();
        }
        #endregion

        //public async Task<Stream> DownloadBlobAsync(string fileName)
        //{
        //    var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        //    var blobClient = containerClient.GetBlobClient(fileName);
        //    var response = await blobClient.DownloadAsync();
        //    return response.Value.Content;
        //}

        #region Delete Image
        public async Task DeleteBlobAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }


        #endregion

        #region UploadingImages
        public async Task<List<string>> UploadBlobAsyncImgs(List<IFormFile> files)
        {
            var blobUrls = new List<string>();
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

            foreach (var file in files)
            {
                var blobClient = containerClient.GetBlobClient(file.FileName);

                await blobClient.UploadAsync(file.OpenReadStream());

                blobUrls.Add(blobClient.Uri.ToString());
            }

            return blobUrls;
        }
        #endregion
    }
}
