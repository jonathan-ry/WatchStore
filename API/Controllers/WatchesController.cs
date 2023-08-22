using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class WatchesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public WatchesController(DataContext context, IMapper mapper
            ,IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
        {
            var watches = await _context.Watches.Where(x => x.IsDeleted == false).ToListAsync();
            return Ok(watches);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Watch>> AddWatch(WatchDTO watch)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }

            var newWatch = _mapper.Map<Watch>(watch);

            if(watch.Photo != null)
            {
                BlobResponseDTO blobResult = await _fileService.UploadAsync(watch.Photo);
                newWatch.PhotoUri = blobResult.Blob.Uri;
            }

            _context.Add(newWatch);
            await _context.SaveChangesAsync();

            return Ok(newWatch);
        }

        [HttpDelete("remove-item/{itemNumber}")]
        public async Task<ActionResult<Watch>> DeleteWatch(int itemNumber)
        {
            var watch = await _context.Watches.FirstOrDefaultAsync(x => x.Id == itemNumber);
            if(watch != null) 
            {
                watch.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return Ok(watch);
        }


    }
}
