using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IWatchRepository
    {
        //Update
        Task UpdateWatch(Watch watch);

        //Get
        Task<IEnumerable<Watch>> GetWatchesAsync();
        Task<Watch> GetWatchByIdAsync(int id);
        Task<Watch> GetWatchByItemNumberAsync(string itemNumber);

        //Delete
        Task<Watch> DeleteWatchByIdAsync(int id);
        Task<Watch> DeleteWatchByItemNumberAsync(string itemNumber);


        //Add
        Task AddItemAsync(Watch watch);

        //Save
        Task<bool> SaveAllAsync();
    }
}
