using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallery.Data;
using Gallery.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

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

        public CloudBlobContainer GetCloudBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetImage(string title, string tags, Uri uri)
        {
            var image = new GalleryImage
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _ctx.Add(image);
            await _ctx.SaveChangesAsync();
        }

        public List<ImageTag> ParseTags(string tags)
        {
            //var tagList = tags.Split(",").ToList().Select(tag => new ImageTag { Description = tag });

            //var imageTags = new List<ImageTag>();

            //foreach(var tag in tagList)
            //{
            //    imageTags
            //        .Add(new ImageTag() {
            //            Description = tag
            //        });
            //}

            //return imageTags;

            return tags.Split(",")
                .ToList()
                .Select(tag => new ImageTag { Description = tag })
                .ToList();
        }
    }
}
