using Autofac;
using EntertainmentNetwork.BL.ViewModels;

namespace EntertainmentNetworkClient.Modules
{
    [DevExpress.Utils.MVVM.UI.ViewType("SchedulerSearch")]
    public partial class SchedulerSearch : BaseModule
    {  
        public SchedulerSearch() : base()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Visible = false;

            this.mvvmContext1.ViewModelType = typeof(SchedulerSearchViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<SchedulerSearchViewModel>();

            var fluentAPI = mvvmContext1.OfType<SchedulerSearchViewModel>();
           
            fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.CinemaSearchViewModel.LoadData());
            fluentAPI.SetBinding(this.lookUpEditCinemas.Properties, prop => prop.DataSource, x => x.CinemaSearchViewModel.Entities);
            fluentAPI.WithEvent(this.lookUpEditCinemas, "EditValueChanged").SetBinding(x => x.CinemaSearchViewModel.SelectedEntity, args => this.lookUpEditCinemas.EditValue);
            fluentAPI.SetBinding(this.lookUpEditCinemas, lookup => lookup.EditValue, x => x.CinemaSearchViewModel.SelectedEntity);

            fluentAPI.SetBinding(this.lookUpEditCities.Properties, prop => prop.DataSource, x => x.CinemaSearchViewModel.CityViewModel.Entities);
            fluentAPI.WithEvent(this.lookUpEditCities, "EditValueChanged").SetBinding(x => x.CinemaSearchViewModel.CityViewModel.SelectedEntity, args => this.lookUpEditCities.EditValue);
            fluentAPI.SetBinding(this.lookUpEditCities, lookup => lookup.EditValue, x => x.CinemaSearchViewModel.CityViewModel.SelectedEntity);

            fluentAPI.SetBinding(this.dateEditFromDate, dtEdit => dtEdit.DateTime, view => view.StartDate);
            fluentAPI.SetBinding(this.timeEditFromTime, timeEdit => timeEdit.EditValue, view => view.StartTime);

            fluentAPI.SetBinding(this.dateEditToDate, dtEdit => dtEdit.DateTime, view => view.EndDate);
            fluentAPI.SetBinding(this.timeEditToTime, timeEdit => timeEdit.EditValue, view => view.EndTime);
        }
    }
}
