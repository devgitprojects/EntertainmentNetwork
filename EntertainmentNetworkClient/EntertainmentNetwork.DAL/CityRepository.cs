
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DataService = EntertainmentNetwork.DAL.CityService;
using EntertainmentNetwork.DAL.CityService;
using EntertainmentNetwork.DAL.Models.Interfaces;
using Interfaces = EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.Logging;
using System;

namespace EntertainmentNetwork.DAL
{
    public class CityRepository : BaseRepository<ICity>, Interfaces.IBaseRepository<ICity>
    {
        public CityRepository(DataService.CityService cityService)
        {
            this.cityService = cityService;
        }

        #region IBaseRepository

        public ICity Create()
        {
            ICity newCity = new city();
            newCity.PropertyChanged += this.Entity_PropertyChanged;
            return newCity;
        }

        public async Task<ICity> FindById(decimal id)
        {
            var result = await Logger.ExecuteAndLog<Task<findCityByIdResponse>>(() => this.cityService.findCityByIdAsync(new findCityByIdRequest(id)));
            return result.@return.FirstOrDefault(x => x.id == id);
        }

        public async Task<List<ICity>> GetAll()
        {
            return await Logger.ExecuteAndLog<Task<List<ICity>>>(async () =>
            {
                var result = await this.cityService.getCitiesAsync(new getCitiesRequest());
                List<ICity> cities = this.CastToList(result.@return);
                cities.ForEach(x => x.PropertyChanged += this.Entity_PropertyChanged);
                return cities;
            });
        }

        public async Task Remove(ICity city)
        {
            await Logger.ExecuteAndLog<Task>(() => this.cityService.removeCityAsync(new removeCityRequest(city.id)));
            city.PropertyChanged -= this.Entity_PropertyChanged;
        }

        public async Task Save(IList<ICity> cities)
        {
            var result = await Logger.ExecuteAndLog<Task<saveCitiesResponse>>(
                () => this.cityService.saveCitiesAsync(new saveCitiesRequest(cities.Where(x => x.IsNew || x.IsChanged).Cast<city>().ToArray())));
            this.Update(cities, result.@return);
        }

        public async Task Save(ICity city)
        {
            await this.Save(new List<ICity> { city });
        }

        #endregion

        private readonly DataService.CityService cityService;
    }
}
