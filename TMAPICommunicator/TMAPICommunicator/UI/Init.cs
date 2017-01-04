using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetCheatX.Core.UI;
using NetCheatX.Core.Interfaces;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace TMAPICommunicator.UI
{
    public partial class Init : XForm
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private Communicator _com = null;
        private TMAPI _tmapi = null;
        private IPluginHost _host = null;

        public Init(Communicator com, TMAPI tmapi, IPluginHost host)
        {
            _com = com;
            _tmapi = tmapi;
            _host = host;

            if (_com != null)
                _com.ReadyChanged += Com_ReadyChanged;

            InitializeComponent();

            LvTM.SmallImageList = new ImageList();
            LvTM.SmallImageList.Images.Add(new Bitmap(1, 1));

            LoadSettings();

            RefreshList(true);
        }

        #region Misc Events

        private void Com_ReadyChanged(object sender, string e)
        {
            //Communicator com = (Communicator)sender;

            RefreshList();
        }

        #endregion

        #region Control Events

        private void LvTM_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            int status, wh, pad = 5;
            Rectangle region;
            if (e.Item.Tag == null || !(e.Item.Tag is int) || ((int)e.Item.Tag) < 0)
                return;

            status = (int)e.Item.Tag;
            wh = e.Bounds.Height - (pad << 1);
            region = new Rectangle(e.Bounds.X + pad, e.Bounds.Y + pad, wh, wh);

            if (status == 1)
                e.Graphics.FillRectangle(Brushes.Yellow, region);
            else if (status == 2)
                e.Graphics.FillRectangle(Brushes.Green, region);
            else if (status == 0)
                e.Graphics.FillRectangle(Brushes.Red, region);
            else
                return;

            e.Graphics.DrawRectangle(Pens.Black, region);
        }

        private void LvTM_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            LvTM_DrawItem(sender, new DrawListViewItemEventArgs(e.Graphics, e.Item, e.Bounds, e.ItemIndex, e.ItemState));
        }

        private void Init_Resize(object sender, EventArgs e)
        {
            MbOpenTM.Location = new Point((splitContainer1.Panel1.Width - MbOpenTM.Width) / 2, (splitContainer1.Panel1.Height - MbOpenTM.Height) / 2 + 10);
            MbRefresh.Location = new Point((splitContainer1.Panel1.Width - MbRefresh.Width) / 2, (splitContainer1.Panel1.Height - MbRefresh.Height) / 2 - 10);

            MbNotInstalled.Location = new Point((splitContainer1.Panel1.Width - MbNotInstalled.Width) / 2, (splitContainer1.Panel1.Height - MbNotInstalled.Height) / 2);

            LvTM.Columns[0].Width = LvTM.Width - LvTM.Margin.Horizontal;
        }

        private void MbRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void MbOpenTM_Click(object sender, EventArgs e)
        {
            OpenTM();
        }

        private void MbNotInstalled_Click(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.Start("https://www.google.com/search?q=target+manager+ps3+download") == null)
            {
                MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "We tried to direct your browser to a google search offering options to download the Target Manager API but it failed :/");
            }
        }

        #endregion

        #region Private Functions

        private void OpenTM()
        {
            string path1 = @"C:\Program Files (x86)\SN Systems\PS3\bin";
            string path2 = @"C:\Program Files\SN Systems\PS3\bin";

            string file1 = path1 + "\\ps3tm.exe";
            string file2 = path2 + "\\ps3tm.exe";

            if (_tmapi != null)
                _tmapi.InitComms();

            if (Directory.Exists(path1) && File.Exists(file1))
                Process.Start(file1);
            else if (Directory.Exists(path2) && File.Exists(file2))
                Process.Start(file2);
        }

        private void RefreshList(bool first = false)
        {
            LabelTarget.SuspendLayout();
            LabelIP.SuspendLayout();
            LabelAttached.SuspendLayout();

            LabelTarget.Text = "Target: NULL";
            LabelIP.Text = "IP/Port: 0.0.0.0:0";
            LabelAttached.Text = "Attached: False";

            LvTM.Items.Clear();
            if (_tmapi != null)
            {
                if (!_tmapi.InitComms())
                {
                    // Target Manager not installed
                    MbOpenTM.Visible = false;
                    MbRefresh.Visible = false;
                    MbNotInstalled.Visible = true;
                    LvTM.Enabled = false;

                    MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "Please download and install the Target Manager before using this Communicator.", "Looks like you don't have the Target Manager installed.");
                    goto exit;
                }


                List<string> targets = _tmapi.GetAllTargets();
                if (targets == null || targets.Count == 0)
                {
                    // Target Manager not configured
                    MbOpenTM.Visible = true;
                    MbRefresh.Visible = true;
                    MbNotInstalled.Visible = false;
                    LvTM.Enabled = false;

                    MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "Please open the Target Manager and add your PS3 as a debugging station.", "Looks like you don't have the Target Manager configured.");
                    goto exit;
                }

                // Target Manager configured
                MbOpenTM.Visible = false;
                MbRefresh.Visible = false;
                MbNotInstalled.Visible = false;
                LvTM.Enabled = true;

                int connected = _tmapi.GetConnectedTarget();
                for (int target = 0; target < targets.Count; target++)
                {
                    LvTM.Items.Add(new ListViewItem(targets[target], 0) { ToolTipText = "Status: Not Connected", Tag = 0 });
                    if (target == connected)
                    {
                        // If this is the first time calling RefreshList and AttachOnConnect
                        if (first && McAttachOnConnect.Checked)
                            if (_tmapi.AttachProcess(McContinueOnAttach.Checked))
                                _com.Ready = true;

                        LvTM.Items[target].Tag = 1;
                        LvTM.Items[target].ToolTipText = "Status: Connected, Not Attached";
                        if (_com.GetProcessState() != NetCheatX.Core.Types.ProcessState.Killed)
                        {
                            LvTM.Items[target].Tag = 2;
                            LvTM.Items[target].ToolTipText = "Status: Connected and Attached";
                        }

                        LabelTarget.Text = "Target: " + _tmapi.SCE.GetTargetName();
                        LabelIP.Text = "IP/Port: " + _tmapi.SCE.GetTargetIPPort();
                        LabelAttached.Text = "Attached: " + ((int)LvTM.Items[target].Tag == 2).ToString();

                    }
                }
            }

            
            exit: LabelTarget.ResumeLayout(true);
            LabelIP.ResumeLayout(true);
            LabelAttached.ResumeLayout(true);
        }

        #endregion

        #region Context Menu

        private void LvTM_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                connectToolStripMenuItem.Visible = false;
                attachToolStripMenuItem.Visible = false;
                reattachToolStripMenuItem.Visible = false;
                reconnectToolStripMenuItem.Visible = false;
                disconnectToolStripMenuItem.Visible = false;

                if (LvTM.SelectedIndices.Count == 1)
                {
                    if (LvTM.Items[LvTM.SelectedIndices[0]].Tag == null || !(LvTM.Items[LvTM.SelectedIndices[0]].Tag is int))
                    {

                    }
                    else {
                        switch ((int)LvTM.Items[LvTM.SelectedIndices[0]].Tag)
                        {
                            case 0: // Not Connected or Attached
                                connectToolStripMenuItem.Visible = true;
                                break;
                            case 1: // Connected, Not Attached
                                reconnectToolStripMenuItem.Visible = true;
                                disconnectToolStripMenuItem.Visible = true;
                                attachToolStripMenuItem.Visible = true;
                                break;
                            case 2: // Connected and Attached
                                reconnectToolStripMenuItem.Visible = true;
                                disconnectToolStripMenuItem.Visible = true;
                                reattachToolStripMenuItem.Visible = true;
                                break;
                        }
                    }
                }

                CmTM.Show(this, e.Location);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tmapi == null)
                return;

            if (!_tmapi.ConnectTarget(LvTM.SelectedIndices[0]))
                MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "Please ensure that both this PC and the PS3 are properly connected to the internet.", "Failed to connect to target.");
            else if (McAttachOnConnect.Checked) // Attach if AttachOnConnect
                _tmapi.AttachProcess(McContinueOnAttach.Checked);

            RefreshList();
        }

        private void attachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tmapi == null)
                return;

            if (!_tmapi.AttachProcess(McContinueOnAttach.Checked))
                MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "Are you sure your game is using a debugged EBOOT.BIN with all .self files debugged?", "Failed to attach to game process.");
            else
                _com.Ready = true;
        }

        private void reattachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attachToolStripMenuItem_Click(sender, e);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_tmapi == null)
                return;

            _tmapi.DisconnectTarget();

            LvTM.SelectedItems[0].Tag = 0;
            _com.Ready = false;
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(sender, e);
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void openTargetManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTM();
        }

        #endregion

        #region Settings

        private void LoadSettings()
        {
            string s;
            
            s = _host.PlatformProperties["TMAPICommunicator_ContinueOnAttach"];
            if (s != null && s != "")
                McContinueOnAttach.Checked = bool.Parse(s);
            else
                _host.PlatformProperties["TMAPICommunicator_ContinueOnAttach"] = McContinueOnAttach.Checked.ToString();

            s = _host.PlatformProperties["TMAPICommunicator_AttachOnConnect"];
            if (s != null && s != "")
                McAttachOnConnect.Checked = bool.Parse(s);
            else
                _host.PlatformProperties["TMAPICommunicator_AttachOnConnect"] = McAttachOnConnect.Checked.ToString();
        }

        private void McAttachOnConnect_CheckedChanged(object sender, EventArgs e)
        {
            _host.PlatformProperties["TMAPICommunicator_AttachOnConnect"] = McAttachOnConnect.Checked.ToString();
        }

        private void McContinueOnAttach_CheckedChanged(object sender, EventArgs e)
        {
            _host.PlatformProperties["TMAPICommunicator_ContinueOnAttach"] = McContinueOnAttach.Checked.ToString();
        }

        #endregion

    }
}
