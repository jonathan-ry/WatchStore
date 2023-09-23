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
        public async Task<ActionResult<BlobResponseDTO>> UploadPhoto(PhotoDTO photo)
        {
            BlobResponseDTO result = await _fileService.UploadAsync(photo);

            if (!String.IsNullOrEmpty(result.Blob.Uri)) return Ok(result);

            return BadRequest("Error in uploading photo");
        }
    }
}
