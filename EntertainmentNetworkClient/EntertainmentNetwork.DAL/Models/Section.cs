using System;
using System.ComponentModel;
using System.Xml.Serialization;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.DAL.CinemaService
{
    public partial class section : baseModel, ISection
    {
        public section() 
        {
            this.PropertyChanged += this.SectionPropertyChanged;
            this.secCoefSpecified = true;
        }

        public section(decimal floorId, string floorName)
        {
            this.id = floorId;
            this.name = floorName;
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
            ISection section = (ISection)model;
            this.id = section.id;
            this.name = section.name;
            this.secCoef = section.secCoef;
            this.secCoefSpecified = true;
        }

        public override bool Equals(object obj)
        {
            ISection secToCompare = obj as ISection;
            return secToCompare != null
                && Object.Equals(this.id, secToCompare.id)
                && Object.Equals(this.name, secToCompare.name)
                && Object.Equals(this.secCoef, secToCompare.secCoef);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode() ^ Helpers.GetHashCode(this.name) ^ this.secCoef.GetHashCode();
        }

        private void SectionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "seats" && this.seats != null)
            {
                foreach (var seat in this.seats)
                {
                    seat.PropertyChanged += (o, a) => { this.RaisePropertyChanged(a.PropertyName); };
                }
            }
        }    
    }
}
