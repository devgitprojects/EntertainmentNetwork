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
    public class SchedulerEventEditViewModel : SingleViewModel<ISchedulerRepository, IScheduler>
    {
        public SchedulerEventEditViewModel(ISchedulerRepository dataSource, CinemaEditViewModel cinemaEditViewModel)
            : base(dataSource)
        {
            this.CinemaEditViewModel = cinemaEditViewModel;
        }

        public virtual CinemaEditViewModel CinemaEditViewModel { get; protected set; }

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

        protected override async Task<IScheduler> GetData()
        {
            var id = ((ISupportParameter)this).Parameter as IScheduler;
            if (id == null || !this.Entity.IsNew)
            {
                return await this.DataSource.FindById(this.Entity.id);
            }
            else
            {
                return id;
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
