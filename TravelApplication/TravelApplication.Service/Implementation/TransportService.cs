using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApplication.Domain.DTO;
using TravelApplication.Domain.Domain;
using TravelApplication.Repository.Interface;
using TravelApplication.Service.Interface;

namespace TravelApplication.Service.Implementation
{
    public class TransportService : ITransportService
    {
        private readonly ITransportRepository _transportRepository;

        public TransportService(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public async Task<IEnumerable<TransportDTO>> GetAllTransportsAsync()
        {
            var transports = await _transportRepository.GetAllAsync();
            return transports.Select(t => new TransportDTO
            {
                Id = t.Id,
                Type = t.Type,
                DeparturePoint = t.DeparturePoint,
                ArrivalPoint = t.ArrivalPoint,
                DepartureTime = t.DepartureTime,
                ArrivalTime = t.ArrivalTime,
                CostPerPassenger = t.CostPerPassenger
            });
        }

        public async Task<TransportDTO> GetTransportByIdAsync(int id)
        {
            var transport = await _transportRepository.GetByIdAsync(id);
            if (transport == null) return null;

            return new TransportDTO
            {
                Id = transport.Id,
                Type = transport.Type,
                DeparturePoint = transport.DeparturePoint,
                ArrivalPoint = transport.ArrivalPoint,
                DepartureTime = transport.DepartureTime,
                ArrivalTime = transport.ArrivalTime,
                CostPerPassenger = transport.CostPerPassenger
            };
        }

        public async Task AddTransportAsync(TransportDTO transportDto)
        {
            var transport = new Transport
            {
                Type = transportDto.Type,
                DeparturePoint = transportDto.DeparturePoint,
                ArrivalPoint = transportDto.ArrivalPoint,
                DepartureTime = transportDto.DepartureTime,
                ArrivalTime = transportDto.ArrivalTime,
                CostPerPassenger = transportDto.CostPerPassenger
            };

            await _transportRepository.AddAsync(transport);
        }

        public async Task UpdateTransportAsync(TransportDTO transportDto)
        {
            var transport = new Transport
            {
                Id = transportDto.Id,
                Type = transportDto.Type,
                DeparturePoint = transportDto.DeparturePoint,
                ArrivalPoint = transportDto.ArrivalPoint,
                DepartureTime = transportDto.DepartureTime,
                ArrivalTime = transportDto.ArrivalTime,
                CostPerPassenger = transportDto.CostPerPassenger
            };

            await _transportRepository.UpdateAsync(transport);
        }

        public async Task DeleteTransportAsync(int id)
        {
            await _transportRepository.DeleteAsync(id);
        }
    }
}
