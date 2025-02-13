using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface IActivityService
    {
        List<Activity> GetAllActivities();
        Activity GetActivityById(Guid id);
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void DeleteActivity(Guid id);
    }
}
