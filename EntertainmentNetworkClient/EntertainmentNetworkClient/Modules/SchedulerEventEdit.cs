using System;
using Autofac;
using DevExpress.Utils.MVVM;
using DevExpress.XtraScheduler;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;


namespace EntertainmentNetworkClient.Modules
{
    public partial class SchedulerEventEdit : DevExpress.XtraScheduler.UI.AppointmentForm
    {
        public SchedulerEventEdit(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm) 
        {
            InitializeComponent();
            this.mvvmContext1.ViewModelType = typeof(SchedulerEventEditViewModel);
            this.mvvmContext1.ViewModelCreate += (o, e) => e.ViewModel = AutofacConfig.IoC.Resolve<SchedulerEventEditViewModel>();
            this.FluentApi = mvvmContext1.OfType<SchedulerEventEditViewModel>();
            this.FluentApi.SetBinding(this.lookUpEditHalls.Properties, prop => prop.DataSource, x => x.CinemaEditViewModel.BindingHalls);
            this.FluentApi.WithEvent(this.lookUpEditHalls, "EditValueChanged").SetBinding(x => x.CinemaEditViewModel.SelectedHall, args => this.lookUpEditHalls.EditValue);
            this.FluentApi.SetBinding(this.lookUpEditHalls, lookup => lookup.EditValue, x => x.CinemaEditViewModel.SelectedHall);

            this.idTextEdit.Text = apt.Id == null ? String.Empty : apt.Id.ToString();
        }

        private MVVMContextFluentAPI<SchedulerEventEditViewModel> FluentApi { get; set; }
       
        private decimal AppointmentHallId
        {
            get
            {
                var id = this.Controller.EditedAppointmentCopy.CustomFields[Resources.FieldNameHallId];
                return id is decimal ? (decimal)id : -1;
            }
            set
            {
                this.Controller.EditedAppointmentCopy.CustomFields[Resources.FieldNameHallId] = value; 
            }
        }

        private decimal AppointmentCoefficient
        {
            get
            {
                var id = this.Controller.EditedAppointmentCopy.CustomFields[Resources.FieldNameSchedulerCoefficient];
                return id is decimal ? (decimal)id : 1;
            }
            set
            {
                this.Controller.EditedAppointmentCopy.CustomFields[Resources.FieldNameSchedulerCoefficient] = value;
            }
        }

        /// <summary>
        /// Add your code to obtain a custom field value and fill the editor with data.
        /// </summary>
        public override void LoadFormData(Appointment appointment)
        {           
            base.LoadFormData(appointment);
            this.spinEditCoefficient.EditValue = this.AppointmentCoefficient;
            this.FluentApi.ViewModel.CinemaEditViewModel.SelectedHallId = this.AppointmentHallId;  
        }

        /// <summary>
        /// Add your code to retrieve a value from the editor and set the custom appointment field.
        /// </summary>
        public override bool SaveFormData(Appointment appointment)
        {
            this.AppointmentHallId = this.FluentApi.ViewModel.CinemaEditViewModel.SelectedHallId;
            this.AppointmentCoefficient = (decimal)this.spinEditCoefficient.EditValue;
            return base.SaveFormData(appointment);
        }

        /// <summary>
        /// Add your code to notify that any custom field is changed. Return true if a custom field is changed, otherwise false.
        /// </summary>
        public override bool IsAppointmentChanged(Appointment appointment)
        {
            return true;
        }
    }
}
