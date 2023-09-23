using API.DTO;
using API.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly string _storageAccount = "imgstoreacn";
        private readonly string _key = "DefaultEndpointsProtocol=https;AccountName=imagestoreacn;AccountKey=D+G2wImj/Eg57MxVoTUL9QA/UoIhC1k2gjg3Bp5fk4iHzFsTjT3isNLdDqCCzyH3Ud83393pskPY+AStDndaUA==;EndpointSuffix=core.windows.net";
        private readonly BlobContainerClient _filesContainer;

        public FileService()
        {
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(_key);
            _filesContainer = blobServiceClient.GetBlobContainerClient("photocontainer");
        }

        public async Task<BlobResponseDTO> UploadAsync([FromBody] PhotoDTO model)
        {
            byte[] binaryData = Convert.FromBase64String(model.Base64Data);

            BlobResponseDTO response = new();

            string uniqueId = Guid.NewGuid().ToString();

            var ImageFileName = uniqueId + model.FileName;

            BlobClient client = _filesContainer.GetBlobClient(ImageFileName);

            // Upload the binary data to Azure Blob Storage
            using (var stream = new MemoryStream(binaryData))
            {
                await client.UploadAsync(stream, true);
            }

            response.Status = $"File {ImageFileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }
    }
}
