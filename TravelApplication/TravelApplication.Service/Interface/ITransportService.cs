using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;

namespace TravelApplication.Service.Interface
{
    public interface ITransportService
    {
        List<Transport> GetAllTransports();
        Transport GetTransportById(Guid id);
        void AddTransport(Transport transport);
        void UpdateTransport(Transport transport);
        void DeleteTransport(Guid id);
    }
}
