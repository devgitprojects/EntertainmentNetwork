using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.DAL;

namespace EntertainmentNetwork.BL.ViewModels
{
    public class SeatsMapGenerationViewModel : BaseViewModel
    {
        public SeatsMapGenerationViewModel(CinemaEditViewModel cinemaEditViewModel)
            : base() 
        {
            this.CinemaEditViewModel = cinemaEditViewModel;
        }

        public virtual CinemaEditViewModel CinemaEditViewModel { get; set; }

        public virtual int RowsCount { get; set; }

        public virtual int ColumnsPerRowCount { get; set; }

        public virtual int GetSeatsCount()
        {
            return this.CinemaEditViewModel.SeatsCount;
        }

        public virtual async Task GenerateSeats()
        {
            if (this.MessageBoxService.ShowMessage("Are you sure to generate seats map for selected section? This removes previously generated seats map.",
                "Remove previously generated seats map.", MessageButton.OKCancel, MessageIcon.Question, MessageResult.Cancel) == MessageResult.OK)
            {
                await this.CinemaEditViewModel.RemoveSeats();
                await this.CinemaEditViewModel.DataSource.GenerateSeats(this.CinemaEditViewModel.SelectedSection, this.RowsCount, this.ColumnsPerRowCount);
                this.CinemaEditViewModel.LoadSeats();
            }
        }

        public virtual bool CanGenerateSeats()
        {
            return this.CinemaEditViewModel.SelectedHall != null && this.CinemaEditViewModel.SelectedSection != null;
        }

        protected IMessageBoxService MessageBoxService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }

    }
}
