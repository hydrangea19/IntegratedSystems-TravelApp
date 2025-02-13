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
    public class TransportService : ITransportService
    {
        private readonly IRepository<Transport> _transportRepository;

        public TransportService(IRepository<Transport> transportRepository)
        {
            _transportRepository = transportRepository;
        }
        public void AddTransport(Transport transport)
        {
            if (transport == null)
            {
                throw new ArgumentException(nameof(transport), "Transport data cannot be null.");
            }
            _transportRepository.Insert(transport);
        }

        public void DeleteTransport(Guid id)
        {
            Transport transport = _transportRepository.Get(id);
            if (transport == null)
            {
                throw new ArgumentException(nameof(transport), "Transport data cannot be null.");
            }
            _transportRepository.Delete(transport);
        }

        public List<Transport> GetAllTransports()
        {
            return _transportRepository.GetAll().ToList();
        }

        public Transport GetTransportById(Guid id)
        {
            return _transportRepository.Get(id);
        }

        public void UpdateTransport(Transport transport)
        {
           _transportRepository.Update(transport);
        }

    }

}
