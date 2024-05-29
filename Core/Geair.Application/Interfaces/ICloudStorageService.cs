using Microsoft.AspNetCore.Http;

namespace Geair.Application.Interfaces
{
    public interface ICloudStorageService
    {

        Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave);
        Task DeleteFileAsync(string fileNameToDelete);
    }
}
