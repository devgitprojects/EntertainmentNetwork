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
    [ViewType("CinemaEdit")]
    public partial class CinemaEdit : BaseModule
    {
        public CinemaEdit() : base()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonGenerateSeats, this.buttonSave, this.buttonRefresh, this.buttonDelete });          
            this.Initialize();
        }

        private MVVMContextFluentAPI<CinemaEditViewModel> FluentApi { get; set; }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(CinemaEditViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<CinemaEditViewModel>();

            this.FluentApi = this.mvvmContext1.OfType<CinemaEditViewModel>();
            this.FluentApi.SetObjectDataSourceBinding(this.iCinemaBindingSource, x => x.Entity);

            this.FluentApi.SetBinding(this.lookUpEditCities.Properties, prop => prop.DataSource, x => x.CityViewModel.Entities);
            this.FluentApi.SetBinding(this.lookUpEditCities, lookup => lookup.EditValue, x => x.CityViewModel.SelectedEntity);

            this.FluentApi.SetBinding(this.gridHalls, gControl => gControl.DataSource, x => x.BindingHalls);

            this.FluentApi.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridHallsView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedHall, args => args.Row as IHall,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            this.gridHallsView.MasterRowGetRelationCount += (view, e) => e.RelationCount = this.FluentApi.ViewModel.RelationCount;
            this.gridHallsView.MasterRowGetRelationName += (view, e) => e.RelationName = this.FluentApi.ViewModel.HallSectionsRelationName;
            this.gridHallsView.MasterRowGetChildList += (view, e) => e.ChildList = this.FluentApi.ViewModel.BindingSections;

            this.FluentApi.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridViewSections, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedSection, args => args.Row as ISection,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            this.gridViewSections.MasterRowGetRelationCount += (view, e) => e.RelationCount = this.FluentApi.ViewModel.RelationCount;
            this.gridViewSections.MasterRowGetRelationName += (view, e) => e.RelationName = this.FluentApi.ViewModel.SectionSeatsRelationName;
            this.gridViewSections.MasterRowGetChildList += (view, e) => e.ChildList = this.FluentApi.ViewModel.BindingSeats;
            this.gridViewSections.MasterRowGetLevelDefaultView += this.GenerateSeatsViewColumns;

            this.gridViewSeats.FocusedColumnChanged += this.GridViewSeatsFocusedColumnChanged;
            this.gridViewSeats.CustomDrawCell += this.GridViewSeatsCustomDrawCell;
            this.gridViewSeats.CustomRowCellEditForEditing += this.GridViewSeatsCustomRowCellEditForEditing;

            this.repositoryItemUnboundColumnActive.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;
            this.repositoryItemUnboundColumnNotActive.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;

            this.repositoryItemUnboundColumn.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;
            this.repositoryItemUnboundColumn.ButtonClick += this.RepositoryItemUnboundColumnButtonClick; 

            this.FluentApi.BindCommand(this.buttonRefresh, view => view.Reset());
            this.FluentApi.BindCommand(this.buttonSave, view => view.Save());
            this.FluentApi.BindCommand(this.buttonDelete, view => view.Remove());
            this.FluentApi.BindCommand(this.buttonGenerateSeats, view => view.GenerateSeats());
        }

        private void GridViewSeatsFocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                this.FluentApi.ViewModel.SelectedSeat = view.GetFocusedRowCellValue(e.FocusedColumn) as ISeat;
            }
        }

        private void GridViewSeatsCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            var seat = this.FluentApi.ViewModel.GetSeatByColumnFromSeatRow(e.Row as IEnumerable<ISeat>, e.Column.FieldName);
            if (seat != null)
            {
                if (e.IsGetData)
                {
                    e.Value = seat;
                }

                if (e.IsSetData)
                {
                    this.FluentApi.ViewModel.SetSeatNumber(seat, e.Value as string);
                }
            }
        }

        private void GridViewSeatsCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = this.FluentApi.ViewModel.IsSeatActive(e.CellValue as ISeat) ? Color.White : Color.LightGray;
        }

        private void GridViewSeatsCustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem = this.repositoryItemUnboundColumn;
            this.repositoryItemUnboundColumn.Buttons[0].Image = this.FluentApi.ViewModel.IsSeatActive(e.CellValue as ISeat)
                ? this.repositoryItemUnboundColumnActive.Buttons[0].Image
                : this.repositoryItemUnboundColumnNotActive.Buttons[0].Image;
        }


        private void GridViewSeatsCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem = this.FluentApi.ViewModel.IsSeatActive(e.CellValue as ISeat)
                ? this.repositoryItemUnboundColumnActive 
                : this.repositoryItemUnboundColumnNotActive;            
        }

        private void GenerateSeatsViewColumns(object sender, MasterRowGetLevelDefaultViewEventArgs e)
        {
            GridView view = e.DefaultView as GridView;
            if (view != null)
            {
                view.Columns.Clear();

                for (int i = 0; i < this.FluentApi.ViewModel.SeatsColumnsCount; i++)
                {
                    GridColumn unboundColumn = view.Columns.AddField(i.ToString());
                    unboundColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                    unboundColumn.Visible = true; 
                }
            }
        }

        private void RepositoryItemUnboundColumnFormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            e.Value = this.FluentApi.ViewModel.GetSeatNumber(e.Value as ISeat);
        }

        private void RepositoryItemUnboundColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var editor = sender as ButtonEdit;
            this.FluentApi.ViewModel.SetSeatActiveToOpposite(editor.EditValue as ISeat);
            editor.Properties.Buttons[0].Image = this.FluentApi.ViewModel.IsSeatActive(editor.EditValue as ISeat)
                ? this.repositoryItemUnboundColumnActive.Buttons[0].Image
                : this.repositoryItemUnboundColumnNotActive.Buttons[0].Image;
        }

        protected WindowsUIButton buttonGenerateSeats = new WindowsUIButton(Resources.ButtonGenerate, null, "Columns;Size32x32;GrayScaled");
    }
}
