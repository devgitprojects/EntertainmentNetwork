namespace EntertainmentNetworkClient.Modules
{
    partial class SeatsMapGenerationForm
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.labelControlSeatsCount = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditHalls = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEditColumns = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditRows = new DevExpress.XtraEditors.SpinEdit();
            this.lookUpEditFloors = new DevExpress.XtraEditors.LookUpEdit();
            this.data = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForColumns = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRows = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlHalls = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlFloors = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlSeatsCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHalls.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditColumns.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRows.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFloors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSeatsCount)).BeginInit();
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
            this.windowsUIButtonPanelMain.Location = new System.Drawing.Point(0, 98);
            this.windowsUIButtonPanelMain.Size = new System.Drawing.Size(644, 60);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.labelControlSeatsCount);
            this.dataLayoutControl1.Controls.Add(this.lookUpEditHalls);
            this.dataLayoutControl1.Controls.Add(this.spinEditColumns);
            this.dataLayoutControl1.Controls.Add(this.spinEditRows);
            this.dataLayoutControl1.Controls.Add(this.lookUpEditFloors);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(179, 296, 668, 350);
            this.dataLayoutControl1.Root = this.data;
            this.dataLayoutControl1.Size = new System.Drawing.Size(644, 98);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // labelControlSeatsCount
            // 
            this.labelControlSeatsCount.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControlSeatsCount.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlSeatsCount.Location = new System.Drawing.Point(551, 38);
            this.labelControlSeatsCount.Name = "labelControlSeatsCount";
            this.labelControlSeatsCount.Size = new System.Drawing.Size(81, 18);
            this.labelControlSeatsCount.StyleController = this.dataLayoutControl1;
            this.labelControlSeatsCount.TabIndex = 7;
            // 
            // lookUpEditHalls
            // 
            this.lookUpEditHalls.Location = new System.Drawing.Point(108, 12);
            this.lookUpEditHalls.Name = "lookUpEditHalls";
            this.lookUpEditHalls.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.lookUpEditHalls.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditHalls.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditHalls.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditHalls.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lookUpEditHalls.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditHalls.Properties.DisplayMember = "name";
            this.lookUpEditHalls.Size = new System.Drawing.Size(524, 22);
            this.lookUpEditHalls.StyleController = this.dataLayoutControl1;
            this.lookUpEditHalls.TabIndex = 6;
            // 
            // spinEditColumns
            // 
            this.spinEditColumns.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditColumns.Location = new System.Drawing.Point(345, 64);
            this.spinEditColumns.Name = "spinEditColumns";
            this.spinEditColumns.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.spinEditColumns.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditColumns.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditColumns.Properties.Appearance.Options.UseFont = true;
            this.spinEditColumns.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEditColumns.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.spinEditColumns.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spinEditColumns.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditColumns.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEditColumns.Properties.Mask.EditMask = "d";
            this.spinEditColumns.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditColumns.Properties.MaxLength = 4;
            this.spinEditColumns.Properties.NullText = "0";
            this.spinEditColumns.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            this.spinEditColumns.Size = new System.Drawing.Size(287, 22);
            this.spinEditColumns.StyleController = this.dataLayoutControl1;
            this.spinEditColumns.TabIndex = 5;
            // 
            // spinEditRows
            // 
            this.spinEditRows.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditRows.Location = new System.Drawing.Point(108, 64);
            this.spinEditRows.Name = "spinEditRows";
            this.spinEditRows.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.spinEditRows.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditRows.Properties.Appearance.Options.UseBackColor = true;
            this.spinEditRows.Properties.Appearance.Options.UseFont = true;
            this.spinEditRows.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEditRows.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.spinEditRows.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spinEditRows.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditRows.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEditRows.Properties.Mask.EditMask = "d";
            this.spinEditRows.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spinEditRows.Properties.MaxLength = 4;
            this.spinEditRows.Properties.NullText = "0";
            this.spinEditRows.Size = new System.Drawing.Size(137, 22);
            this.spinEditRows.StyleController = this.dataLayoutControl1;
            this.spinEditRows.TabIndex = 4;
            // 
            // lookUpEditFloors
            // 
            this.lookUpEditFloors.Location = new System.Drawing.Point(108, 38);
            this.lookUpEditFloors.Name = "lookUpEditFloors";
            this.lookUpEditFloors.Properties.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.lookUpEditFloors.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditFloors.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEditFloors.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditFloors.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lookUpEditFloors.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFloors.Properties.DisplayMember = "name";
            this.lookUpEditFloors.Size = new System.Drawing.Size(343, 22);
            this.lookUpEditFloors.StyleController = this.dataLayoutControl1;
            this.lookUpEditFloors.TabIndex = 6;
            // 
            // data
            // 
            this.data.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.data.GroupBordersVisible = false;
            this.data.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForColumns,
            this.ItemForRows,
            this.layoutControlHalls,
            this.layoutControlFloors,
            this.layoutControlSeatsCount});
            this.data.Location = new System.Drawing.Point(0, 0);
            this.data.Name = "Root";
            this.data.Size = new System.Drawing.Size(644, 98);
            this.data.TextVisible = false;
            // 
            // ItemForColumns
            // 
            this.ItemForColumns.Control = this.spinEditColumns;
            this.ItemForColumns.CustomizationFormText = "Max seats per row:";
            this.ItemForColumns.Location = new System.Drawing.Point(237, 52);
            this.ItemForColumns.Name = "ItemForColumns";
            this.ItemForColumns.Size = new System.Drawing.Size(387, 26);
            this.ItemForColumns.Text = "Max seats per row:";
            this.ItemForColumns.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ItemForRows
            // 
            this.ItemForRows.Control = this.spinEditRows;
            this.ItemForRows.CustomizationFormText = "Rows";
            this.ItemForRows.Location = new System.Drawing.Point(0, 52);
            this.ItemForRows.Name = "ItemForRows";
            this.ItemForRows.Size = new System.Drawing.Size(237, 26);
            this.ItemForRows.Text = "Rows";
            this.ItemForRows.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlHalls
            // 
            this.layoutControlHalls.Control = this.lookUpEditHalls;
            this.layoutControlHalls.Location = new System.Drawing.Point(0, 0);
            this.layoutControlHalls.Name = "layoutControlHalls";
            this.layoutControlHalls.Size = new System.Drawing.Size(624, 26);
            this.layoutControlHalls.Text = "Hall: ";
            this.layoutControlHalls.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlFloors
            // 
            this.layoutControlFloors.Control = this.lookUpEditFloors;
            this.layoutControlFloors.CustomizationFormText = "Hall: ";
            this.layoutControlFloors.Location = new System.Drawing.Point(0, 26);
            this.layoutControlFloors.Name = "layoutControlFloors";
            this.layoutControlFloors.Size = new System.Drawing.Size(443, 26);
            this.layoutControlFloors.Text = "Floor: ";
            this.layoutControlFloors.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlSeatsCount
            // 
            this.layoutControlSeatsCount.Control = this.labelControlSeatsCount;
            this.layoutControlSeatsCount.Location = new System.Drawing.Point(443, 26);
            this.layoutControlSeatsCount.Name = "layoutControlSeatsCount";
            this.layoutControlSeatsCount.Size = new System.Drawing.Size(181, 26);
            this.layoutControlSeatsCount.Text = "Seats Count:";
            this.layoutControlSeatsCount.TextSize = new System.Drawing.Size(93, 13);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // SeatsMapGenerationForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "SeatsMapGenerationForm";
            this.Size = new System.Drawing.Size(644, 158);
            this.Controls.SetChildIndex(this.windowsUIButtonPanelMain, 0);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditHalls.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditColumns.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRows.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFloors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlHalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSeatsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup data;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditHalls;
        private DevExpress.XtraEditors.SpinEdit spinEditColumns;
        private DevExpress.XtraEditors.SpinEdit spinEditRows;
        private DevExpress.XtraLayout.LayoutControlItem ItemForColumns;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRows;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlHalls;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFloors;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlFloors;
        private DevExpress.XtraEditors.LabelControl labelControlSeatsCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlSeatsCount;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}
