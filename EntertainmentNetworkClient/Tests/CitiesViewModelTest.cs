using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DevExpress.Mvvm.POCO;
using Moq;
using NUnit.Framework;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetwork.DAL.CityService;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace Tests
{
    /// <summary>
    /// Test class to check CitiesViewModel
    /// </summary>
    [TestFixture]
    public class CitiesViewModelTest
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            this.newCity = new city(123, cities[0].name, cities[0].citCountry);
            this.cityViewModelSource = new Mock<IBaseRepository<ICity>>(MockBehavior.Strict);
            this.cityViewModelSource.Setup(ds => ds.GetAll()).Returns(Task.FromResult(cities));
            this.cityViewModelSource.Setup(ds => ds.Remove(cities[1])).Returns(Task.FromResult(cities[1]));
            Func<ICity, ICity, Task<ICity>> updatedCity = (x, y) =>
            {
                x.Update(y);
                return Task.FromResult(x);
            };
            this.cityViewModelSource.Setup(ds => ds.Save(cities[0])).Returns(updatedCity(cities[0], newCity));

            var builder = new ContainerBuilder();
            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CitiesViewModel))).As<CitiesViewModel>()
                .WithParameter((prop, context) => prop.Name == "dataSource", (prop, context) => this.cityViewModelSource.Object).SingleInstance();
            this.cityViewModel = builder.Build().Resolve<CitiesViewModel>();
        }

        [Test]
        public void LoadCitiesPositiveTest()
        {
            var result = this.cityViewModel.LoadData();
            Assert.AreEqual(this.cities, this.cityViewModel.Entities);
        }

        [Test]
        public void RemoveCityPositiveTest()
        {
            var resultLoad = this.cityViewModel.LoadData();
            this.cityViewModel.SelectedEntity = this.cityViewModel.Entities.FirstOrDefault(x => x.GetId() == cities[1].GetId());
            var resultRemove = this.cityViewModel.Remove();
            Assert.AreNotEqual(this.cityViewModel.Entities.Any(x => x.GetId() == cities[1].GetId()), true);
        }

        [Test]
        public void SaveCityPositiveTest()
        {
            this.cityViewModel.Entities.Clear();
            this.cityViewModel.Entities.Add(cities[0]);
            var result = this.cityViewModel.Save();
            Assert.AreEqual(this.cityViewModel.Entities.Contains(newCity), true);
        }

        private Mock<IBaseRepository<ICity>> cityViewModelSource;
        private CitiesViewModel cityViewModel;
        private List<ICity> cities = new List<ICity>
            {
                new city(0, "name1", "country1"),
                new city(1, "name2", "country2"),
                new city(2, "name3", "country3")
            };

        private ICity newCity;
    }
}
