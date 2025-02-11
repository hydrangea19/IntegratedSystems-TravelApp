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
    public class TransportRepository : ITransportRepository
    {
        private readonly ApplicationDbContext _context;

        public TransportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transport>> GetAllAsync()
            => await _context.Transports.ToListAsync();

        public async Task<Transport> GetByIdAsync(int id)
            => await _context.Transports.FindAsync(id);

        public async Task AddAsync(Transport transport)
        {
            await _context.Transports.AddAsync(transport);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transport transport)
        {
            _context.Transports.Update(transport);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transport = await GetByIdAsync(id);
            if (transport == null) return false;

            _context.Transports.Remove(transport);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
