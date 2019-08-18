using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL.OrdersService
{
    public partial class orders : baseModel, IOrder
    {
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

        public decimal GetId()
        {
            return this.id;
        }

        public void Update(IBaseModel model)
        {
            IOrder order = (IOrder)model;
            this.id = order.id;
            this.idSpecified = true;
            this.ordComm = order.ordComm;
            this.ordCost = order.ordCost;
            this.ordCostSpecified = true;
            this.ordDate = order.ordDate;
            this.ordDateSpecified = true;
            this.ticketses = order.ticketses;
        }

        public override bool Equals(object obj)
        {
            IOrder orderToCompare = obj as IOrder;
            return orderToCompare != null && Object.Equals(this.id, orderToCompare.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        public object[] ToArray()
        {
            return new object[] 
            { 
                this.GetId(), 
                this.ordDate,
                this.ticketses == null ? 0 : this.ticketses.Where(x => x != null).Sum(x => x.tctPrice)
            };
        }

        public object[] TicketsToArrayData()
        {
            return this.ticketses == null ? (object[])Enumerable.Empty<object>() : this.ticketses.Select(
                x => new object[] 
                {
                    x.id,
                    x.scheduler == null ? "N/A" : x.scheduler.schTimeFrom.ToString(String.Format("{0} - {1}", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern)),
                    x.tctPrice,
                    x.seat == null ? -1 : x.seat.seatRow,
                    x.seat == null ? -1 : x.seat.seatNum,
                }).ToArray();
        }
    }
}
