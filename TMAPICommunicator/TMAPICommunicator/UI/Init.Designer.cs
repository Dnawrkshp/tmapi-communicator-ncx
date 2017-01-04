namespace TMAPICommunicator.UI
{
    partial class Init
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.LvTM = new MetroFramework.Controls.MetroListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmTM = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reattachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTargetManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MbOpenTM = new MetroFramework.Controls.MetroButton();
            this.MbRefresh = new MetroFramework.Controls.MetroButton();
            this.MbNotInstalled = new MetroFramework.Controls.MetroButton();
            this.MToolTip = new MetroFramework.Components.MetroToolTip();
            this.McAttachOnConnect = new MetroFramework.Controls.MetroCheckBox();
            this.McContinueOnAttach = new MetroFramework.Controls.MetroCheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.LabelAttached = new MetroFramework.Controls.MetroLabel();
            this.LabelIP = new MetroFramework.Controls.MetroLabel();
            this.LabelTarget = new MetroFramework.Controls.MetroLabel();
            this.LabelStatus = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.LabelSetting = new MetroFramework.Controls.MetroLabel();
            this.CmTM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvTM
            // 
            this.LvTM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
            this.LvTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvTM.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LvTM.FullRowSelect = true;
            this.LvTM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LvTM.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.LvTM.LabelWrap = false;
            this.LvTM.Location = new System.Drawing.Point(0, 0);
            this.LvTM.MultiSelect = false;
            this.LvTM.Name = "LvTM";
            this.LvTM.OwnerDraw = true;
            this.LvTM.ShowItemToolTips = true;
            this.LvTM.Size = new System.Drawing.Size(655, 200);
            this.LvTM.TabIndex = 0;
            this.LvTM.TabStop = false;
            this.LvTM.UseCompatibleStateImageBehavior = false;
            this.LvTM.UseSelectable = true;
            this.LvTM.View = System.Windows.Forms.View.Details;
            this.LvTM.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.LvTM_DrawItem);
            this.LvTM.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.LvTM_DrawSubItem);
            this.LvTM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LvTM_MouseDown);
            // 
            // columnName
            // 
            this.columnName.Text = "Target";
            this.columnName.Width = 100;
            // 
            // CmTM
            // 
            this.CmTM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.reconnectToolStripMenuItem,
            this.reattachToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.attachToolStripMenuItem,
            this.refreshListToolStripMenuItem,
            this.openTargetManagerToolStripMenuItem});
            this.CmTM.Name = "CmTM";
            this.CmTM.Size = new System.Drawing.Size(190, 180);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.ToolTipText = "Connects to selected target.";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // reattachToolStripMenuItem
            // 
            this.reattachToolStripMenuItem.Name = "reattachToolStripMenuItem";
            this.reattachToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.reattachToolStripMenuItem.Text = "Reattach";
            this.reattachToolStripMenuItem.Click += new System.EventHandler(this.reattachToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // attachToolStripMenuItem
            // 
            this.attachToolStripMenuItem.Name = "attachToolStripMenuItem";
            this.attachToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.attachToolStripMenuItem.Text = "Attach";
            this.attachToolStripMenuItem.ToolTipText = "Attaches to the selected target\'s game.";
            this.attachToolStripMenuItem.Click += new System.EventHandler(this.attachToolStripMenuItem_Click);
            // 
            // refreshListToolStripMenuItem
            // 
            this.refreshListToolStripMenuItem.Name = "refreshListToolStripMenuItem";
            this.refreshListToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.refreshListToolStripMenuItem.Text = "Refresh Targets List";
            this.refreshListToolStripMenuItem.ToolTipText = "Refreshes list of targets.";
            this.refreshListToolStripMenuItem.Click += new System.EventHandler(this.refreshListToolStripMenuItem_Click);
            // 
            // openTargetManagerToolStripMenuItem
            // 
            this.openTargetManagerToolStripMenuItem.Name = "openTargetManagerToolStripMenuItem";
            this.openTargetManagerToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.openTargetManagerToolStripMenuItem.Text = "Open Target Manager";
            this.openTargetManagerToolStripMenuItem.ToolTipText = "Opens the Target Manager GUI.";
            this.openTargetManagerToolStripMenuItem.Click += new System.EventHandler(this.openTargetManagerToolStripMenuItem_Click);
            // 
            // MbOpenTM
            // 
            this.MbOpenTM.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.MbOpenTM.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.MbOpenTM.Location = new System.Drawing.Point(243, 77);
            this.MbOpenTM.Name = "MbOpenTM";
            this.MbOpenTM.Size = new System.Drawing.Size(149, 23);
            this.MbOpenTM.TabIndex = 2;
            this.MbOpenTM.TabStop = false;
            this.MbOpenTM.Text = "Open Target Manager";
            this.MToolTip.SetToolTip(this.MbOpenTM, "Opens the Target Manager GUI.");
            this.MbOpenTM.UseSelectable = true;
            this.MbOpenTM.Visible = false;
            this.MbOpenTM.Click += new System.EventHandler(this.MbOpenTM_Click);
            // 
            // MbRefresh
            // 
            this.MbRefresh.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.MbRefresh.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.MbRefresh.Location = new System.Drawing.Point(243, 48);
            this.MbRefresh.Name = "MbRefresh";
            this.MbRefresh.Size = new System.Drawing.Size(149, 23);
            this.MbRefresh.TabIndex = 3;
            this.MbRefresh.TabStop = false;
            this.MbRefresh.Text = "Refresh List";
            this.MToolTip.SetToolTip(this.MbRefresh, "Refreshes list of targets.");
            this.MbRefresh.UseSelectable = true;
            this.MbRefresh.Visible = false;
            this.MbRefresh.Click += new System.EventHandler(this.MbRefresh_Click);
            // 
            // MbNotInstalled
            // 
            this.MbNotInstalled.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.MbNotInstalled.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.MbNotInstalled.Location = new System.Drawing.Point(223, 106);
            this.MbNotInstalled.Name = "MbNotInstalled";
            this.MbNotInstalled.Size = new System.Drawing.Size(198, 23);
            this.MbNotInstalled.TabIndex = 4;
            this.MbNotInstalled.TabStop = false;
            this.MbNotInstalled.Text = "Open Browser to Google Search";
            this.MToolTip.SetToolTip(this.MbNotInstalled, "Opens the default browser to\r\n\"https://www.google.com/search?q=target+manager+ps3" +
        "+download\"");
            this.MbNotInstalled.UseSelectable = true;
            this.MbNotInstalled.Click += new System.EventHandler(this.MbNotInstalled_Click);
            // 
            // MToolTip
            // 
            this.MToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.MToolTip.StyleManager = null;
            this.MToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // McAttachOnConnect
            // 
            this.McAttachOnConnect.AutoSize = true;
            this.McAttachOnConnect.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.McAttachOnConnect.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.McAttachOnConnect.Location = new System.Drawing.Point(27, 31);
            this.McAttachOnConnect.Name = "McAttachOnConnect";
            this.McAttachOnConnect.Size = new System.Drawing.Size(133, 19);
            this.McAttachOnConnect.TabIndex = 4;
            this.McAttachOnConnect.Text = "Attach on Connect";
            this.MToolTip.SetToolTip(this.McAttachOnConnect, "TMAPI will automatically attempt to\r\nattach to the game process after a\r\nsuccessf" +
        "ul connect.");
            this.McAttachOnConnect.UseSelectable = true;
            this.McAttachOnConnect.CheckedChanged += new System.EventHandler(this.McAttachOnConnect_CheckedChanged);
            // 
            // McContinueOnAttach
            // 
            this.McContinueOnAttach.AutoSize = true;
            this.McContinueOnAttach.Checked = true;
            this.McContinueOnAttach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.McContinueOnAttach.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.McContinueOnAttach.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.McContinueOnAttach.Location = new System.Drawing.Point(27, 56);
            this.McContinueOnAttach.Name = "McContinueOnAttach";
            this.McContinueOnAttach.Size = new System.Drawing.Size(140, 19);
            this.McContinueOnAttach.TabIndex = 5;
            this.McContinueOnAttach.Text = "Continue On Attach";
            this.MToolTip.SetToolTip(this.McContinueOnAttach, "TMAPI will automatically attempt to\r\nresume the game process after a\r\nsuccessful " +
        "attach.");
            this.McContinueOnAttach.UseSelectable = true;
            this.McContinueOnAttach.CheckedChanged += new System.EventHandler(this.McContinueOnAttach_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MbNotInstalled);
            this.splitContainer1.Panel1.Controls.Add(this.MbRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.MbOpenTM);
            this.splitContainer1.Panel1.Controls.Add(this.LvTM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(655, 515);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.metroPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.metroPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(655, 314);
            this.splitContainer2.SplitterDistance = 96;
            this.splitContainer2.TabIndex = 1;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.LabelAttached);
            this.metroPanel2.Controls.Add(this.LabelIP);
            this.metroPanel2.Controls.Add(this.LabelTarget);
            this.metroPanel2.Controls.Add(this.LabelStatus);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(655, 96);
            this.metroPanel2.TabIndex = 0;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // LabelAttached
            // 
            this.LabelAttached.AutoSize = true;
            this.LabelAttached.Location = new System.Drawing.Point(12, 66);
            this.LabelAttached.Name = "LabelAttached";
            this.LabelAttached.Size = new System.Drawing.Size(92, 19);
            this.LabelAttached.TabIndex = 7;
            this.LabelAttached.Text = "Attached: True";
            // 
            // LabelIP
            // 
            this.LabelIP.AutoSize = true;
            this.LabelIP.Location = new System.Drawing.Point(24, 47);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.Size = new System.Drawing.Size(166, 19);
            this.LabelIP.TabIndex = 6;
            this.LabelIP.Text = "IP/Port: 192.168.137.97:1000";
            // 
            // LabelTarget
            // 
            this.LabelTarget.AutoSize = true;
            this.LabelTarget.Location = new System.Drawing.Point(28, 28);
            this.LabelTarget.Name = "LabelTarget";
            this.LabelTarget.Size = new System.Drawing.Size(132, 19);
            this.LabelTarget.TabIndex = 5;
            this.LabelTarget.Text = "Target: 192.168.137.97";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(12, 9);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(43, 19);
            this.LabelStatus.TabIndex = 4;
            this.LabelStatus.Text = "Status";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.McContinueOnAttach);
            this.metroPanel1.Controls.Add(this.McAttachOnConnect);
            this.metroPanel1.Controls.Add(this.LabelSetting);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(655, 214);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // LabelSetting
            // 
            this.LabelSetting.AutoSize = true;
            this.LabelSetting.Location = new System.Drawing.Point(12, 9);
            this.LabelSetting.Name = "LabelSetting";
            this.LabelSetting.Size = new System.Drawing.Size(54, 19);
            this.LabelSetting.TabIndex = 3;
            this.LabelSetting.Text = "Settings";
            // 
            // Init
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 515);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Init";
            this.Text = "Target Manager View";
            this.Resize += new System.EventHandler(this.Init_Resize);
            this.CmTM.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView LvTM;
        private MetroFramework.Controls.MetroContextMenu CmTM;
        private MetroFramework.Controls.MetroButton MbOpenTM;
        private MetroFramework.Controls.MetroButton MbRefresh;
        private MetroFramework.Controls.MetroButton MbNotInstalled;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTargetManagerToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnName;
        private MetroFramework.Components.MetroToolTip MToolTip;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reattachToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel LabelSetting;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel LabelIP;
        private MetroFramework.Controls.MetroLabel LabelTarget;
        private MetroFramework.Controls.MetroLabel LabelStatus;
        private MetroFramework.Controls.MetroLabel LabelAttached;
        private MetroFramework.Controls.MetroCheckBox McContinueOnAttach;
        private MetroFramework.Controls.MetroCheckBox McAttachOnConnect;
    }
}