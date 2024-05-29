
using Geair.Application.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Geair.Persistance.Repositories
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly GoogleCredential googleCredential;
        private readonly StorageClient storageClient;
        private readonly string bucketName;


        public CloudStorageService(IConfiguration configuration)
        {
            googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("GoogleCredentialFile"));
            storageClient = StorageClient.Create(googleCredential);
            bucketName = configuration.GetValue<string>("GoogleCloudStorageBucket");
        }

        public async Task DeleteFileAsync(string fileNameToDelete)
        {
            await storageClient.DeleteObjectAsync(bucketName, fileNameToDelete);
        }

        public async Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave)
        {
            using (var memoryStream = new MemoryStream())
            {
                await fileToUpload.CopyToAsync(memoryStream);
                var dataObject = await storageClient.UploadObjectAsync(bucketName, fileNameToSave, null, memoryStream);
                return dataObject.MediaLink;
            }
        }



    }
}
