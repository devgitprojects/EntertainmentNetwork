using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class SchedulerViewModel : CollectionViewModel<ISchedulerRepository, IScheduler>
    {
        public SchedulerViewModel(ISchedulerRepository dataSource, ShowSearchViewModel showSearchViewModel, CinemaEditViewModel cinemaEditViewModel)
            : base(dataSource)
        {
            this.ShowSearchViewModel = showSearchViewModel;
            ObservableCollection<IScheduler> observedSchedulers = new ObservableCollection<IScheduler>();
            observedSchedulers.CollectionChanged += this.OnSchedulersCollectionChanged;
            this.Entities = new BindingList<IScheduler>(observedSchedulers);
            this.Schedulers.AllowNew = true;
            this.Schedulers.AddingNew += OnEntitiesAddingNew;
            this.Schedulers.ListChanged += this.OnEntitiesListChanged;

            Messenger.Default.Register<SchedulerSearchViewModel>(this, OnSchedulerSearchViewModelChanged);
        }

        public virtual ShowSearchViewModel ShowSearchViewModel { get; set; }
                
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }

        private BindingList<IScheduler> Schedulers 
        {
            get
            {
                return (BindingList<IScheduler>)this.Entities;
            }
        }                

        public override bool CanSave()
        {
            return !this.IsLoading && this.Entities.Any(x => x.IsNew || x.IsChanged);
        }

        public bool CanLoadData()
        {
            return this.Entities.Any();
        }

        public async Task SearchSchedulers()
        {
            this.parameters = new object[1]; /// used as exchange object between search dialog and current view
            if (this.DialogService.ShowDialog(MessageButton.OKCancel, "Schedulers Search", "SchedulerSearch", parameters, this) == MessageResult.OK)
            {
                var exchangeview = this.parameters[0] as SchedulerSearchViewModel;
                this.ShowSearchViewModel.StartDate = exchangeview.StartDate;
                this.ShowSearchViewModel.EndDate = exchangeview.EndDate;
                await this.ShowSearchViewModel.LoadData();
                await this.LoadData();
            }
        }

        protected override async Task<IEnumerable<IScheduler>> GetData()
        {
            var exchangeview = this.parameters[0] as SchedulerSearchViewModel;
            return await this.DataSource.GetSchedulersByCinemaHallShowDates(
                exchangeview.CinemaSearchViewModel.SelectedEntity,
                exchangeview.SelectedHall,
                exchangeview.SelectedShow,
                exchangeview.StartDate.Add(exchangeview.StartTime.TimeOfDay),
                exchangeview.EndDate.Add(exchangeview.EndTime.TimeOfDay));
        }

        private void OnSchedulersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (IScheduler schedule in e.OldItems)
                {
                    this.DataSource.Remove(schedule);
                }
            }
        }

        protected virtual async void OnSchedulerSearchViewModelChanged(SchedulerSearchViewModel schedulerSearchViewModel)
        {
            this.parameters = new object[] { schedulerSearchViewModel };
            await this.LoadData();
        }


        private object[] parameters; /// used as exchange object between search dialog and current view
    }
}
