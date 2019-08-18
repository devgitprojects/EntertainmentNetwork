using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DataService = EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.Logging;
using EntertainmentNetwork.DAL.Models;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL
{
    public class CinemaRepository : BaseRepository<ICinema>, ICinemaRepository, ICinemaReadOnlyRepository
    {
        public CinemaRepository(DataService.CinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        #region ICinemaRepository

        public ICinema Create()
        {
            ICinema newCinema = new cinema();
            newCinema.PropertyChanged += this.Entity_PropertyChanged;
            return newCinema;
        }

        public IHall CreateHall()
        {
            return new hall();
        }

        public ISection CreateSection()
        {
            return new section();
        }

        public async Task<ICinema> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findCinemaByIdResponse>>(
                () => this.cinemaService.findCinemaByIdAsync(new findCinemaByIdRequest(id)));
            ICinema cinema = result == null || result.@return == null ? null : result.@return.FirstOrDefault(x => x.id == id);

            return cinema;
        }

        public async Task<ICinema> FindBySimplifiedCinema(immutableTriple simpleCinema)
        {
            return await this.FindById((decimal)simpleCinema.left);
        }

        public async Task GenerateSeats(ISection section, int rowsCount, int columnsPerRowCount)
        {
            if (section != null)
            {
                var result = await Logger.ExecuteAndLog<Task<generateSeatsResponse>>(
                   () => this.cinemaService.generateSeatsAsync(new generateSeatsRequest(section.id, rowsCount, columnsPerRowCount)));
                section.seats = result.@return;
            }
        }

        public async Task<List<ICinema>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<ICinema>>>(async () => 
            {
                var result = await this.cinemaService.getCinemasAsync(new getCinemasRequest());
                List<ICinema> cinemas = this.CastToList(result.@return);
                cinemas.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return cinemas;
            });
        }

        public IHall[] GetHalls(ICinema cinema)
        {
            return cinema == null || cinema.halls == null
                ? (IHall[])Enumerable.Empty<IHall>()
                : cinema.halls;
        }

        public ISection[] GetSections(IHall hall)
        {
            return hall == null || hall.sections == null
                ? (ISection[])Enumerable.Empty<ISection>()
                : hall.sections;
        }

        public IEnumerable<ISeat[]> GetSeats(ISection section)
        {
            return section == null || section.seats == null
               ? (IEnumerable<ISeat[]>)Enumerable.Empty<ISeat[]>()
               : section.seats
               .OrderBy(s => s.seatNum)
               .GroupBy(x => x.seatRow)
               .Select(row => row.OrderBy(x => x.seatColumn).ToArray());
        }

        public async Task Remove(ICinema cinema)
        {
            await Logger.ExecuteAndLog<Task>(() => this.cinemaService.removeCinemaAsync(new removeCinemaRequest(cinema.id)));
        }

        public void Reset(ICinema cinema)
        {
            cinema.Update(new cinema());            
        }

        public async Task Save(IList<ICinema> cinemas)
        {
            var result = await Logger.ExecuteAndLog<Task<saveCinemasResponse>>(
                () => this.cinemaService.saveCinemasAsync(new saveCinemasRequest(cinemas.Where(x => x.IsNew || x.IsChanged).Cast<cinema>().ToArray())));

            this.Update(cinemas, result.@return);
        }

        public async Task Save(ICinema cinema)
        {
            await this.Save(new List<ICinema> { cinema });
        }

        public void SetCinemaCity(ICinema cinema, ICity city)
        {
            if (cinema != null && city != null)
            {
                cinema.city = city.id.ToString();
            }
        }

        public void SetHalls(ICinema cinema, BindingList<IHall> halls)
        {
            cinema.halls = halls.Cast<hall>().ToArray();
        }

        public void SetSections(IHall hall, BindingList<ISection> sections)
        {
            hall.sections = sections.Cast<section>().ToArray();
        }

        public void ClearSeats(ISection section)
        {
            section.seats = (seat[])Enumerable.Empty<seat>();
        }

        #endregion

        #region ICinemaReadOnlyRepository

        immutableTriple IBaseRepository<immutableTriple>.Create()
        {
            throw new System.NotImplementedException();
        }

        Task<immutableTriple> IBaseRepository<immutableTriple>.FindById(decimal id)
        {
            throw new System.NotImplementedException();
        }

        Task<List<immutableTriple>> IBaseRepository<immutableTriple>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<immutableTriple[]> GetSimplifiedCinemasByCityShow(ICity city, immutablePair show)
        {
            getSimplifiedCinemasByCityIdShowIdRequest request = new getSimplifiedCinemasByCityIdShowIdRequest();

            if (city != null)
            {
                request.cityId = city.GetId();
            }

            if (show != null && show.left is decimal)
            {
                request.showId = (decimal)show.left;
            }

            var result = await Logger.ExecuteAndLog<Task<getSimplifiedCinemasByCityIdShowIdResponse>>(
                () => this.cinemaService.getSimplifiedCinemasByCityIdShowIdAsync(request));

            return result == null || result.@return == null ? (immutableTriple[])Enumerable.Empty<immutableTriple>() : result.@return;
        }

        public Task Remove(immutableTriple model)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(IList<immutableTriple> models)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(immutableTriple model)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private readonly DataService.CinemaService cinemaService;
    }
}
