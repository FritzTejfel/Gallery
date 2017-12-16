using Microsoft.AspNetCore.Mvc;
using Gallery.Models;
using System.Collections.Generic;
using Gallery.Data.Models;
using System;

namespace Gallery.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            var hikingImageTags = new List<ImageTag>();
            var cityImageTags = new List<ImageTag>();

            var tag1 = new ImageTag()
            {
                Description = "Adventure",
                Id = 0
            };

            var tag2 = new ImageTag()
            {
                Description = "Urban",
                Id = 1
            };

            var tag3 = new ImageTag()
            {
                Description = "New York",
                Id = 2
            };

            hikingImageTags.Add(tag1);
            cityImageTags.AddRange(new List<ImageTag> { tag2, tag3 });

            var imagelist = new List<GalleryImage>()
            {
                new GalleryImage()
                {
                    Title = "Hiking Trip",
                    Url = "https://static.pexels.com/photos/414171/pexels-photo-414171.jpeg",
                    Created = DateTime.Now,
                    Tags = hikingImageTags
                },

                new GalleryImage()
                {
                    Title = "On the Trail",
                    Url = "https://static.pexels.com/photos/315938/pexels-photo-315938.jpeg",
                    Created = DateTime.Now,
                    Tags = cityImageTags
                },

                new GalleryImage()
                {
                    Title = "Downtown",
                    Url = "https://static.pexels.com/photos/373912/pexels-photo-373912.jpeg",
                    Created = DateTime.Now,
                    Tags = cityImageTags
                }
            };

            var model = new GalleryIndexModel()
            {
                Images = imagelist,
                SearchQuery = ""

            };

            return View(model);
        }
    }
}