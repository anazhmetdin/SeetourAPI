using Microsoft.AspNetCore.Mvc;
using SeetourAPI.Services;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models.Photos;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureImagesURLController : ControllerBase
    {
        #region Ijection
        private readonly IAzureBlobStorageService _azureBlobStorage;
        private readonly SeetourContext _context;

        public AzureImagesURLController(IAzureBlobStorageService azureBlobStorage, SeetourContext context)
        {
            _azureBlobStorage = azureBlobStorage;
            _context = context;
        }
        #endregion

        #region Uploading Image
        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            string url;
            try
            {
                url = await _azureBlobStorage.UploadBlobAsync(file);
            var imageInfo = new Photo
            {
                Id=0,
                Url = url

            };

            //Getting decoded URl
            _context.Photos.Add(imageInfo);
            _context.SaveChanges();
                return Ok(imageInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            // Return a response indicating the image was uploaded successfully
            return Ok();
        }
        #endregion


        #region Downloading Images

        //var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        //var blobClient = containerClient.GetBlobClient(fileName);
        //var response = await blobClient.DownloadAsync();
        //return response.Value.Content;

        #endregion


        #region Delete Image
        [HttpDelete]
        [Route("deleteimage")]
        public async Task<ActionResult> Deleteimage(string url)
        {
            var deleted = await _azureBlobStorage.DeleteBlobAsync(url);

            if (deleted)
                return Ok();

            return NotFound();
        }
        #endregion

        #region UploadImages
        [HttpPost]
        [Route("UploadImages")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            List<string> blobUrls;

            try
            {
                blobUrls = await _azureBlobStorage.UploadBlobAsyncImgs(files);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

            // Save Urls to database
            List<Photo> photos = new();
            blobUrls.ForEach(async url =>
            {
                var photo = new Photo() { Url = url };
                photos.Add(photo);
                await _context.AddAsync(photo);
            });

            await _context.SaveChangesAsync();

            return Ok(photos);
        }
        #endregion

        #region GetImageByURL
        [HttpGet]
        [Route("GetImageByUrl")]
        public async Task<IActionResult> GetImage(string URL)
        {
            var imageStream = await _azureBlobStorage.GetImageAsync(URL);
            return new FileStreamResult(imageStream, "image/*");
        }
        #endregion
        //[HttpGet("{imageName}")]
        //public async Task<IActionResult> GetImage(string imageName)
        //{
        //    var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        //    var blobClient = containerClient.GetBlobClient(imageName);
        //    var response = await blobClient.DownloadAsync();

        //    return File(response.Value.Content, response.Value.ContentType);
        //}
    }

}