using Client.ViewModels;

namespace Client.Interfaces
{
    public interface IApiService
    {
        Task<WatchViewModel> CreateWatchAsync(CreateViewModel model);
        Task<IEnumerable<WatchViewModel>> GetWatchListAsync();
    }
}
