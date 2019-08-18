using EntertainmentNetwork.DAL.TicketService;
using System.ComponentModel;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface ITicket : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        decimal ordersId { get; set; }
        scheduler scheduler { get; set; }
        seat seat { get; set; }
        bool tctIssold { get; set; }
        decimal tctPrice { get; set; }
    }
}
