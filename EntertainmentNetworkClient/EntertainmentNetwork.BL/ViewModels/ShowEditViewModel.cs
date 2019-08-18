using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.Models;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class ShowEditViewModel : SingleViewModel<IShowRepository, IShow>
    {
        public ShowEditViewModel(IShowRepository dataSource)
            : base(dataSource)
        {
        }

        public override async Task LoadData()
        {
            this.IsLoading = true;
            var task = await this.GetData();
            this.DataSource.Update(this.Entity, task);
            this.IsLoading = false;
        }

        public override async Task Remove()
        {
            await base.Remove();
            this.DataSource.Reset(this.Entity);
        }

        public override async Task Reset()
        {
            if (this.Entity.IsNew)
            {
                this.DataSource.Reset(this.Entity);
            }
            else
            {
                await this.LoadData();
            }
        }

        protected override async Task<IShow> GetData()
        {
            var id = ((ISupportParameter)this).Parameter as immutablePair;
            if (id == null || !this.Entity.IsNew)
            {
                return await this.DataSource.FindById(this.Entity.id);
            }
            else
            {
                return await this.DataSource.FindBySimplifiedShow(id);
            }
        }

        protected override void OnParameterChanged(object parameter)
        {
            this.DataSource.Reset(this.Entity);
            if (parameter != null)
            {
                var task = this.LoadData();
            }
        }
    }
}
