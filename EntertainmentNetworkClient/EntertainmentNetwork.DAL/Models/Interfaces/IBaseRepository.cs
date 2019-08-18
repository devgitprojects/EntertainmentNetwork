using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Create();

        Task<T> FindById(decimal id);

        Task<List<T>> GetAll();      

        Task Remove(T model);

        Task Save(IList<T> models);

        Task Save(T model);
    }
}
