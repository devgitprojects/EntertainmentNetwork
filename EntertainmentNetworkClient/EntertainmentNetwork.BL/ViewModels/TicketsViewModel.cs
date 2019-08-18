using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.ShowService;
using EntertainmentNetwork.DAL.TicketService;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class TicketsViewModel : CollectionViewModel<ITicketRepository, ITicket>
    {
        public TicketsViewModel(ITicketRepository dataSource, CinemasSearchViewModel cinemaSearchViewModel,
            CinemaEditViewModel cinemaEditViewModel, SchedulerViewModel schedulerViewModel, OrderViewModel orderViewModel) : base(dataSource) 
        {
            this.CinemaSearchViewModel = cinemaSearchViewModel;
            this.CinemaEditViewModel = cinemaEditViewModel;
            this.SchedulerViewModel = schedulerViewModel;
            this.OrderViewModel = orderViewModel;
            this.Entities = new BindingList<ITicket>();
            this.Tickets.ListChanged += this.OnEntitiesListChanged;
            this.Tickets.AllowNew = true;
            this.Tickets.AddingNew += OnEntitiesAddingNew;

            this.SeatsPerTickets = new BindingList<Dictionary<ISeat, ITicket>>();
           
            Messenger.Default.Register<IScheduler>(this, OnSchedulerChanged);
            Messenger.Default.Register<ISection>(this, OnSectionChanged);
            Messenger.Default.Register<immutablePair>(this, OnShowChanged);
        }

        public virtual decimal Price { get; set; }

        public virtual ISection SelectedSection { get; set; }

        public virtual IScheduler SelectedScheduler { get; set; }

        public virtual immutablePair SelectedShow { get; set; }

        public virtual Dictionary<ISeat, ITicket> SelectedSeatsRow { get; set; }

        public virtual CinemaEditViewModel CinemaEditViewModel { get; set; }

        public virtual CinemasSearchViewModel CinemaSearchViewModel { get; set; }

        public virtual SchedulerViewModel SchedulerViewModel { get; set; }

        public virtual OrderViewModel OrderViewModel { get; set; }

        public virtual BindingList<Dictionary<ISeat, ITicket>> SeatsPerTickets { get; set; }

        private BindingList<ITicket> Tickets 
        {
            get 
            {
                return (BindingList<ITicket>)this.Entities;
            } 
        }

        protected IMessageBoxService DialogService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }

        public virtual async Task<ITicket> GenerateTicket()
        {
            ITicket ticket = null;
            if (this.CanGenerateTicket())
            {
                try
                {
                   await Task.Run(() => this.OrderViewModel.LoadData());
                   var result = await Task.Run(() => this.DataSource.GenerateTicket(
                        this.SchedulerViewModel.SelectedEntity,
                        this.CinemaEditViewModel.SelectedSeat,
                        this.CinemaEditViewModel.SelectedSection,
                        this.SchedulerViewModel.ShowSearchViewModel.SelectedEntity,
                        this.OrderViewModel.Entity));
                    this.SelectedSeatsRow[this.CinemaEditViewModel.SelectedSeat] = result;
                    await Task.Run(() => this.OrderViewModel.LoadData());
                    return this.SelectedSeatsRow[this.CinemaEditViewModel.SelectedSeat];
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException is FaultException<TicketSoldException>)
                    {
                        this.DialogService.ShowMessage(ex.InnerException.Message, ex.InnerException.Message, MessageButton.OK, MessageIcon.Information);
                    }
                    else
                    {
                        throw ex;
                    }
                }

                var reload = this.LoadData();
            }

            return ticket;
        }

        public KeyValuePair<ISeat, ITicket> GetSeatByColumnFromSeatTicketRow(Dictionary<ISeat, ITicket> seatsTickets, string columnName)
        {
            return seatsTickets == null ? default(KeyValuePair<ISeat, ITicket>) : seatsTickets.FirstOrDefault(x => x.Key.seatColumn.ToString() == columnName);
        }

        public string GetTicketSeatText(object seatTicket)
        {
            string text = "N/A";
            if (seatTicket is KeyValuePair<ISeat, ITicket> && ((KeyValuePair<ISeat, ITicket>)seatTicket).Key != null)
            {
                if (((KeyValuePair<ISeat, ITicket>)seatTicket).Key.seatIsactive)
                {
                    if (((KeyValuePair<ISeat, ITicket>)seatTicket).Value != null)
                    {
                        text = String.Format("{0} - Sold", ((KeyValuePair<ISeat, ITicket>)seatTicket).Key.seatNum);
                    }
                    else
                    {
                        text = ((KeyValuePair<ISeat, ITicket>)seatTicket).Key.seatNum.ToString();
                    }
                }
            }

            return text;
        }

        public bool IsSeatTicketActive(object seatTicket)
        {
            return seatTicket is KeyValuePair<ISeat, ITicket>
                && ((KeyValuePair<ISeat, ITicket>)seatTicket).Key != null
                && ((KeyValuePair<ISeat, ITicket>)seatTicket).Key.seatIsactive 
                && ((KeyValuePair<ISeat, ITicket>)seatTicket).Value == null;
        }

        public virtual bool CanGenerateTicket()
        {
            return this.SelectedSeatsRow != null 
                && this.CinemaEditViewModel.SelectedSeat != null
                && this.SchedulerViewModel.SelectedEntity != null
                && this.CinemaEditViewModel.SelectedSeat.seatIsactive
                && (this.SelectedSeatsRow.ContainsKey(this.CinemaEditViewModel.SelectedSeat) 
                    && this.SelectedSeatsRow[this.CinemaEditViewModel.SelectedSeat] == null);
        }

        public override async Task LoadData()
        {
            await base.LoadData();

            this.IsLoading = true;
            this.SeatsPerTickets.Clear();

            foreach (var seatsRow in this.CinemaEditViewModel.BindingSeats)
            {
                var test = seatsRow.Select(x => new 
                {
                    Key = x,
                    Value = this.Tickets.FirstOrDefault(tct => this.DataSource.IsSeatIsSold(x, tct))
                }).ToDictionary(x => x.Key, x => x.Value);
                this.SeatsPerTickets.Add(test);
            }

            this.IsLoading = false;
        }

        public bool CanLoadData()
        {
            return this.SchedulerViewModel.SelectedEntity != null;
        }

        public override bool CanSave()
        {
            return !this.IsLoading;
        }

        public override bool CanRemove()
        {
            return base.CanRemove() && !this.SelectedEntity.IsNew;
        }

        public object[] OrderTicketsToArrayData()
        {
            return this.OrderViewModel.Entity.TicketsToArrayData();
        }

        protected override async Task<IEnumerable<ITicket>> GetData()
        {
            return await this.DataSource.GetTicketsByScheduler(this.SchedulerViewModel.SelectedEntity);
        }

        protected void OnSchedulerChanged(IScheduler scheduler)
        {
            this.SelectedScheduler = scheduler;
        }

        protected void OnSectionChanged(ISection section)
        {
            this.SelectedSection = section;
        }

        protected void OnShowChanged(immutablePair show)
        {
            this.SelectedShow = show;
        }
    }
}
