using System.Threading.Tasks;
using EntertainmentNetwork.DAL.ShowService;
using EntertainmentNetwork.DAL.TicketService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ITicketRepository : IBaseRepository<ITicket> 
    {
        Task<ITicket[]> GetTicketsByScheduler(IScheduler scheduler);
        Task<ITicket> GenerateTicket(IScheduler scheduler, ISeat seat, ISection section, immutablePair show, IOrder order);
        bool IsSeatIsSold(ISeat seat, ITicket ticket);
    }
}
