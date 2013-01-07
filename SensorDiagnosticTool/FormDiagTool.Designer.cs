// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace SensorDiagnosticTool
{
    partial class FormDiagTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiagTool));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonEvents = new System.Windows.Forms.ToolStripDropDownButton();
            this.showEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonSensors = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableSensorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.dataGridViewProperties = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEvents = new System.Windows.Forms.GroupBox();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.treeViewSensors = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProperties)).BeginInit();
            this.groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBoxEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonFile,
            this.toolStripDropDownButtonEvents,
            this.toolStripDropDownButtonSensors});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(760, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonFile
            // 
            this.toolStripDropDownButtonFile.AutoToolTip = false;
            this.toolStripDropDownButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripDropDownButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonFile.Image")));
            this.toolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFile.Name = "toolStripDropDownButtonFile";
            this.toolStripDropDownButtonFile.ShowDropDownArrow = false;
            this.toolStripDropDownButtonFile.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonFile.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonEvents
            // 
            this.toolStripDropDownButtonEvents.AutoToolTip = false;
            this.toolStripDropDownButtonEvents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonEvents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEventsToolStripMenuItem,
            this.logEventsToolStripMenuItem});
            this.toolStripDropDownButtonEvents.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonEvents.Image")));
            this.toolStripDropDownButtonEvents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonEvents.Name = "toolStripDropDownButtonEvents";
            this.toolStripDropDownButtonEvents.ShowDropDownArrow = false;
            this.toolStripDropDownButtonEvents.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButtonEvents.Text = "Events";
            // 
            // showEventsToolStripMenuItem
            // 
            this.showEventsToolStripMenuItem.Checked = true;
            this.showEventsToolStripMenuItem.CheckOnClick = true;
            this.showEventsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEventsToolStripMenuItem.Name = "showEventsToolStripMenuItem";
            this.showEventsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.showEventsToolStripMenuItem.Text = "Show Events";
            // 
            // logEventsToolStripMenuItem
            // 
            this.logEventsToolStripMenuItem.Name = "logEventsToolStripMenuItem";
            this.logEventsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.logEventsToolStripMenuItem.Text = "Log Events...";
            this.logEventsToolStripMenuItem.Click += new System.EventHandler(this.logEventsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonSensors
            // 
            this.toolStripDropDownButtonSensors.AutoToolTip = false;
            this.toolStripDropDownButtonSensors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonSensors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.enableSensorsToolStripMenuItem,
            this.launchControlPanelToolStripMenuItem});
            this.toolStripDropDownButtonSensors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSensors.Image")));
            this.toolStripDropDownButtonSensors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSensors.Name = "toolStripDropDownButtonSensors";
            this.toolStripDropDownButtonSensors.ShowDropDownArrow = false;
            this.toolStripDropDownButtonSensors.Size = new System.Drawing.Size(51, 22);
            this.toolStripDropDownButtonSensors.Text = "Sensors";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // enableSensorsToolStripMenuItem
            // 
            this.enableSensorsToolStripMenuItem.Name = "enableSensorsToolStripMenuItem";
            this.enableSensorsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.enableSensorsToolStripMenuItem.Text = "Enable Sensors...";
            this.enableSensorsToolStripMenuItem.Click += new System.EventHandler(this.enableSensorsToolStripMenuItem_Click);
            // 
            // launchControlPanelToolStripMenuItem
            // 
            this.launchControlPanelToolStripMenuItem.Name = "launchControlPanelToolStripMenuItem";
            this.launchControlPanelToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.launchControlPanelToolStripMenuItem.Text = "Launch Control Panel...";
            this.launchControlPanelToolStripMenuItem.Click += new System.EventHandler(this.launchControlPanelToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(183, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxEvents);
            this.splitContainer2.Size = new System.Drawing.Size(577, 420);
            this.splitContainer2.SplitterDistance = 298;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBoxProperties);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxData);
            this.splitContainer3.Size = new System.Drawing.Size(577, 298);
            this.splitContainer3.SplitterDistance = 175;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Controls.Add(this.dataGridViewProperties);
            this.groupBoxProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 0);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(577, 175);
            this.groupBoxProperties.TabIndex = 1;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // dataGridViewProperties
            // 
            this.dataGridViewProperties.AllowUserToAddRows = false;
            this.dataGridViewProperties.AllowUserToDeleteRows = false;
            this.dataGridViewProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProperties.ColumnHeadersVisible = false;
            this.dataGridViewProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            this.dataGridViewProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProperties.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewProperties.Name = "dataGridViewProperties";
            this.dataGridViewProperties.ReadOnly = true;
            this.dataGridViewProperties.RowHeadersVisible = false;
            this.dataGridViewProperties.Size = new System.Drawing.Size(571, 156);
            this.dataGridViewProperties.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.ReadOnly = true;
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.dataGridViewData);
            this.groupBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxData.Location = new System.Drawing.Point(0, 0);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(577, 119);
            this.groupBoxData.TabIndex = 1;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Data";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.ColumnHeadersVisible = false;
            this.dataGridViewData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewData.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.RowHeadersVisible = false;
            this.dataGridViewData.Size = new System.Drawing.Size(571, 100);
            this.dataGridViewData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // groupBoxEvents
            // 
            this.groupBoxEvents.Controls.Add(this.textBoxEvents);
            this.groupBoxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEvents.Location = new System.Drawing.Point(0, 0);
            this.groupBoxEvents.Name = "groupBoxEvents";
            this.groupBoxEvents.Size = new System.Drawing.Size(577, 118);
            this.groupBoxEvents.TabIndex = 1;
            this.groupBoxEvents.TabStop = false;
            this.groupBoxEvents.Text = "Events";
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEvents.Location = new System.Drawing.Point(3, 16);
            this.textBoxEvents.MaxLength = 2000;
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.ReadOnly = true;
            this.textBoxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEvents.Size = new System.Drawing.Size(571, 99);
            this.textBoxEvents.TabIndex = 0;
            // 
            // treeViewSensors
            // 
            this.treeViewSensors.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewSensors.Location = new System.Drawing.Point(0, 25);
            this.treeViewSensors.Name = "treeViewSensors";
            this.treeViewSensors.Size = new System.Drawing.Size(183, 420);
            this.treeViewSensors.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(183, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 420);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // FormDiagTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 445);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.treeViewSensors);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDiagTool";
            this.Text = "Sensor Diagnostic Tool 0.2.1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProperties)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBoxEvents.ResumeLayout(false);
            this.groupBoxEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonEvents;
        private System.Windows.Forms.ToolStripMenuItem logEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSensors;
        private System.Windows.Forms.ToolStripMenuItem enableSensorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchControlPanelToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBoxEvents;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.DataGridView dataGridViewProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.TreeView treeViewSensors;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEventsToolStripMenuItem;
    }
}

