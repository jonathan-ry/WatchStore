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
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IWatchRepository _watchRepository;

        public WatchesController(IMapper mapper
            ,IFileService fileService, IWatchRepository watchRepository)
        {
            _mapper = mapper;
            _fileService = fileService;
            _watchRepository = watchRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
        {
            var watches = await _watchRepository.GetWatchesAsync();
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

            var item = await _watchRepository.GetWatchByItemNumberAsync(watch.ItemNumber);

            if(item != null)
            {
                return BadRequest("Item Number already exist");
            }

            if(watch.Photo != null)
            {
                BlobResponseDTO blobResult = await _fileService.UploadAsync(watch.Photo);
                newWatch.PhotoUri = blobResult.Blob.Uri;
            }

            await _watchRepository.AddItemAsync(newWatch);
            
            if(await _watchRepository.SaveAllAsync()) return Ok(newWatch);

            return BadRequest("Problem adding watch");
        }

        [HttpDelete("remove-item/id/{id}")]
        public async Task<ActionResult<Watch>> DeleteWatchById(int id)
        {
            var watch = await _watchRepository.DeleteWatchByIdAsync(id);

            if (await _watchRepository.SaveAllAsync()) return Ok(watch);

            return BadRequest("Problem deleting watch");
        }

        [HttpDelete("remove-item/item-no/{itemNumber}")]
        public async Task<ActionResult<Watch>> DeleteWatchByItemNumber(string itemNumber)
        {
            var watch = await _watchRepository.DeleteWatchByItemNumberAsync(itemNumber);

            if (await _watchRepository.SaveAllAsync()) return Ok(watch);

            return BadRequest("Problem deleting watch");
        }

        [HttpPut("update")]
        public async Task<ActionResult<Watch>> UpdateWatch(Watch watch)
        {
             _watchRepository.UpdateWatch(watch);
            if (await _watchRepository.SaveAllAsync()) return Ok(watch);

            return BadRequest("Problem updating watch");
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Watch>> GetWatchById(int id)
        {
            var watch = await _watchRepository.GetWatchByIdAsync(id);
            if (watch != null) return Ok(watch);

            return BadRequest("No result found");
        }

        [HttpGet("item/{itemNumber}")]
        public async Task<ActionResult<Watch>> GetWatchByItemNumber(string itemNumber)
        {
            var watch = await _watchRepository.GetWatchByItemNumberAsync(itemNumber);
            if (watch != null) return Ok(watch);

            return BadRequest("No result found");
        }

    }
}
