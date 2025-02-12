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
    public class DestinationActivityRepository : IDestinationActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DestinationActivity>> GetAllAsync()
        {
            return await _context.DestinationActivities
                .Include(da => da.Destination)
                .Include(da => da.Activity)
                .ToListAsync();
        }

        public async Task<DestinationActivity> GetByIdAsync(Guid destinationId, Guid activityId)
        {
            return await _context.DestinationActivities
                .FirstOrDefaultAsync(da => da.DestinationId == destinationId && da.ActivityId == activityId);
        }

        public async Task AddAsync(DestinationActivity destinationActivity)
        {
            await _context.DestinationActivities.AddAsync(destinationActivity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid destinationId, Guid activityId)
        {
            var entity = await GetByIdAsync(destinationId, activityId);
            if (entity != null)
            {
                _context.DestinationActivities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
