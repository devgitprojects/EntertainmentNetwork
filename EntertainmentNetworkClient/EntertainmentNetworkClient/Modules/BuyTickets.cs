using Autofac;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetworkClient.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace EntertainmentNetworkClient.Modules
{
    public partial class BuyTickets : BaseModule
    {
        public BuyTickets()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonBuy });          
        }

        private MVVMContextFluentAPI<TicketsViewModel> FluentApi { get; set; }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(TicketsViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<TicketsViewModel>();

            this.FluentApi = this.mvvmContext1.OfType<TicketsViewModel>();
           
            this.FluentApi.SetBinding(this.lookUpEditCities.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.CityViewModel.Entities);
            this.FluentApi.SetBinding(this.lookUpEditCities, lookup => lookup.EditValue, x => x.CinemaEditViewModel.CityViewModel.SelectedEntity);
            
            this.FluentApi.SetBinding(this.dateEditStartDate, dtEdit => dtEdit.DateTime, view => view.SchedulerViewModel.ShowSearchViewModel.StartDate);
            this.FluentApi.SetBinding(this.dateEditEndDate, dtEdit => dtEdit.DateTime, view => view.SchedulerViewModel.ShowSearchViewModel.EndDate);

            this.FluentApi.SetBinding(this.lookUpEditShow.Properties, prop => prop.DataSource, x => x.SchedulerViewModel.ShowSearchViewModel.Entities);
            this.FluentApi.SetBinding(this.lookUpEditShow, lookup => lookup.EditValue, x => x.SchedulerViewModel.ShowSearchViewModel.SelectedEntity);

            this.FluentApi.SetBinding(this.lookUpEditCinema.Properties, prop => prop.DataSource, x => x.CinemaSearchViewModel.Entities);
            this.FluentApi.SetBinding(this.lookUpEditCinema, lookup => lookup.EditValue, x => x.CinemaSearchViewModel.SelectedEntity);

            this.FluentApi.SetBinding(this.lookUpEditHall.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.BindingHalls);
            this.FluentApi.SetBinding(this.lookUpEditHall, lookup => lookup.EditValue, x => x.CinemaEditViewModel.SelectedHall);
            this.lookUpEditHall.EditValueChanged += (o, e) => Messenger.Default.Send<SchedulerSearchViewModel>(new SchedulerSearchViewModel
            {
                StartDate = this.FluentApi.ViewModel.SchedulerViewModel.ShowSearchViewModel.StartDate,
                SelectedHall = this.FluentApi.ViewModel.CinemaEditViewModel.SelectedHall,
                SelectedShow = this.FluentApi.ViewModel.SchedulerViewModel.ShowSearchViewModel.SelectedEntity,
                EndDate = this.FluentApi.ViewModel.SchedulerViewModel.ShowSearchViewModel.EndDate,
                CinemaSearchViewModel = this.FluentApi.ViewModel.CinemaSearchViewModel
            });

            this.FluentApi.SetBinding(this.lookUpEditSection.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.BindingSections);
            this.FluentApi.SetBinding(this.lookUpEditSection, lookup => lookup.EditValue, x => x.CinemaEditViewModel.SelectedSection);

            this.FluentApi.SetBinding(this.lookUpEditSchedule.Properties, prop => prop.DataSource, x => x.SchedulerViewModel.Entities);
            this.FluentApi.SetBinding(this.lookUpEditSchedule, lookup => lookup.EditValue, x => x.SchedulerViewModel.SelectedEntity);

            this.FluentApi.SetBinding(this.gridControlSeatsMap, gControl => gControl.DataSource, x => x.SeatsPerTickets);

            this.FluentApi.SetTrigger(x => x.SelectedSection, (section) => this.GenerateSeatsViewColumns());
            this.FluentApi.SetTrigger(x => x.SelectedScheduler, (scheduler) =>  this.GenerateSeatsViewColumns());
            this.FluentApi.SetTrigger(x => x.SelectedShow, (show) => this.GenerateSeatsViewColumns());

            this.FluentApi.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(this.gridViewSeatsMap, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedSeatsRow, args => args.Row as Dictionary<ISeat, ITicket>,
                (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));

            this.gridViewSeatsMap.FocusedColumnChanged += this.GridViewSeatsFocusedColumnChanged;
            this.gridViewSeatsMap.CustomDrawCell += this.GridViewSeatsCustomDrawCell;
            this.gridViewSeatsMap.CustomRowCellEditForEditing += this.GridViewSeatsCustomRowCellEditForEditing;

            this.FluentApi.SetBinding(this.textEditPrice, textEditPrice => textEditPrice.EditValue, x => x.Price);

            this.repositoryItemUnboundColumnActive.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;
            this.repositoryItemUnboundColumnNotActive.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;

            this.repositoryItemUnboundColumn.FormatEditValue += this.RepositoryItemUnboundColumnFormatEditValue;
            this.repositoryItemUnboundColumn.ButtonClick += this.RepositoryItemUnboundColumnButtonClick;

            this.FluentApi.BindCommand(this.buttonBuy, view => view.OrderViewModel.Reset());
            this.buttonBuy.Click += (o, e) => this.LoadTreeListData();
        }

        private void GridViewSeatsFocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var cellValue = view.GetFocusedRowCellValue(e.FocusedColumn);
                if (cellValue is KeyValuePair<ISeat, ITicket>)
                {
                    this.FluentApi.ViewModel.CinemaEditViewModel.SelectedSeat = ((KeyValuePair<ISeat, ITicket>)cellValue).Key;
                }
            }
        }

        private void GridViewSeatsCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            var seat = this.FluentApi.ViewModel.GetSeatByColumnFromSeatTicketRow(e.Row as Dictionary<ISeat, ITicket>, e.Column.FieldName);
           
            if (e.IsGetData)
            {
                e.Value = seat;
            }          
        }

        private void GridViewSeatsCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.BackColor = this.FluentApi.ViewModel.IsSeatTicketActive(e.CellValue) ? Color.White : Color.LightGray;
        }

        private void GridViewSeatsCustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem = this.repositoryItemUnboundColumn;
            this.repositoryItemUnboundColumn.Buttons[0].Image = this.FluentApi.ViewModel.IsSeatTicketActive(e.CellValue)
                ? this.repositoryItemUnboundColumnActive.Buttons[0].Image
                : this.repositoryItemUnboundColumnNotActive.Buttons[0].Image;
        }


        private void GridViewSeatsCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem = this.FluentApi.ViewModel.IsSeatTicketActive(e.CellValue)
                ? this.repositoryItemUnboundColumnActive
                : this.repositoryItemUnboundColumnNotActive;
        }

        private async void GenerateSeatsViewColumns()
        {
            this.gridViewSeatsMap.Columns.Clear();
            if (this.FluentApi.ViewModel.CanLoadData())
            {
                await this.FluentApi.ViewModel.LoadData();
                for (int i = 0; i < this.FluentApi.ViewModel.CinemaEditViewModel.SeatsColumnsCount; i++)
                {
                    GridColumn unboundColumn = this.gridViewSeatsMap.Columns.AddField(i.ToString());
                    unboundColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                    unboundColumn.Visible = true;
                }
            }
        }

        private void RepositoryItemUnboundColumnFormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            e.Value = this.FluentApi.ViewModel.GetTicketSeatText(e.Value);
        }

        private void RepositoryItemUnboundColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var editor = sender as ButtonEdit;
            var result = Task.Run(() => this.FluentApi.ViewModel.GenerateTicket()).Result;
            editor.EditValue = result;
            editor.Properties.Buttons[0].Image = this.FluentApi.ViewModel.IsSeatTicketActive(editor.EditValue)
                ? this.repositoryItemUnboundColumnActive.Buttons[0].Image
                : this.repositoryItemUnboundColumnNotActive.Buttons[0].Image;
            this.LoadTreeListData();            
        }

        private void LoadTreeListData()
        {
            this.treeListOrders.Nodes.Clear();
            this.treeListOrders.AppendNode(this.FluentApi.ViewModel.OrderViewModel.Entity.ToArray(), null);

            foreach (var tct in this.FluentApi.ViewModel.OrderTicketsToArrayData())
            {
                this.treeListOrders.AppendNode(tct, this.treeListOrders.Nodes[0]);
            }
        }

        protected WindowsUIButton buttonBuy = new WindowsUIButton(Resources.ButtonBuy, null, "ShoppingCart;Size32x32;GrayScaled");
    }
}
