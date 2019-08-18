using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Modules;
using DevExpress.Utils.MVVM.Services;
using DevExpress.Utils.MVVM;

namespace EntertainmentNetworkClient
{
    public partial class EntertainmentNetworkMainForm : Form
    {
        public EntertainmentNetworkMainForm()
        {
            InitializeComponent();
            MVVMContext.RegisterFlyoutDialogService();
            LoginFlyout.Action = CreateLoginAction();
            // closeFlyout.Action = CreateCloseAction();
            windowsUIView1.FlyoutHidden += windowsUIView_FlyoutHidden;
            windowsUIView1.QueryStartupContentContainer += windowsUIView_QueryStartupContentContainer;
            windowsUIView1.NavigationBarsShowing += windowsUIView_NavigationBarsShowing;
            windowsUIView1.NavigatedTo += windowsUIView_NavigatedTo;
            windowsUIView1.NavigatedFrom += windowsUIView_NavigatedFrom;
            windowsUIView1.QueryControl += windowsUIView_QueryControl;
            // Handling the QueryControl event that will populate all automatically generated Documents
        }

        FlyoutAction CreateLoginAction()
        {
            FlyoutAction loginAction = new FlyoutAction();
            loginAction.Caption = Text + " LOGIN";
            loginAction.Commands.Add(FlyoutCommand.OK);
            return loginAction;
        }

        void windowsUIView_FlyoutHidden(object sender, FlyoutResultEventArgs e)
        {
            if (windowsUIView1.ActiveFlyoutContainer == LoginFlyout)
                windowsUIView1.ActivateContainer(hubGroup);
        }

        void windowsUIView_QueryStartupContentContainer(object sender, QueryContentContainerEventArgs e)
        {
            hubGroup.Caption = UserName;
            e.ContentContainer = hubGroup;
        }
        void windowsUIView_QueryControl(object sender, QueryControlEventArgs e)
        {
            Type moduleType = typeof(EntertainmentNetworkMainForm).Assembly.GetType(e.Document.ControlTypeName);
            BaseModule module = Activator.CreateInstance(moduleType) as BaseModule;
            module.Initialize();
            e.Control = module;
        }
        void windowsUIView_NavigationBarsShowing(object sender, NavigationBarsCancelEventArgs e)
        {
            e.Cancel = (e.ContentContainer == hubGroup);
        }

        void windowsUIView_NavigatedTo(object sender, NavigationEventArgs e)
        {
            if (e.Target == LoginFlyout)
                e.Parameter = UserName;
        }
        void windowsUIView_NavigatedFrom(object sender, NavigationEventArgs e)
        {
            if (e.Source == LoginFlyout && LoginFlyout.LastResult == System.Windows.Forms.DialogResult.OK)
            {
                UserName = e.Parameter as string;
                hubGroup.Caption = UserName;
            }
        }

        Brush borderBrush = new SolidBrush(Color.FromArgb(0xa6, 0xa6, 0xa6));
        Brush borderHotBrush = new SolidBrush(Color.FromArgb(126, 180, 234));
        string UserName = "John Smith";
    }
}
