using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL;
using System.ComponentModel;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class CitiesViewModel : CollectionViewModel<IBaseRepository<ICity>, ICity>
    {
        public CitiesViewModel(IBaseRepository<ICity> dataSource) : base(dataSource) 
        {
            this.Entities = new BindingList<ICity>();
            this.Cities.ListChanged += this.OnEntitiesListChanged;
            this.Cities.AllowNew = true;
            this.Cities.AddingNew += OnEntitiesAddingNew;
            var loading = this.LoadData();
        }

        private BindingList<ICity> Cities 
        {
            get 
            {
                return (BindingList<ICity>)this.Entities;
            } 
        }

        public override bool CanSave()
        {
            return !this.IsLoading && this.Entities.Any(x => x.IsNew || x.IsChanged);
        }

        public override bool CanRemove()
        {
            return base.CanRemove() && !this.SelectedEntity.IsNew;
        }

        protected override async Task<IEnumerable<ICity>> GetData()
        {
            return await this.DataSource.GetAll();
        }
    }
}
