using BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string?> UploadAsync(IFormFile? file, string folderName)
        {
            if (file == null) return null;

            var uploadPath = Path.Combine(_env.WebRootPath, folderName);

            Directory.CreateDirectory(uploadPath);

            var uniqueName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(uploadPath, uniqueName);

            using var fs = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(fs);

            return $"{folderName}/{uniqueName}";
        }

        public void Delete(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl)||imageUrl=="images/Icon.png")
                return;

            var fullPath = Path.Combine(_env.WebRootPath, imageUrl.TrimStart('/'));

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }

}
