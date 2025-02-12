using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain;

namespace TravelApplication.Repository.Interface
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(Guid id); // Changed from int to Guid
        Task AddAsync(Activity activity);
        Task UpdateAsync(Activity activity);
        Task<bool> DeleteAsync(Guid id); // Changed from int to Guid
    }
}