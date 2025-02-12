using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TravelApplication.Domain.Domain;
using TravelApplication.Repository.Interface;

namespace TravelApplication.Repository.Implementation
{
    public class DestinationTransportRepository : IDestinationTransportRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationTransportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DestinationTransport>> GetAllAsync()
        {
            return await _context.DestinationTransports
                .Include(dt => dt.Destination)
                .Include(dt => dt.Transport)
                .ToListAsync();
        }

        public async Task<DestinationTransport> GetByIdAsync(Guid destinationId, Guid transportId)
        {
            return await _context.DestinationTransports
                .FirstOrDefaultAsync(dt => dt.DestinationId == destinationId && dt.TransportId == transportId);
        }

        public async Task AddAsync(DestinationTransport destinationTransport)
        {
            await _context.DestinationTransports.AddAsync(destinationTransport);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid destinationId, Guid transportId)
        {
            var entity = await GetByIdAsync(destinationId, transportId);
            if (entity != null)
            {
                _context.DestinationTransports.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
