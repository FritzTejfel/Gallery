using Microsoft.AspNetCore.Mvc;
using Gallery.Models;
using Gallery.Data;

namespace Gallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IImage _imageService;

        public GalleryController(IImage imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var imagelist = _imageService.GetAll();

            var model = new GalleryIndexModel()
            {
                Images = imagelist,
                SearchQuery = ""

            };

            return View(model);
        }
    }
}