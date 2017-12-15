using Gallery.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Data
{
    public class GalleryDbContext : DbContext 
    {
        public GalleryDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
    }
}
