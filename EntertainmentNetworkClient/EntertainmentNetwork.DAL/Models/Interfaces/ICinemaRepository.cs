using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ICinemaRepository : IBaseRepository<ICinema>
    {
        IHall CreateHall();
        ISection CreateSection();
        Task GenerateSeats(ISection section, int rowsCount, int columnsPerRowCount);
        Task<ICinema> FindBySimplifiedCinema(immutableTriple simpleCinema);
        IHall[] GetHalls(ICinema cinema);
        ISection[] GetSections(IHall cinema);
        IEnumerable<ISeat[]> GetSeats(ISection section);
        void SetCinemaCity(ICinema cinema, ICity city);
        void SetHalls(ICinema cinema, BindingList<IHall> halls);
        void SetSections(IHall hall, BindingList<ISection> sections);
        void ClearSeats(ISection section);
        void Reset(ICinema show);
        void Update(ICinema target, ICinema source);
    }

    public interface ICinemaReadOnlyRepository : IBaseRepository<immutableTriple>
    {
        Task<immutableTriple[]> GetSimplifiedCinemasByCityShow(ICity city, immutablePair show);
    }
}
