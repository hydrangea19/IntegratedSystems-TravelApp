using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;
using TravelApplication.Domain.DTO;
using TravelApplication.Repository.Interface;

namespace TravelApplication.Repository.Implementation
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Destination> _entities;
        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<Destination>();
        }
        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid travelId)
        {
            var entity = await GetByIdAsync(travelId);
            if (entity != null) 
            {
                _context.Destinations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.Include(d => d.Accomodations).ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(Guid travelId)
        {
            return await _context.Destinations.Include(d => d.Accomodations).FirstOrDefaultAsync(d => d.TravelId == travelId);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }
    }
}
