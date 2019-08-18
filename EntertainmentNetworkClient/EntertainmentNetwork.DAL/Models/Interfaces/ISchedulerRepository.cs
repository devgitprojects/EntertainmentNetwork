using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ISchedulerRepository : IBaseRepository<IScheduler>
    {
        Task<IScheduler[]> GetSchedulersByCinemaHallShowDates(immutableTriple simpleCinema, IHall hall, immutablePair show, DateTime startDt, DateTime endDt);
        void Reset(IScheduler scheduler);
        void Update(IScheduler target, IScheduler source);
    }
}
