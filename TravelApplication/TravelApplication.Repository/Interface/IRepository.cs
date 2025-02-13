using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApplication.Domain.Domain.MainModels;
using TravelApplication.Domain.DTO;

namespace TravelApplication.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {   
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        TravelPackage GetDetailsForTravelPackage(Guid? id);

        TravelPackageDetailsDTO? GetTravelPackageDetails(Guid id);
    }
}
