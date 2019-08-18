using Autofac;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.ButtonPanel;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    [ViewType("SeatsMapGeneration")]
    public partial class SeatsMapGenerationForm : BaseModule
    {
        public SeatsMapGenerationForm()
        {
            this.InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonGenerateSeats });

            this.mvvmContext1.ViewModelType = typeof(SeatsMapGenerationViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<SeatsMapGenerationViewModel>();

            var fluentAPI = mvvmContext1.OfType<SeatsMapGenerationViewModel>();

            fluentAPI.SetBinding(this.lookUpEditHalls.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.BindingHalls);
            fluentAPI.WithEvent(this.lookUpEditHalls, "EditValueChanged").SetBinding(x => x.CinemaEditViewModel.SelectedHall, args => this.lookUpEditHalls.EditValue);
            fluentAPI.SetBinding(this.lookUpEditHalls, lookup => lookup.EditValue, x => x.CinemaEditViewModel.SelectedHall);

            fluentAPI.SetBinding(this.lookUpEditFloors.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.BindingSections);
            fluentAPI.WithEvent(this.lookUpEditFloors, "EditValueChanged").SetBinding(x => x.CinemaEditViewModel.SelectedSection, args => this.lookUpEditFloors.EditValue);
            fluentAPI.SetBinding(this.lookUpEditFloors, lookup => lookup.EditValue, x => x.CinemaEditViewModel.SelectedSection);

            fluentAPI.SetBinding(this.spinEditRows, spin => spin.EditValue, view => view.RowsCount);
            fluentAPI.SetBinding(this.spinEditColumns, spin => spin.EditValue, view => view.ColumnsPerRowCount);

            fluentAPI.SetBinding(this.labelControlSeatsCount, lbl => lbl.Text, view => view.CinemaEditViewModel.SeatsCount);

            fluentAPI.BindCommand(this.buttonGenerateSeats, view => view.GenerateSeats());
        }

        protected WindowsUIButton buttonGenerateSeats = new WindowsUIButton(Resources.ButtonGenerate, null, "Columns;Size32x32;GrayScaled");
    }
}
