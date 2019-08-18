using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL.ShowService;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.Models;
using DataService = EntertainmentNetwork.DAL.ShowService;
using Interfaces = EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.Logging;
using System;

namespace EntertainmentNetwork.DAL
{
    public class ShowRepository : BaseRepository<IShow>, IShowRepository, IShowReadOnlyRepository
    {
        public ShowRepository(DataService.ShowService showService)
        {
            this.showService = showService;
        }

        #region IShowRepository

        public IShow Create()
        {
            IShow newShow = new show();
            newShow.PropertyChanged += this.Entity_PropertyChanged;
            return newShow;
        }

        public async Task<IShow> FindBySimplifiedShow(immutablePair simpleShow)
        {
            return await this.FindById((decimal)simpleShow.left);
        }

        public async Task<IShow> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findShowByIdResponse>>(
                () => this.showService.findShowByIdAsync(new findShowByIdRequest(id)));

            return result == null || result.@return == null ? null : result.@return.FirstOrDefault(x => x.id == id);
        }

        public async Task<List<IShow>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<IShow>>>(async () => 
            {
                var result = await this.showService.getShowsAsync(new getShowsRequest());
                List<IShow> shows = this.CastToList(result.@return);
                shows.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return shows;
            });
        }

        public async Task Remove(IShow show)
        {
            await Logger.ExecuteAndLog<Task>(() => this.showService.removeShowAsync(new removeShowRequest(show.id)));
        }

        public void Reset(IShow show)
        {
            show.Update(new show());
        }

        public async Task Save(IList<IShow> shows)
        {
            var cast = shows.Where(x => x.IsNew || x.IsChanged).Cast<show>().ToArray();

            foreach (var show in cast)
            {
                show.shwStartDtSpecified = true;
                show.shwEndDtSpecified = true;
            }
            
            var result = await Logger.ExecuteAndLog<Task<saveShowsResponse>>(
                () => this.showService.saveShowsAsync(new saveShowsRequest(cast)));

            this.Update(shows, result.@return);
        }

        public async Task Save(IShow show)
        {
            await this.Save(new List<IShow> { show });
        }

        #endregion

        #region IShowReadOnlyRepository

        immutablePair IBaseRepository<immutablePair>.Create()
        {
            throw new NotImplementedException();
        }

        Task<immutablePair> IBaseRepository<immutablePair>.FindById(decimal id)
        {
            throw new NotImplementedException();
        }

        Task<List<immutablePair>> IBaseRepository<immutablePair>.GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<immutablePair[]> GetSimplifiedShowsByDates(DateTime startDT, DateTime endDT)
        {
            var result = await Logger.ExecuteAndLog<Task<getSimplifiedShowsByDatesResponse>>(
                () => this.showService.getSimplifiedShowsByDatesAsync(new getSimplifiedShowsByDatesRequest(startDT, endDT)));
            return result.@return == null ? (immutablePair[])Enumerable.Empty<immutablePair>() : result.@return;
        }

        public Task Remove(immutablePair model)
        {
            throw new NotImplementedException();
        }

        public Task Save(IList<immutablePair> models)
        {
            throw new NotImplementedException();
        }

        public Task Save(immutablePair model)
        {
            throw new NotImplementedException();
        }

        #endregion

        private readonly DataService.ShowService showService;

    }
}
