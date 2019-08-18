using Autofac;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraGrid.Views.Base;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    public partial class CinemasSearch : BaseModule
    {  
        public CinemasSearch() : base()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonAddNew, this.buttonEditSelected, this.buttonRefresh });
        }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(CinemasSearchViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) =>  e.ViewModel = AutofacConfig.IoC.Resolve<CinemasSearchViewModel>(); 

            var fluentAPI = mvvmContext1.OfType<CinemasSearchViewModel>();
            
            fluentAPI.WithEvent(this, "Load").EventToCommand(x => x.LoadData());
            fluentAPI.SetBinding(this.lookUpEditCities.Properties, prop => prop.DataSource, x => x.CityViewModel.Entities);
            fluentAPI.WithEvent(this.lookUpEditCities, "EditValueChanged").SetBinding(x => x.CityViewModel.SelectedEntity, args => this.lookUpEditCities.EditValue);
            fluentAPI.SetBinding(this.lookUpEditCities, lookup => lookup.EditValue, x => x.CityViewModel.SelectedEntity);

            fluentAPI.SetBinding(this.gridCinemas, gControl => gControl.DataSource, x => x.Entities);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridCinemasView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity, args => args.Row as EntertainmentNetwork.DAL.CinemaService.immutableTriple,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));

            fluentAPI.BindCommand(this.buttonRefresh, view => view.LoadData());
            fluentAPI.BindCommand(this.buttonAddNew, view => view.New());
            fluentAPI.BindCommand(this.buttonEditSelected, view => view.Edit());
        }

        private WindowsUIButton buttonAddNew = new WindowsUIButton(Resources.ButtonAddNew, null, "AddItem;Size32x32;GrayScaled");
        private WindowsUIButton buttonEditSelected = new WindowsUIButton(Resources.ButtonEditSelected, null, "Edit;Size32x32;GrayScaled");
    }
}
