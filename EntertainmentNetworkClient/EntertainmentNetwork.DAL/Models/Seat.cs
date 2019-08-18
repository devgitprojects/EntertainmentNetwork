using EntertainmentNetwork.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EntertainmentNetwork.DAL.CinemaService
{
    public partial class seat : baseModel, ISeat
    {
        public seat() { }

        public seat(decimal seatId, int seatColumn, int seatNum, int seatRow, int seatType, bool isActive)
        {
            this.id = seatId;
            this.seatColumn = seatColumn;
            this.seatNum = seatNum;
            this.seatRow = seatRow;
            this.seatIsactive = seatIsactive;
            this.seatType = seatType;
        }

        [XmlIgnore]
        public bool IsChanged { get; set; }
        
        [XmlIgnore]
        public bool IsNew
        {
            get { return this.id == 0; }
        }

        public decimal GetId()
        {
            return this.id;
        }

        public void Update(IBaseModel model)
        {
            ISeat seat = (ISeat)model;
            this.id = seat.id;
            this.seatColumn = seat.seatColumn;
            this.seatNum = seat.seatNum;
            this.seatRow = seat.seatRow;
            this.seatIsactive = seat.seatIsactive;
            this.seatType = seat.seatType;
        }

        public override bool Equals(object obj)
        {
            ISeat cityToCompare = obj as ISeat;
            return cityToCompare != null
                && Object.Equals(this.id, cityToCompare.id)
                && Object.Equals(this.seatColumn, cityToCompare.seatColumn)
                && Object.Equals(this.seatNum, cityToCompare.seatNum)
                && Object.Equals(this.seatRow, cityToCompare.seatRow)
                && Object.Equals(this.seatIsactive, cityToCompare.seatIsactive)
                && Object.Equals(this.seatType, cityToCompare.seatType);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode() ^ this.seatColumn.GetHashCode()
                ^ this.seatNum.GetHashCode() ^ this.seatRow.GetHashCode() ^ this.seatIsactive.GetHashCode()
                ^ this.seatType.GetHashCode();
        }
    }
}
