using Microsoft.AspNetCore.Components.Forms;

namespace TangyWeb_Server.Service.IService
{
    public interface IFileUpload
    {
        public Task<string> UploadFile(IBrowserFile file);
        public bool DeleteFile(string filePath);
    }
}
