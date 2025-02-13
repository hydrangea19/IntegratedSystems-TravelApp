using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity> _activityRepository;

        public ActivityService(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public void AddActivity(Activity activity)
        {
            if(activity == null)
            {
                throw new ArgumentException(nameof(activity), "Activity data cannot be null.");
            }
            _activityRepository.Insert(activity);
        }

        public void DeleteActivity(Guid id)
        {
            Activity activity = _activityRepository.Get(id);
            if(activity != null)
            {
                _activityRepository.Delete(activity);
            }
        }

        public Activity GetActivityById(Guid id)
        {
           return _activityRepository.Get(id);
        }

        public List<Activity> GetAllActivities()
        {
            return _activityRepository.GetAll().ToList();
        }

        public void UpdateActivity(Activity activity)
        {
            _activityRepository.Update(activity);
        }
    }
}
