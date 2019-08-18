using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL.ShowService
{
    public partial class show : baseModel, IShow
    {
        public show() { }

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
            IShow show = (IShow)model;
            this.id = show.id;
            this.idSpecified = !show.IsNew;
            this.name = show.name;
            this.shwDescr = show.shwDescr;
            this.shwPerformer = show.shwPerformer;
            this.shwIcon = show.shwIcon;
            this.shwStartDt = show.shwStartDt;
            this.shwEndDt = show.shwEndDt;
            this.shwPrice = show.shwPrice;
        }

        public decimal GetId()
        {
            return this.id;
        }

        public override bool Equals(object show)
        {
            IShow showToCompare = show as IShow;
            return showToCompare != null && this.id.Equals(showToCompare.id);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
