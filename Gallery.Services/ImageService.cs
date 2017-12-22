using System.Collections.Generic;
using System.Linq;
using Gallery.Data;
using Gallery.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Services
{
    public class ImageService : IImage
    {
        private readonly GalleryDbContext _ctx;

        public ImageService(GalleryDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return _ctx.GalleryImages
                .Include(img => img.Tags);
        }

        public GalleryImage GetById(int id)
        {
            return GetAll()
                .Where(img => img.Id == id)
                .First();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetAll()
                .Where(
                img => img.Tags.Any(t => t.Description == tag));
        }
    }
}
