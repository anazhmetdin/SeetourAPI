using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace SeetourAPI.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {

        #region Injection
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;
        private readonly int maxFileSize;
        private readonly string[] AllowedExtensions;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;

            maxFileSize = _configuration.GetSection("AzureBlobStorage").GetValue<int>("maxFileSize");
            AllowedExtensions = _configuration.GetSection("AzureBlobStorage:AllowedExtensions").Get<string[]>() ?? new string[0];

            _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("AzureStorageAccount") ?? "");
            _containerName = _configuration.GetSection("AzureBlobStorage").GetValue<string>("ContainerName") ?? "";
        }
        #endregion

        #region UploadOneImage
        public async Task<string> UploadBlobAsync(IFormFile file)
        {
            CheckFileAllowed(file);

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(GetUniqueName(file.FileName));

            try
            {
                await blobClient.UploadAsync(file.OpenReadStream());
            }
            catch
            {
                throw new Exception($"Couldn't upload {file.Name}, please try again later");
            }

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
        public async Task<bool> DeleteBlobAsync(string fileUrl)
        {
            //Get the last segment in the URL
            Uri uri = new Uri(fileUrl);
            string lastSegment = uri.Segments.LastOrDefault()!;

            //Encoding The Spaces in the Last segment
            string fileName = Uri.UnescapeDataString(lastSegment);
            // Console.WriteLine(lastSegmentDecoded);

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            return await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }
        #endregion

        #region GetImage
        public async Task<Stream> GetImageAsync(string fileUrl)
        {
            //Get the last segment in the URL
            Uri uri = new Uri(fileUrl);
            string lastSegment = uri.Segments.LastOrDefault()!;

            //Encoding The Spaces in the Last segment
            string fileName = Uri.UnescapeDataString(lastSegment);
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            // Check if the image exists before downloading it
            if (!await blobClient.ExistsAsync())
            {
                throw new Exception($"There is no image with '  {fileName} ' name is exicted ");
                // or throw an exception or return a default image, depending on your use case
            }
            var response = await blobClient.DownloadAsync();

            return response.Value.Content;
        }
        #endregion


        #region UploadingImages
        public async Task<List<string>> UploadBlobAsyncImgs(List<IFormFile> files)
        {
            var blobUrls = new List<string>();

            foreach (var file in files)
            {
                blobUrls.Add(await UploadBlobAsync(file));
            }

            return blobUrls;
        }
        #endregion


        #region TestFunctions
        private static string GetUniqueName(string name)
        {
            return $"{DateTime.Now.Ticks}_{name}";
        }

        private void CheckFileAllowed(IFormFile file)
        {
            CheckIsImage(file);
            CheckFileSize(file);
        }

        private void CheckFileSize(IFormFile file)
        {
            if (file.Length >024L * 1024 * maxFileSize)
                throw new Exception($"File {file.FileName} exceeds size limit of {maxFileSize} MB");
        }

        private void CheckIsImage(IFormFile file)
        {
            if (!file.ContentType.StartsWith("image/") || AllowedExtensions?.Contains(Path.GetExtension(file.Name)) == true)
                throw new Exception($"File {file.FileName} has an unsupported extension. Supported files are: {string.Join(' ', AllowedExtensions)}");
        }

        #endregion

        #region GetImageV1
        //[HttpGet("{imageName}")]
        //public IActionResult GetImage(string fileUrl)
        //{

        //Uri uri = new Uri(fileUrl);
        //string lastSegment = uri.Segments.LastOrDefault()!;

        ////Encoding The Spaces in the Last segment
        //string fileName = Uri.UnescapeDataString(lastSegment);
        //// Console.WriteLine(lastSegmentDecoded);

        //var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        //var blobClient = containerClient.GetBlobClient(fileName);



        //// Check if the blob exists
        //if (!blobClient.Exists())
        //    {
        //        return NotFound();
        //    }

        //    // Download the image data to a memory stream
        //    MemoryStream memoryStream = new MemoryStream();
        //     blobClient.DownloadToStream(memoryStream);

        //    // Set the content type of the response based on the image file type
        //    string contentType = blob.Properties.ContentType;
        //    HttpContext.Response.ContentType = contentType;

        //    // Return the image data as the response body
        //    return File(memoryStream.ToArray(), contentType);
        //}
        #endregion



    }
}













