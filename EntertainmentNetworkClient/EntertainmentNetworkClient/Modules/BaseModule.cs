using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetworkClient.Properties;

namespace EntertainmentNetworkClient.Modules
{
    public partial class BaseModule : DevExpress.XtraEditors.XtraUserControl
    {
        public BaseModule()
        {
            InitializeComponent();
        }

        public virtual void Initialize()
        {
        }
        
        protected WindowsUIButton buttonRefresh = new WindowsUIButton(Resources.ButtonRefresh, null, "Reset;Size32x32;GrayScaled");
        protected WindowsUIButton buttonSave = new WindowsUIButton(Resources.ButtonSave, null, "Save;Size32x32;GrayScaled");
        protected WindowsUIButton buttonDelete = new WindowsUIButton(Resources.ButtonDelete, null, "Edit/Delete;Size32x32;GrayScaled");
    }  
}
