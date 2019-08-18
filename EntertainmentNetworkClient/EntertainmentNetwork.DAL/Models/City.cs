using System;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.CityService;
using System.Xml.Serialization;

namespace EntertainmentNetwork.DAL.CityService
{
    public partial class city : baseModel, ICity
    {
        public city() { }

        public city(decimal citId, string citName, string citCountry)
        {
            this.id = citId;
            this.name = citName;
            this.citCountry = citCountry;
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
            ICity city = (ICity)model;
            this.id = city.id;
            this.name = city.name;
            this.citCountry = city.citCountry;
        }

        public override bool Equals(object obj)
        {
            ICity cityToCompare = obj as ICity;
            return cityToCompare != null 
                && Object.Equals(this.id, cityToCompare.id)
                && Object.Equals(this.name, cityToCompare.name)
                && Object.Equals(this.citCountry, cityToCompare.citCountry);
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode()
                ^ Helpers.GetHashCode(this.name)
                ^ Helpers.GetHashCode(this.citCountry);
        }
    }
}
