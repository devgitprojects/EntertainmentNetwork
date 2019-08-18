using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class CinemasSearchViewModel : CollectionViewModel<ICinemaReadOnlyRepository, immutableTriple>
    {
        public CinemasSearchViewModel(ICinemaReadOnlyRepository dataSource, CitiesViewModel cityViewModel)
            : base(dataSource) 
        {
            this.Entities = ImmutableList<immutableTriple>.Empty;
            this.CityViewModel = cityViewModel;
            Messenger.Default.Register<ICity>(this, OnCityChanged);
            Messenger.Default.Register<immutablePair>(this, OnShowChanged);
        }

        public virtual CitiesViewModel CityViewModel { get; set; }

        protected IDocumentManagerService DocumentService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        private immutablePair SelectedShow { get; set; }

        public bool CanLoadData()
        {
            return this.CityViewModel.SelectedEntity != null;
        }

        public virtual void New()
        {
            this.ShowEditCinema(null); 
        }

        public virtual void Edit()
        {
            this.ShowEditCinema(this.SelectedEntity); 
        }

        public override async Task LoadData()
        {
            this.IsLoading = true;          
            var result = await this.GetData();
            this.Entities = ImmutableList.Create<immutableTriple>((immutableTriple[])result);
            this.IsLoading = false;
        }

        public virtual bool CanEdit()
        {
            return !this.IsLoading && this.SelectedEntity != null;
        }

        public override bool CanSave()
        {
            return false;
        }

        public override bool CanRemove()
        {
            return false;
        }

        protected override async Task<IEnumerable<immutableTriple>> GetData()
        {
            return await this.DataSource.GetSimplifiedCinemasByCityShow(this.CityViewModel.SelectedEntity, this.SelectedShow);
        }

        protected virtual async void OnCityChanged(ICity city)
        {
            await this.LoadData();
            this.UpdateCommands();
        }

        protected virtual async void OnShowChanged(immutablePair show)
        {
            this.SelectedShow = show;
            await this.LoadData();
            this.UpdateCommands();
            this.SelectedEntity = this.Entities.FirstOrDefault();
            this.SelectedShow = null;
        }

        private void ShowEditCinema(object parameter)
        {
            var document = this.DocumentService.CreateDocument("CinemaEdit", parameter, this);
            document.Id = "_" + System.Guid.NewGuid().ToString().Replace('-', '_');
            document.DestroyOnClose = true;
            document.Show();
        }

        protected override void UpdateCommands()
        {
            base.UpdateCommands();
            #pragma warning disable 4014
            this.RaiseCanExecuteChanged(x => x.Edit());
            #pragma warning restore 4014
        }
    }
}
