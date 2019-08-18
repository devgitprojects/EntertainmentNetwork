using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL.CinemaService
{
    public partial class cinema : baseModel, ICinema
    {
        public cinema()
        {
            this.PropertyChanged += CinemaPropertyChanged;
        }

        public cinema(decimal cinId, string cityId, string cinName, string cinAddress, byte[] cinIcon)
        {
            this.id = cinId;
            this.idSpecified = true;
            this.city = cityId;
            this.name = cinName;
            this.cinAddress = cinAddress;
            this.cinIcon = cinIcon;     
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
            ICinema cinema = (ICinema)model;
            this.id = cinema.id;
            this.idSpecified = !cinema.IsNew;
            this.name = cinema.name;
            this.cinAddress = cinema.cinAddress;
            this.cinIcon = cinema.cinIcon;
            this.halls = cinema.halls;
        }

        public override bool Equals(object obj)
        {
            ICinema cityToCompare = obj as ICinema;
            return cityToCompare != null
                && Object.Equals(this.id, cityToCompare.id)
                && Object.Equals(this.name, cityToCompare.name)
                && Object.Equals(this.cinAddress, cityToCompare.cinAddress)
                && Object.Equals(this.cinIcon, cityToCompare.cinIcon);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode() ^ Helpers.GetHashCode(this.name) ^ Helpers.GetHashCode(this.cinAddress)
                ^ Helpers.GetHashCode(this.cinAddress) ^ Helpers.GetHashCode(this.city);
        }

        private void CinemaPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "halls" && this.halls != null)
            {
                foreach (var hall in this.halls)
                {
                    hall.PropertyChanged += (o, a) => { this.RaisePropertyChanged(a.PropertyName); }; 
                }
            }
        }
    }
}
