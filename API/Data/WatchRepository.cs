using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class WatchRepository : IWatchRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public WatchRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddItemAsync(Watch watch)
        {
             await _context.Watches.AddAsync(watch);
        }

        public async Task<Watch> DeleteWatchByIdAsync(int id)
        {
            var watch = await _context.Watches.SingleOrDefaultAsync(x => x.Id == id);
            watch.IsDeleted = true;

            return watch;
        }

        public async Task<Watch> DeleteWatchByItemNumberAsync(string itemNumber)
        {
            var watch = await _context.Watches.FirstOrDefaultAsync(x => x.ItemNumber == itemNumber);
            watch.IsDeleted = true;

            return watch;
        }

        public async Task<Watch> GetWatchByIdAsync(int id)
        {
            return await _context.Watches
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Watch> GetWatchByItemNumberAsync(string itemNumber)
        {
            return await _context.Watches.FirstOrDefaultAsync(x => x.ItemNumber == itemNumber &&
            x.IsDeleted == false);
        }

        public async Task<IEnumerable<Watch>> GetWatchesAsync()
        {
            return await _context.Watches
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateWatch(Watch watchUpdate)
        {
            var watch = await _context.Watches.SingleOrDefaultAsync(x => x.Id == watchUpdate.Id);
            if (watch != null) 
            {
                watch.Name = watchUpdate.Name;
                watch.ItemNumber = watchUpdate.ItemNumber;
                watch.Price = watchUpdate.Price;
                watch.ShortDescription = watchUpdate.ShortDescription;
                watch.FullDescription = watchUpdate.FullDescription;
                watch.Caliber = watchUpdate.Caliber;
                watch.Diameter = watchUpdate.Diameter;
                watch.Movement = watchUpdate.Movement;
                watch.Chronograph = watchUpdate.Chronograph;
                watch.Jewel = watchUpdate.Jewel;
                watch.Weight = watchUpdate.Weight;
                watch.Thickness = watchUpdate.Thickness;
                watch.Height = watchUpdate.Height;
                watch.CaseMaterial = watchUpdate.CaseMaterial;
                watch.StrapMaterial = watchUpdate.StrapMaterial;
                watch.PhotoUri = watchUpdate.PhotoUri;

            }
        }
    }
}
