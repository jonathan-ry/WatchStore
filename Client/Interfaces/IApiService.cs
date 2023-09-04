using Client.DTO;
using Client.ViewModels;

namespace Client.Interfaces
{
    public interface IApiService
    {
        Task<WatchViewModel> CreateWatchAsync(CreateViewModel model);
        Task<IEnumerable<WatchViewModel>> GetWatchListAsync();
        Task<WatchViewModel> GetWatchByIdAsync(int id);
        Task<WatchViewModel> GetWatchByItemNumberAsync(string itemNumber);
        Task<WatchViewModel> DeleteWatchByIdAsync(int id);
        Task<WatchViewModel> UpdateWatchAsync(UpdateViewModel model);
        Task<BlobResponseDTO> FileUploadAsync(IFormFile photo);
    }
}
