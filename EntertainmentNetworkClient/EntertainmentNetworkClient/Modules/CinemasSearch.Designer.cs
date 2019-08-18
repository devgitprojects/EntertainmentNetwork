namespace EntertainmentNetworkClient.Modules
{
    partial class CinemasSearch
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
        ///
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControlCinema = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridCinemas = new DevExpress.XtraGrid.GridControl();
            this.gridCinemasView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCinId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCinName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.lookUpEditCities = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlCinema)).BeginInit();
            this.dataLayoutControlCinema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCinemas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCinemasView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCities.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanelMain
            // 
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.Location = new System.Drawing.Point(0, 540);
            this.windowsUIButtonPanelMain.Size = new System.Drawing.Size(800, 60);
            // 
            // dataLayoutControlCinema
            // 
            this.dataLayoutControlCinema.AllowCustomization = false;
            this.dataLayoutControlCinema.Controls.Add(this.gridCinemas);
            this.dataLayoutControlCinema.Controls.Add(this.lookUpEditCities);
            this.dataLayoutControlCinema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControlCinema.Location = new System.Drawing.Point(0, 30);
            this.dataLayoutControlCinema.Name = "dataLayoutControlCinema";
            this.dataLayoutControlCinema.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(798, 371, 683, 350);
            this.dataLayoutControlCinema.Root = this.layoutControlGroup1;
            this.dataLayoutControlCinema.Size = new System.Drawing.Size(800, 570);
            this.dataLayoutControlCinema.TabIndex = 0;
            // 
            // gridCinemas
            // 
            this.gridCinemas.Location = new System.Drawing.Point(12, 40);
            this.gridCinemas.MainView = this.gridCinemasView;
            this.gridCinemas.Name = "gridCinemas";
            this.gridCinemas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridCinemas.Size = new System.Drawing.Size(776, 518);
            this.gridCinemas.TabIndex = 7;
            this.gridCinemas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridCinemasView});
            // 
            // gridCinemasView
            // 
            this.gridCinemasView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridCinemasView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridCinemasView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridCinemasView.Appearance.OddRow.Options.UseBackColor = true;
            this.gridCinemasView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridCinemasView.Appearance.Row.Options.UseFont = true;
            this.gridCinemasView.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridCinemasView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridCinemasView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridCinemasView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCinId,
            this.colCinName});
            this.gridCinemasView.GridControl = this.gridCinemas;
            this.gridCinemasView.Name = "gridCinemasView";
            this.gridCinemasView.OptionsView.EnableAppearanceOddRow = true;
            this.gridCinemasView.OptionsView.ShowGroupPanel = false;
            // 
            // colCinId
            // 
            this.colCinId.Caption = "ID";
            this.colCinId.FieldName = "left";
            this.colCinId.Name = "colCinId";
            this.colCinId.OptionsColumn.AllowEdit = false;
            this.colCinId.Visible = true;
            this.colCinId.VisibleIndex = 0;
            this.colCinId.Width = 128;
            // 
            // colCinName
            // 
            this.colCinName.Caption = "Name";
            this.colCinName.FieldName = "middle";
            this.colCinName.Name = "colCinName";
            this.colCinName.OptionsColumn.AllowEdit = false;
            this.colCinName.Visible = true;
            this.colCinName.VisibleIndex = 1;
            this.colCinName.Width = 307;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // lookUpEditCities
            // 
            this.lookUpEditCities.Location = new System.Drawing.Point(12, 9);
            this.lookUpEditCities.Name = "lookUpEditCities";
            this.lookUpEditCities.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lookUpEditCities.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCities.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditCities.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCities.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCities.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpEditCities.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lookUpEditCities.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCities.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "City Id", 49, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Name", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("citCountry", "Country", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lookUpEditCities.Properties.DisplayMember = "name";
            this.lookUpEditCities.Properties.NullText = "Please select city";
            this.lookUpEditCities.Size = new System.Drawing.Size(772, 24);
            this.lookUpEditCities.StyleController = this.dataLayoutControlCinema;
            this.lookUpEditCities.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 570);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // labelControl
            // 
            this.labelControl.AllowHtmlString = true;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl.Location = new System.Drawing.Point(0, 0);
            this.labelControl.Name = "labelControl";
            this.labelControl.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.labelControl.Size = new System.Drawing.Size(800, 30);
            this.labelControl.TabIndex = 1;
            this.labelControl.Text = "Cinemas";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // CinemasSearch
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayoutControlCinema);
            this.Controls.Add(this.labelControl);
            this.Name = "CinemasSearch";
            this.Size = new System.Drawing.Size(800, 600);
            this.Controls.SetChildIndex(this.labelControl, 0);
            this.Controls.SetChildIndex(this.dataLayoutControlCinema, 0);
            this.Controls.SetChildIndex(this.windowsUIButtonPanelMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlCinema)).EndInit();
            this.dataLayoutControlCinema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCinemas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCinemasView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCities.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControlCinema;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCities;
        private DevExpress.XtraGrid.GridControl gridCinemas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridCinemasView;
        private DevExpress.XtraGrid.Columns.GridColumn colCinId;
        private DevExpress.XtraGrid.Columns.GridColumn colCinName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}
