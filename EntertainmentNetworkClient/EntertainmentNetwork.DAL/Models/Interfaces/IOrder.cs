using System;
using System.ComponentModel;
using EntertainmentNetwork.DAL.OrdersService;

namespace EntertainmentNetwork.DAL.Models.Interfaces
{
    public interface IOrder : IBaseModel, INotifyPropertyChanged
    {
        [ReadOnly(true)]
        decimal id { get; set; }
        string ordComm { get; set; }
        decimal ordCost { get; set; }
        bool ordCostSpecified { get; set; }
        DateTime ordDate { get; set; }
        bool ordDateSpecified { get; set; }
        tickets[] ticketses { get; set; }

        object[] ToArray();
        object[] TicketsToArrayData();
    }
}