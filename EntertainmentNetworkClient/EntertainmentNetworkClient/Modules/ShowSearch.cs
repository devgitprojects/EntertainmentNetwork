using Autofac;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraGrid.Views.Base;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    public partial class ShowSearch : BaseModule
    {  
        public ShowSearch() : base()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonSearch, this.buttonAddNew, this.buttonEditSelected });
        }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(ShowSearchViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<ShowSearchViewModel>();

            var fluentAPI = mvvmContext1.OfType<ShowSearchViewModel>();
            fluentAPI.SetBinding(this.gridShows, gControl => gControl.DataSource, view => view.Entities);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridViewShows, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity, args => args.Row as EntertainmentNetwork.DAL.ShowService.immutablePair,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));

            fluentAPI.SetBinding(this.dateEditStartDate, dtEdit => dtEdit.DateTime, view => view.StartDate);
            fluentAPI.SetBinding(this.dateEditEndDate, dtEdit => dtEdit.DateTime, view => view.EndDate);

            fluentAPI.BindCommand(this.buttonSearch, view => view.LoadData());
            fluentAPI.BindCommand(this.buttonAddNew, view => view.New());
            fluentAPI.BindCommand(this.buttonEditSelected, view => view.Edit());
        }

        private WindowsUIButton buttonAddNew = new WindowsUIButton(Resources.ButtonAddNew, null, "AddItem;Size32x32;GrayScaled");
        private WindowsUIButton buttonEditSelected = new WindowsUIButton(Resources.ButtonEditSelected, null, "Edit;Size32x32;GrayScaled");
        private WindowsUIButton buttonSearch = new WindowsUIButton(Resources.ButtonSearch, null, "Find;Size32x32;GrayScaled");
    }
}
