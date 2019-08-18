namespace EntertainmentNetworkClient
{
    partial class EntertainmentNetworkMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.hubGroup = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TabbedGroup(this.components);
            this.docCities = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.docCinemas = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.docShows = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.docBuyTickets = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.docSchedulers = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.LoginFlyout = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(this.components);
            this.docLoginPage = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.flyoutSeatsMapGenerationForm = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(this.components);
            this.docSeatsMapGenerationForm = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.pageCinemaEdit = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page(this.components);
            this.docCinemaEdit = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.flyoutSchedulerAppointmentForm = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(this.components);
            this.docSchedulerAppointmentForm = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.flyoutSchedulersSearch = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(this.components);
            this.docSchedulersSearch = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.baseModuleDocument = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.viewsManagerDocument = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hubGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCinemas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBuyTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginFlyout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLoginPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSeatsMapGenerationForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSeatsMapGenerationForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageCinemaEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCinemaEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSchedulerAppointmentForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulerAppointmentForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSchedulersSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulersSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseModuleDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewsManagerDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.BackgroundImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.BottomLeft;
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.hubGroup,
            this.LoginFlyout,
            this.flyoutSeatsMapGenerationForm,
            this.flyoutSchedulerAppointmentForm,
            this.pageCinemaEdit,
            this.flyoutSchedulersSearch});
            this.windowsUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.docCities,
            this.docLoginPage,
            this.docCinemas,
            this.baseModuleDocument,
            this.viewsManagerDocument,
            this.docShows,
            this.docSchedulersSearch,
            this.docSchedulerAppointmentForm,
            this.docBuyTickets,
            this.docCinemaEdit,
            this.docSeatsMapGenerationForm,
            this.docSchedulers});
            this.windowsUIView1.UseSplashScreen = DevExpress.Utils.DefaultBoolean.False;
            // 
            // hubGroup
            // 
            this.hubGroup.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document[] {
            this.docCities,
            this.docCinemas,
            this.docShows,
            this.docBuyTickets,
            this.docSchedulers});
            this.hubGroup.Name = "hubGroup";
            this.hubGroup.Parent = this.LoginFlyout;
            this.hubGroup.Properties.AllowHtmlDrawHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.hubGroup.Properties.HeaderOffset = -12;
            this.hubGroup.Properties.HeaderStyle = DevExpress.XtraBars.Docking2010.Views.WindowsUI.HeaderStyle.Tile;
            this.hubGroup.Properties.Margin = new System.Windows.Forms.Padding(-8, -56, 10, 30);
            this.hubGroup.Properties.TileSize = 140;
            // 
            // docCities
            // 
            this.docCities.Caption = "Cities";
            this.docCities.ControlName = "Cities";
            this.docCities.ControlTypeName = "EntertainmentNetworkClient.Modules.Cities";
            this.docCities.Header = "Cities";
            // 
            // docCinemas
            // 
            this.docCinemas.Caption = "Cinemas";
            this.docCinemas.ControlName = "CinemasSearch";
            this.docCinemas.ControlTypeName = "EntertainmentNetworkClient.Modules.CinemasSearch";
            this.docCinemas.Header = "Cinemas";
            // 
            // docShows
            // 
            this.docShows.Caption = "Shows";
            this.docShows.ControlName = "ShowSearch";
            this.docShows.ControlTypeName = "EntertainmentNetworkClient.Modules.ShowSearch";
            // 
            // docBuyTickets
            // 
            this.docBuyTickets.Caption = "BuyTickets";
            this.docBuyTickets.ControlName = "BuyTickets";
            this.docBuyTickets.ControlTypeName = "EntertainmentNetworkClient.Modules.BuyTickets";
            // 
            // docSchedulers
            // 
            this.docSchedulers.Caption = "Schedulers";
            this.docSchedulers.ControlName = "Schedulers";
            this.docSchedulers.ControlTypeName = "EntertainmentNetworkClient.Modules.Schedulers";
            this.docSchedulers.Header = "Schedulers";
            // 
            // LoginFlyout
            // 
            this.LoginFlyout.Document = this.docLoginPage;
            this.LoginFlyout.Name = "LoginFlyout";
            // 
            // docLoginPage
            // 
            this.docLoginPage.Caption = "Login Page";
            this.docLoginPage.ControlName = "LoginForm";
            this.docLoginPage.ControlTypeName = "EntertainmentNetworkClient.Modules.LoginForm";
            // 
            // flyoutSeatsMapGenerationForm
            // 
            this.flyoutSeatsMapGenerationForm.Document = this.docSeatsMapGenerationForm;
            this.flyoutSeatsMapGenerationForm.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OKCancel;
            this.flyoutSeatsMapGenerationForm.Name = "flyoutSeatsMapGenerationForm";
            this.flyoutSeatsMapGenerationForm.Parent = this.pageCinemaEdit;
            // 
            // docSeatsMapGenerationForm
            // 
            this.docSeatsMapGenerationForm.Caption = "Seats Map Generation";
            this.docSeatsMapGenerationForm.ControlName = "SeatsMapGenerationForm";
            this.docSeatsMapGenerationForm.ControlTypeName = "EntertainmentNetworkClient.Modules.SeatsMapGenerationForm";
            // 
            // pageCinemaEdit
            // 
            this.pageCinemaEdit.Caption = "";
            this.pageCinemaEdit.Document = this.docCinemaEdit;
            this.pageCinemaEdit.Name = "pageCinemaEdit";
            this.pageCinemaEdit.Parent = this.hubGroup;
            // 
            // docCinemaEdit
            // 
            this.docCinemaEdit.Caption = "CinemaEdit";
            this.docCinemaEdit.ControlName = "CinemaEdit";
            this.docCinemaEdit.ControlTypeName = "EntertainmentNetworkClient.Modules.CinemaEdit";
            // 
            // flyoutSchedulerAppointmentForm
            // 
            this.flyoutSchedulerAppointmentForm.Document = this.docSchedulerAppointmentForm;
            this.flyoutSchedulerAppointmentForm.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OKCancel;
            this.flyoutSchedulerAppointmentForm.Name = "flyoutSchedulerAppointmentForm";
            this.flyoutSchedulerAppointmentForm.Parent = this.hubGroup;
            // 
            // docSchedulerAppointmentForm
            // 
            this.docSchedulerAppointmentForm.Caption = "SchedulerAppointmentForm";
            this.docSchedulerAppointmentForm.ControlName = "SchedulerAppointmentForm";
            this.docSchedulerAppointmentForm.ControlTypeName = "EntertainmentNetworkClient.Modules.SchedulerAppointmentForm";
            // 
            // flyoutSchedulersSearch
            // 
            this.flyoutSchedulersSearch.Document = this.docSchedulersSearch;
            this.flyoutSchedulersSearch.FlyoutButtons = System.Windows.Forms.MessageBoxButtons.OKCancel;
            this.flyoutSchedulersSearch.Name = "flyoutSchedulersSearch";
            this.flyoutSchedulersSearch.Parent = this.hubGroup;
            // 
            // docSchedulersSearch
            // 
            this.docSchedulersSearch.Caption = "Schedulers Search";
            this.docSchedulersSearch.ControlName = "SchedulerSearch";
            this.docSchedulersSearch.ControlTypeName = "EntertainmentNetworkClient.Modules.SchedulerSearch";
            // 
            // baseModuleDocument
            // 
            this.baseModuleDocument.Caption = "BaseModule";
            this.baseModuleDocument.ControlName = "BaseModule";
            this.baseModuleDocument.ControlTypeName = "EntertainmentNetworkClient.Modules.BaseModule";
            // 
            // viewsManagerDocument
            // 
            this.viewsManagerDocument.Caption = "ViewsManager";
            this.viewsManagerDocument.ControlName = "ViewsManager";
            this.viewsManagerDocument.ControlTypeName = "EntertainmentNetworkClient.Modules.ViewsManager";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // EntertainmentNetworkMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 674);
            this.Name = "EntertainmentNetworkMainForm";
            this.Text = "EntertainmentNetwork";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hubGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCinemas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docBuyTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginFlyout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLoginPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSeatsMapGenerationForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSeatsMapGenerationForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageCinemaEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCinemaEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSchedulerAppointmentForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulerAppointmentForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutSchedulersSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchedulersSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseModuleDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewsManagerDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docCities;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TabbedGroup hubGroup;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout LoginFlyout;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docLoginPage;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docCinemas;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout flyoutSeatsMapGenerationForm;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document baseModuleDocument;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document viewsManagerDocument;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docShows;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docSchedulersSearch;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docSchedulerAppointmentForm;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout flyoutSchedulerAppointmentForm;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docBuyTickets;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docCinemaEdit;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Page pageCinemaEdit;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docSeatsMapGenerationForm;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document docSchedulers;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout flyoutSchedulersSearch;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;




    }
}

