using API.DTO;

namespace API.Interfaces
{
    public interface IFileService
    {
        Task<BlobResponseDTO> UploadAsync(PhotoDTO model);
    }
}
