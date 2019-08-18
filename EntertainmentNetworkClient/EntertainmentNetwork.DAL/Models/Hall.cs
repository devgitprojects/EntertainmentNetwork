using EntertainmentNetwork.DAL.Models.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace EntertainmentNetwork.DAL.CinemaService
{
    public partial class hall : baseModel, IHall
    {
        public hall() 
        {
            this.PropertyChanged += HallPropertyChanged;
        }

        public hall(decimal halId, string halName) 
        {
            this.id = halId;
            this.name = halName;
        }

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
            IHall hall = (IHall)model;
            this.id = hall.id;
            this.name = hall.name;
        }

        public override bool Equals(object obj)
        {
            IHall cityToCompare = obj as IHall;
            return cityToCompare != null
                && Object.Equals(this.id, cityToCompare.id)
                && Object.Equals(this.name, cityToCompare.name);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode() ^ Helpers.GetHashCode(this.name);
        }

        private void HallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "sections" && this.sections != null)
            {
                foreach (var section in this.sections)
                {
                    section.PropertyChanged += (o, a) => { this.RaisePropertyChanged(a.PropertyName); };
                }
            }
        }         
    }
}
