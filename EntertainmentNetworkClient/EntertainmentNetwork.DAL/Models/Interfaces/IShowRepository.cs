using System;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IShowRepository : IBaseRepository<IShow> 
    {
        Task<IShow> FindBySimplifiedShow(immutablePair simpleShow);
        void Reset(IShow show);
        void Update(IShow target, IShow source);
    }

    public interface IShowReadOnlyRepository : IBaseRepository<immutablePair>
    {
        Task<immutablePair[]> GetSimplifiedShowsByDates(DateTime startDT, DateTime endDT);
    }
}
