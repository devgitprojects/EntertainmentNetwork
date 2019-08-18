using System.Collections.Generic;
using System.Drawing;
using Autofac;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.UI;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    [ViewType("ShowEdit")]
    public partial class ShowEdit : BaseModule
    {
        public ShowEdit() : base()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonSave, this.buttonRefresh, this.buttonDelete });          
            this.Initialize();
        }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(ShowEditViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<ShowEditViewModel>();

            var fluentApi = this.mvvmContext1.OfType<ShowEditViewModel>();
            fluentApi.SetObjectDataSourceBinding(this.iShowBindingSource, x => x.Entity);

            fluentApi.BindCommand(this.buttonRefresh, view => view.Reset());
            fluentApi.BindCommand(this.buttonSave, view => view.Save());
            fluentApi.BindCommand(this.buttonDelete, view => view.Remove());
        }
    }
}
