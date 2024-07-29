using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ImagesController : ControllerBase
    {
        private readonly ImageService _imageService;

        public ImagesController(ImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage( IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Image file is empty.");
            }

            await _imageService.SaveImageAsync(imageFile);
            return Ok();
        }
    }


}
