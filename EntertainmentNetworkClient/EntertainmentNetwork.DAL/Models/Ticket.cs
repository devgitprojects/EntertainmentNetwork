using System.Xml.Serialization;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL.TicketService
{
    public partial class tickets : baseModel, ITicket
    {
        public tickets() { }

        [XmlIgnore]
        public bool IsNew
        {
            get
            {
                return this.id == 0;
            }
        }

        [XmlIgnore]
        public bool IsChanged { get; set; }

        public void Update(IBaseModel model)
        {
            ITicket ticket = (ITicket)model;
            this.id = ticket.id;
            this.idSpecified = true;
            this.ordersId = ticket.ordersId;
            this.ordersIdSpecified = true;
            this.scheduler = ticket.scheduler;
            this.seat = ticket.seat;
            this.tctIssold = ticket.tctIssold;
            this.tctPrice = ticket.tctPrice;
            this.tctPriceSpecified = true;
        }

        public decimal GetId()
        {
            return this.id;
        }

        public override bool Equals(object ticket)
        {
            ITicket ticketToCompare = ticket as ITicket;
            return ticketToCompare != null && this.id.Equals(ticketToCompare.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
