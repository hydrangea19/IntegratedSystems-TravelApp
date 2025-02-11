using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;
using TravelApplication.Repository.Interface;

namespace TravelApplication.Repository.Implementation
{
    public class AccommodationRepository: IAccommodationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Accommodation> _entities;
        public AccommodationRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<Accommodation>();
        }

        public async Task AddAsync(Accommodation accommodation)
        {
            await _context.Accommodations.AddAsync(accommodation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Accommodations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Accommodation>> GetAllAsync()
        {
            return await _context.Accommodations.ToListAsync();
        }

        public async Task<Accommodation?> GetByIdAsync(int id)
        {
            return await _context.Accommodations.FindAsync(id);
        }

        public async Task UpdateAsync(Accommodation accommodation)
        {
            _context.Update(accommodation);
            await _context.SaveChangesAsync();
        }
    }
}
