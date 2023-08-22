using API.DTO;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FilesController : BaseApiController
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload-file")]
        public async Task<BlobResponseDTO> UploadPhoto(IFormFile file)
        {
            BlobResponseDTO result = await _fileService.UploadAsync(file);
            return result;
        }
    }
}
