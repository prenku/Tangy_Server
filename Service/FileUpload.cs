using Microsoft.AspNetCore.Components.Forms;
using TangyWeb_Server.Service.IService;

namespace TangyWeb_Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public bool DeleteFile(string filePath)
        {

            if (File.Exists(_environment.WebRootPath + filePath))
            {
                File.Delete(_environment.WebRootPath + filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var productFolder = $"{_environment.WebRootPath}\\images\\product";

            if (!Directory.Exists(productFolder))
            {
                Directory.CreateDirectory(productFolder);
            }
            var filePath = Path.Combine(productFolder, fileName);
            await using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);
            var fullPath = $"/images/product/{fileName}";
            return fullPath;
        }
    }
}
