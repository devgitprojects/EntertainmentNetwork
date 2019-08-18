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

namespace EntertainmentNetwork.BL.ViewModels
{
    public class CinemaEditViewModel : SingleViewModel<ICinemaRepository, ICinema>
    {
        public CinemaEditViewModel(ICinemaRepository dataSource, CitiesViewModel cityViewModel)
            : base(dataSource)
        {
            this.CityViewModel = cityViewModel;

            this.BindingHalls = new BindingList<IHall>();
            this.BindingHalls.AllowNew = true;
            this.BindingHalls.AddingNew += this.OnHallsAddingNew;

            this.BindingSections = new BindingList<ISection>();
            this.BindingSections.AllowNew = true;
            this.BindingSections.AddingNew += this.OnSectionsAddingNew;

            this.BindingSeats = new BindingList<ISeat[]>();

            Messenger.Default.Register<immutableTriple>(this, OnSimpleCinemaChanged);
        }

        public virtual CitiesViewModel CityViewModel { get; set; }

        #region Components

        public decimal SelectedHallId 
        {
            get
            {
                return this.SelectedHall == null ? -1 : this.SelectedHall.GetId();
            }
            set
            {
                this.SelectedHall = this.BindingHalls.FirstOrDefault(x => x.GetId() == value);
            }
        }

        public virtual IHall SelectedHall { get; set; }

        public virtual BindingList<IHall> BindingHalls { get; set; }

        public virtual ISection SelectedSection { get; set; }

        public virtual BindingList<ISection> BindingSections { get; set; }

        public virtual ISeat SelectedSeat { get; set; }

        public virtual BindingList<ISeat[]> BindingSeats { get; set; }

        public virtual int SeatsCount { get; set; }

        public int RelationCount
        {
            get
            {
                return 1;
            }
        }

        public string HallSectionsRelationName
        {
            get
            {
                return "Sections";
            }
        }

        public string SectionSeatsRelationName
        {
            get
            {
                return "Seats";
            }
        }

        public int SeatsColumnsCount
        {
            get
            {
                var seats = this.BindingSeats.FirstOrDefault();
                return seats == null ? 0 : seats.Length;
            }
        }

        public bool IsSeatActive(ISeat seat)
        {   
            return seat != null && seat.seatIsactive;    
        }

        public ISeat GetSeatByColumnFromSeatRow(IEnumerable<ISeat> row, string columnName)
        {
            return row == null ? null : row.FirstOrDefault(x => x.seatColumn.ToString() == columnName);
        }

        public int GetSeatNumber(ISeat seat)
        {
            return seat == null ? -1 : seat.seatNum;
        }

        public void SetSeatActiveToOpposite(ISeat seat)
        {
            if (seat != null)
            {
                seat.seatIsactive = !seat.seatIsactive;
            }
        }

        public void SetSeatNumber(ISeat seat, string seatNum)
        {
            int result;
            if (seat != null && seatNum != null && int.TryParse(seatNum, out result))
            {
                seat.seatNum = result;
            }
        }

        #endregion

        public virtual void GenerateSeats()
        {
            this.ShowSeatsMapGeneration(); 
        }

        public override async Task LoadData()
        {
            this.IsLoading = true;
            var task = await this.GetData();
            this.DataSource.Update(this.Entity, task);
            this.IsLoading = false;
            this.LoadHalls();
            this.LoadSections();
            this.LoadSeats();
            this.UpdateCommands();
        }

        public override async Task Save()
        {
            this.DataSource.SetCinemaCity(this.Entity, this.CityViewModel.SelectedEntity);
            await base.Save();
        }

        public override async Task Remove()
        {
            await base.Remove();
            this.DataSource.Reset(this.Entity);
        }

        public async Task RemoveSeats()
        {
            if (this.BindingSeats.Count > 0)
            {
                this.BindingSeats.Clear();
                await this.Save();
            }
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

        public override void UpdateCommands()
        {           
            #pragma warning disable 4014
            this.RaiseCanExecuteChanged(x => x.GenerateSeats());
            #pragma warning restore 4014
            base.UpdateCommands();
        }

        protected IDocumentManagerService DocumentService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        protected override async Task<ICinema> GetData()
        {
            var id = ((ISupportParameter)this).Parameter as immutableTriple;
            if (id == null || !this.Entity.IsNew)
            {
                return await this.DataSource.FindById(this.Entity.id);
            }
            else
            {
                return await this.DataSource.FindBySimplifiedCinema(id);
            }
        }

        protected virtual void OnSimpleCinemaChanged(immutableTriple simpleCinema)
        {
            ((ISupportParameter)this).Parameter = simpleCinema;
        }

        protected virtual void OnSelectedSectionChanged()
        {
            this.UpdateCommands();
            this.LoadSeats();
            Messenger.Default.Send<ISection>(this.SelectedSection);
        }

        protected virtual void OnSelectedHallChanged()
        {
            this.UpdateCommands();
            this.LoadSections();
            this.LoadSeats();
        }

        protected override void OnParameterChanged(object parameter)
        {
            this.DataSource.Reset(this.Entity);
            if (parameter == null)
            {
                this.LoadHalls();
                this.LoadSections();
                this.LoadSeats();
            }
            else
            {
                var task = this.LoadData();
            }
        }

        private void ShowSeatsMapGeneration()
        {
            var document = this.DocumentService.CreateDocument("SeatsMapGeneration", null, this);
            document.Id = "_" + System.Guid.NewGuid().ToString().Replace('-', '_');
            document.DestroyOnClose = true;
            document.Show();
        }

        #region Load components

        public void LoadHalls()
        {
            this.BindingHalls.ListChanged -= this.OnBindingHallsListChanged;
            this.LoadComponents<IHall>(this.BindingHalls,
                () => this.DataSource.GetHalls(this.Entity), (list) => this.SelectedHall = list.FirstOrDefault());
            this.BindingHalls.ListChanged += this.OnBindingHallsListChanged;
        }

        public void LoadSections()
        {
            this.BindingSections.ListChanged -= this.OnBindingSectionsListChanged;
            this.LoadComponents<ISection>(this.BindingSections,
                () => this.DataSource.GetSections(this.SelectedHall), (list) => this.SelectedSection = list.FirstOrDefault());
            this.BindingSections.ListChanged += this.OnBindingSectionsListChanged;
        }

        public void LoadSeats()
        {
            this.BindingSeats.ListChanged -= this.OnBindingSeatsListChanged;
            this.LoadComponents<ISeat[]>(this.BindingSeats, () => this.DataSource.GetSeats(this.SelectedSection), (list) => { });
            this.SeatsCount = this.BindingSeats.Count * (this.BindingSeats.Any() ? this.BindingSeats.FirstOrDefault().Count() : 0);
            this.BindingSeats.ListChanged += this.OnBindingSeatsListChanged;
        }

        protected void LoadComponents<T>(BindingList<T> list, Func<IEnumerable<T>> loader, Action<BindingList<T>> selectorUpdate)
        {
            this.IsLoading = true;

            list.Clear();

            foreach (var entity in loader())
            {
                list.Add(entity);
            }

            selectorUpdate(list);

            this.IsLoading = false;
        }

        #endregion

        #region Components BindingList handlers

        protected virtual void OnBindingHallsListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                this.DataSource.SetHalls(this.Entity, this.BindingHalls);
            }
        }

        protected virtual void OnBindingSectionsListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {
                this.DataSource.SetSections(this.SelectedHall, this.BindingSections);
            }
        }

        protected virtual void OnBindingSeatsListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                this.DataSource.ClearSeats(this.SelectedSection);
            }
        }

        protected virtual void OnHallsAddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = this.DataSource.CreateHall();
        }

        protected virtual void OnSectionsAddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = this.DataSource.CreateSection();
        }

        #endregion
    }
}
