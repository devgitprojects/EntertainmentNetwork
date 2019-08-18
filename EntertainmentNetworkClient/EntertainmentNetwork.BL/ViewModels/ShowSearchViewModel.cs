using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Threading.Tasks;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.ShowService;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class ShowSearchViewModel : CollectionViewModel<IShowReadOnlyRepository, immutablePair>
    {
        public ShowSearchViewModel(IShowReadOnlyRepository dataSource) : base(dataSource)
        {
            this.Entities = ImmutableList<immutablePair>.Empty;
            this.StartDate = DateTime.Now.AddMonths(-1);
            this.EndDate = DateTime.Now.AddMonths(2);
        }
        
        [BindableProperty(OnPropertyChangedMethodName = "OnDateChanged")]
        public virtual DateTime StartDate { get; set; }

        [BindableProperty(OnPropertyChangedMethodName = "OnDateChanged")]
        public virtual DateTime EndDate { get; set; }
        
        protected IDocumentManagerService DocumentService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        public override async Task LoadData()
        {
            this.IsLoading = true;
            var result = await this.GetData();
            this.Entities = ImmutableList.Create<immutablePair>((immutablePair[])result);
            this.IsLoading = false;
        }

        public bool CanLoadData()
        {
            return this.StartDate != null && this.EndDate != null;
        }

        public virtual void New()
        {
            this.ShowEditShow(null);
        }

        public virtual void Edit()
        {
            this.ShowEditShow(this.SelectedEntity);
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

        protected override async Task<IEnumerable<immutablePair>> GetData()
        {
            return await this.DataSource.GetSimplifiedShowsByDates(
                this.StartDate, this.EndDate);
        }

        protected virtual async void OnDateChanged(DateTime startDate)
        {
            await this.LoadData();
        }

        protected override void UpdateCommands()
        {
            base.UpdateCommands();
            #pragma warning disable 4014
            this.RaiseCanExecuteChanged(x => x.Edit());
            #pragma warning restore 4014
        }

        private void ShowEditShow(object parameter)
        {
            var document = this.DocumentService.CreateDocument("ShowEdit", parameter, this);
            document.Id = "_" + System.Guid.NewGuid().ToString().Replace('-', '_');
            document.DestroyOnClose = true;
            document.Show();
        }
    }
}
