using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService = EntertainmentNetwork.DAL.TicketService;
using EntertainmentNetwork.DAL.Logging;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.TicketService;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.DAL
{
    public class TicketRepository : BaseRepository<ITicket>, ITicketRepository
    {
        public TicketRepository(DataService.TicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        #region ITicketRepository

        public ITicket Create()
        {
            ITicket newticket = new tickets();
            newticket.PropertyChanged += this.Entity_PropertyChanged;
            return newticket;
        }

        public bool IsSeatIsSold(ISeat seat, ITicket ticket)
        {
            if (ticket == null || seat == null)
	        {
                throw new ArgumentNullException("Ticket or seat could not be null.");	
	        }

            return ticket.seat != null && ticket.seat.id == seat.GetId();
        }

        public async Task<ITicket> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findTicketByIdResponse>>(
                () => this.ticketService.findTicketByIdAsync(new findTicketByIdRequest(id)));
            return result == null || result.@return == null ? null : result.@return.FirstOrDefault(x => x.id == id);
        }

        public async Task<ITicket> GenerateTicket(IScheduler scheduler, ISeat seat, ISection section, immutablePair show, IOrder order)
        {
            if (scheduler == null || section == null || seat == null || show == null || order == null)
            {
                throw new ArgumentNullException();
            }

            var request = new generateTicketRequest(scheduler.GetId(), seat.GetId(), section.GetId(), (decimal)show.left, order.GetId());
            var result = await Logger.ExecuteAndLog<Task<generateTicketResponse>>(() => this.ticketService.generateTicketAsync(request));
            return result.@return;
        }

        public async Task<List<ITicket>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<ITicket>>>(async () => 
            {
                var result = await this.ticketService.getTicketsAsync(new getTicketsRequest());
                List<ITicket> tickets = this.CastToList(result.@return);
                tickets.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return tickets;
            });
        }

        public async Task<ITicket[]> GetTicketsByScheduler(IScheduler scheduler)
        {
            if (scheduler == null)
	        {
                throw new ArgumentNullException("Scheduler could not be null.");		 
	        }

            var result = await Logger.ExecuteAndLog<Task<getTicketsByScheduleIDResponse>>(
                () => this.ticketService.getTicketsByScheduleIDAsync(new getTicketsByScheduleIDRequest(scheduler.GetId())));
            var tickets = result.@return == null ? (ITicket[])Enumerable.Empty<ITicket>() : result.@return;
            
            foreach (var tct in tickets)
            {
                tct.PropertyChanged += this.Entity_PropertyChanged;
            }

            return tickets;
        }

        public async Task Remove(ITicket ticket)
        {
            await Logger.ExecuteAndLog<Task>(() => this.ticketService.removeTicketAsync(new removeTicketRequest(ticket.id)));
        }

        public async Task Save(IList<ITicket> tickets)
        {
            var result = await Logger.ExecuteAndLog<Task<saveTicketsResponse>>(
                () => this.ticketService.saveTicketsAsync(new saveTicketsRequest(tickets.Where(x => x.IsNew || x.IsChanged).Cast<tickets>().ToArray())));

            this.Update(tickets, result.@return);
        }

        public async Task Save(ITicket ticket)
        {
            await this.Save(new List<ITicket> { ticket });
        }

        #endregion

        private readonly DataService.TicketService ticketService;
    }
}
