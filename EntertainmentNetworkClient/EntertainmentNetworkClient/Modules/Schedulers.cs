using Autofac;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraScheduler;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    public partial class Schedulers : BaseModule
    {
        public Schedulers()
        {
            InitializeComponent();
            this.windowsUIButtonPanelMain.Buttons.AddRange(new IBaseButton[] { this.buttonSearch, this.buttonSave, this.buttonRefresh, this.buttonDelete });
        }

        private MVVMContextFluentAPI<SchedulerViewModel> FluentApi { get; set; }

        public override void Initialize()
        {
            this.mvvmContext1.ViewModelType = typeof(SchedulerViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<SchedulerViewModel>();
            this.FluentApi = mvvmContext1.OfType<SchedulerViewModel>();

            this.FluentApi.SetBinding(this.schedulerStorage.Resources, resources => resources.DataSource, x => x.ShowSearchViewModel.Entities);
            this.FluentApi.SetBinding(this.schedulerStorage.Appointments, appointments => appointments.DataSource, x => x.Entities);

            this.FluentApi.BindCommand(this.buttonSearch, view => view.SearchSchedulers());
            this.FluentApi.BindCommand(this.buttonRefresh, view => view.LoadData());
            this.FluentApi.BindCommand(this.buttonSave, view => view.Save());
            this.buttonDelete.Click += (o, e) => this.schedulerControl.DeleteSelectedAppointments();
                                   
            this.schedulerControl.EditAppointmentFormShowing += OnSchedulerControlEditAppointmentFormShowing;
        }

        private void OnSchedulerControlEditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            SchedulerEventEdit form = new SchedulerEventEdit(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }
        }

        private WindowsUIButton buttonSearch = new WindowsUIButton(Resources.ButtonSearch, null, "Find;Size32x32;GrayScaled");
    }
}
