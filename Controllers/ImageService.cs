using store.Data;
using store.Models;
namespace store.Controllers
{
    public class ImageService
    {
        private readonly storeContext _context;

        public ImageService(storeContext context)
        {
            _context = context;
        }

        public async Task SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await imageFile.CopyToAsync(ms);
                    var image = new Image
                    {
                        ImageData = ms.ToArray()
                    };
                    _context.Images.Add(image);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

}
