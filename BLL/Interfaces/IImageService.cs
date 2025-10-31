using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IImageService
    {
        Task<string?> UploadAsync(IFormFile? file, string folderName);
        void Delete(string? imageUrl);
    }

}
