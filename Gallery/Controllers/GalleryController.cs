using Microsoft.AspNetCore.Mvc;
using Gallery.Models;

namespace Gallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var model = new GalleryIndexModel()
            {

            };

            return View(model);
        }
    }
}