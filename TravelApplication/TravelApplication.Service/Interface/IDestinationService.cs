using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface IDestinationService
    {
        List<Destination> GetAllDestinations();
        Destination GetDestinationById(Guid id);
        void AddDestination(Destination destination);
        void UpdateDestination(Destination destination);
        void DeleteDestination(Guid id);
    }
}
