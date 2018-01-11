using Gallery.Data.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gallery.Data
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();
        IEnumerable<GalleryImage> GetWithTag(string tag);
        GalleryImage GetById(int id);
        CloudBlobContainer GetCloudBlobContainer(string connectionString, string containerName);
        Task SetImage(string title, string atgs, Uri uri);
        List<ImageTag> ParseTags(string tags);
    }
}
