using API.DTO;
using API.Interfaces;
using Azure.Storage.Blobs;

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

        public async Task<BlobResponseDTO> UploadAsync(IFormFile blob)
        {
            BlobResponseDTO response = new();

            string uniqueId = Guid.NewGuid().ToString();
            var ImageFileName = uniqueId + blob.FileName;

            BlobClient client = _filesContainer.GetBlobClient(ImageFileName);

            await using (Stream data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {ImageFileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }
    }
}
