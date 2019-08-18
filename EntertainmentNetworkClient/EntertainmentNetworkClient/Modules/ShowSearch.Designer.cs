namespace EntertainmentNetworkClient.Modules
{
    partial class ShowSearch
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
            this.dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            this.gridShows = new DevExpress.XtraGrid.GridControl();
            this.gridViewShows = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutGridCities = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlCinema)).BeginInit();
            this.dataLayoutControlCinema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndDate)).BeginInit();
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
            this.dataLayoutControlCinema.Controls.Add(this.dateEditEndDate);
            this.dataLayoutControlCinema.Controls.Add(this.dateEditStartDate);
            this.dataLayoutControlCinema.Controls.Add(this.gridShows);
            this.dataLayoutControlCinema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControlCinema.Location = new System.Drawing.Point(0, 30);
            this.dataLayoutControlCinema.Name = "dataLayoutControlCinema";
            this.dataLayoutControlCinema.Root = this.layoutControlGroup1;
            this.dataLayoutControlCinema.Size = new System.Drawing.Size(800, 510);
            this.dataLayoutControlCinema.TabIndex = 0;
            // 
            // dateEditEndDate
            // 
            this.dateEditEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditEndDate.EditValue = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateEditEndDate.Location = new System.Drawing.Point(404, 12);
            this.dateEditEndDate.Name = "dateEditEndDate";
            this.dateEditEndDate.Properties.AccessibleName = "End date";
            this.dateEditEndDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditEndDate.Properties.Appearance.Options.UseFont = true;
            this.dateEditEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEditEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.dateEditEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditEndDate.Size = new System.Drawing.Size(384, 22);
            this.dateEditEndDate.StyleController = this.dataLayoutControlCinema;
            this.dateEditEndDate.TabIndex = 25;
            // 
            // dateEditStartDate
            // 
            this.dateEditStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEditStartDate.EditValue = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateEditStartDate.Location = new System.Drawing.Point(46, 12);
            this.dateEditStartDate.Name = "dateEditStartDate";
            this.dateEditStartDate.Properties.AccessibleName = "End date";
            this.dateEditStartDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditStartDate.Properties.Appearance.Options.UseFont = true;
            this.dateEditStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEditStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            this.dateEditStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditStartDate.Size = new System.Drawing.Size(320, 22);
            this.dateEditStartDate.StyleController = this.dataLayoutControlCinema;
            this.dateEditStartDate.TabIndex = 28;
            // 
            // gridShows
            // 
            this.gridShows.Location = new System.Drawing.Point(12, 38);
            this.gridShows.MainView = this.gridViewShows;
            this.gridShows.Name = "gridShows";
            this.gridShows.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridShows.Size = new System.Drawing.Size(776, 460);
            this.gridShows.TabIndex = 4;
            this.gridShows.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewShows});
            // 
            // gridViewShows
            // 
            this.gridViewShows.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gridViewShows.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewShows.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridViewShows.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewShows.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewShows.Appearance.Row.Options.UseFont = true;
            this.gridViewShows.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridViewShows.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewShows.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewShows.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnName});
            this.gridViewShows.GridControl = this.gridShows;
            this.gridViewShows.Name = "gridViewShows";
            this.gridViewShows.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewShows.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "left";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.OptionsColumn.AllowEdit = false;
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            this.gridColumnID.Width = 128;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "right";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 307;
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemStartDate,
            this.layoutGridCities,
            this.layoutControlItemEndDate});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 510);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItemStartDate
            // 
            this.layoutControlItemStartDate.Control = this.dateEditStartDate;
            this.layoutControlItemStartDate.CustomizationFormText = "Start: ";
            this.layoutControlItemStartDate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemStartDate.Name = "layoutControlItemStartDate";
            this.layoutControlItemStartDate.Size = new System.Drawing.Size(358, 26);
            this.layoutControlItemStartDate.Text = "Start: ";
            this.layoutControlItemStartDate.TextSize = new System.Drawing.Size(31, 13);
            // 
            // layoutGridCities
            // 
            this.layoutGridCities.Control = this.gridShows;
            this.layoutGridCities.CustomizationFormText = "layoutGridCities";
            this.layoutGridCities.Location = new System.Drawing.Point(0, 26);
            this.layoutGridCities.Name = "layoutGridCities";
            this.layoutGridCities.Size = new System.Drawing.Size(780, 464);
            this.layoutGridCities.TextSize = new System.Drawing.Size(0, 0);
            this.layoutGridCities.TextVisible = false;
            // 
            // layoutControlItemEndDate
            // 
            this.layoutControlItemEndDate.Control = this.dateEditEndDate;
            this.layoutControlItemEndDate.CustomizationFormText = "End: ";
            this.layoutControlItemEndDate.Location = new System.Drawing.Point(358, 0);
            this.layoutControlItemEndDate.Name = "layoutControlItemEndDate";
            this.layoutControlItemEndDate.Size = new System.Drawing.Size(422, 26);
            this.layoutControlItemEndDate.Text = "End: ";
            this.layoutControlItemEndDate.TextSize = new System.Drawing.Size(31, 13);
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
            this.labelControl.Text = "Shows";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // ShowSearch
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayoutControlCinema);
            this.Controls.Add(this.labelControl);
            this.Name = "ShowSearch";
            this.Size = new System.Drawing.Size(800, 600);
            this.Controls.SetChildIndex(this.windowsUIButtonPanelMain, 0);
            this.Controls.SetChildIndex(this.labelControl, 0);
            this.Controls.SetChildIndex(this.dataLayoutControlCinema, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlCinema)).EndInit();
            this.dataLayoutControlCinema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewShows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControlCinema;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemEndDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemStartDate;
        private DevExpress.XtraGrid.GridControl gridShows;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewShows;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutGridCities;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}
