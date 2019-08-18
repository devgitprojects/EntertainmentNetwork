using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService = EntertainmentNetwork.DAL.SchedulerService;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.Logging;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.SchedulerService;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL
{
    public class SchedulerRepository : BaseRepository<IScheduler>, ISchedulerRepository
    {
        public SchedulerRepository(DataService.SchedulerService schedulerService)
        {
            this.schedulerService = schedulerService;
        }

        #region ISchedulerRepository

        public IScheduler Create()
        {
            IScheduler newScheduler = new scheduler();
            newScheduler.PropertyChanged += this.Entity_PropertyChanged;
            return newScheduler;
        }

        public async Task<IScheduler> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findSchedulerByIdResponse>>(
                () => this.schedulerService.findSchedulerByIdAsync(new findSchedulerByIdRequest(id)));
            return result == null || result.@return == null ? null : result.@return.FirstOrDefault(x => x.id == id);
        }

        public async Task<List<IScheduler>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<IScheduler>>>(async () => 
            {
                var result = await this.schedulerService.getSchedulersAsync(new getSchedulersRequest());
                List<IScheduler> schedulers = this.CastToList(result.@return);
                schedulers.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return schedulers;
            });
        }

        public async Task<IScheduler[]> GetSchedulersByCinemaHallShowDates(immutableTriple simpleCinema, IHall hall, immutablePair show, DateTime startDt, DateTime endDt)
        {
            getSchedulersByCinemaHallShowDatesRequest request = new getSchedulersByCinemaHallShowDatesRequest
            {
                startDt = startDt,
                endDt = endDt
            };
            
            if (simpleCinema != null && simpleCinema.left is decimal)
            {
                request.cinemaID = (decimal)simpleCinema.left;
            }

            if (hall != null)
            {
                request.hallId = hall.GetId();
            }

            if (show != null && show.left is decimal)
            {
                request.showId = (decimal)show.left;
            } 

            var result = await Logger.ExecuteAndLog<Task<getSchedulersByCinemaHallShowDatesResponse>>(
                () => this.schedulerService.getSchedulersByCinemaHallShowDatesAsync(request));
            var scheduler = result.@return == null ? (IScheduler[])Enumerable.Empty<IScheduler>() : result.@return;
            
            foreach (var schedule in scheduler)
            {
                schedule.PropertyChanged += this.Entity_PropertyChanged;
            }

            return scheduler;
        }

        public async Task Remove(IScheduler scheduler)
        {
            await Logger.ExecuteAndLog<Task>(() => this.schedulerService.removeSchedulerAsync(new removeSchedulerRequest(scheduler.id)));
        }

        public void Reset(IScheduler scheduler)
        {
            scheduler.Update(new scheduler());
        }

        public async Task Save(IList<IScheduler> schedulers)
        {
            var result = await Logger.ExecuteAndLog<Task<saveSchedulersResponse>>(
                () => this.schedulerService.saveSchedulersAsync(new saveSchedulersRequest(schedulers.Where(x => x.IsNew || x.IsChanged).Cast<scheduler>().ToArray())));

            this.Update(schedulers, result.@return);
        }

        public async Task Save(IScheduler scheduler)
        {
            await this.Save(new List<IScheduler> { scheduler });
        }

        #endregion

        private readonly DataService.SchedulerService schedulerService;
    }
}
