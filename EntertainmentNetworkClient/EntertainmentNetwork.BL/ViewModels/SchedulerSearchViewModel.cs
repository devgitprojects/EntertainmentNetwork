using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Mvvm;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.ShowService;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class SchedulerSearchViewModel : BaseViewModel, ISupportParameter
    {
        public SchedulerSearchViewModel() { }
        public SchedulerSearchViewModel(CinemasSearchViewModel cinemaSearchViewModel) : base()
        {
            this.CinemaSearchViewModel = cinemaSearchViewModel;
            this.StartDate = DateTime.Now.AddMonths(-1);
            this.EndDate = DateTime.Now.AddMonths(2);
        }

        [Required]
        public virtual DateTime StartDate { get; set; }

        [Required]
        public virtual DateTime StartTime { get; set; }

        [Required]
        public virtual DateTime EndDate { get; set; }

        [Required]
        public virtual DateTime EndTime { get; set; }

        public virtual CinemasSearchViewModel CinemaSearchViewModel { get; set; }

        public IHall SelectedHall { get; set; }

        public immutablePair SelectedShow { get; set; }

        #region ISupportParameter

        object ISupportParameter.Parameter
        {
            get { return parameters; }
            set
            {
                parameters = (object[])value;
                if (parameters.Length == 1)
                {
                    parameters[0] = this;
                }
            }
        }

        #endregion ISupportParameter

        private object[] parameters;
    }
}
