using Autofac;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraGrid.Views.Base;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetwork.DAL.Models.Interfaces;

namespace EntertainmentNetworkClient.Modules
{
    public partial class Cities : BaseModule
    {
        public Cities() 
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonSave, this.buttonRefresh, this.buttonDelete });
        }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(CitiesViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<CitiesViewModel>();
            var fluentAPI = mvvmContext1.OfType<CitiesViewModel>();

            fluentAPI.SetBinding(this.gridCities, gControl => gControl.DataSource, x => x.Entities);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridCitiesView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity, args => 
                {
                    if (args.RowHandle < 0)
                    {
                        this.buttonDelete.Enabled = false; 
                    }
                    return args.Row as ICity;
                },
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));

            fluentAPI.BindCommand(this.buttonRefresh, view => view.LoadData());
            fluentAPI.BindCommand(this.buttonSave, view => view.Save());
            fluentAPI.BindCommand(this.buttonDelete, view => view.Remove());
        }
    }
}
