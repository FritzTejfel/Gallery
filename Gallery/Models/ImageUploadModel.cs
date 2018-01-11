using Microsoft.AspNetCore.Http;

namespace Gallery.Models
{
    public class ImageUploadModel
    {
        public string Title { get; set; }

        public string Tags { get; set; }

        public IFormFile ImageUpload { get; set; }
    }
}
