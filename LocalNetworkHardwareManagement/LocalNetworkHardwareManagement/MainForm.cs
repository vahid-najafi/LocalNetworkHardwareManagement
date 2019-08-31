using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkHardware.DataLayer;
using LocalNetworkHardware.DataLayer.Context;
using LocalNetworkHardwareManagement.Core.Buisness;
using LocalNetworkHardwareManagement.Core.Helpers;
using LocalNetworkHardwareManagement.Core.Models;
using LocalNetworkHardwareManagement.Core.Socket_Classes;
using LocalNetworkHardwareManagement.Core.Test;

namespace LocalNetworkHardwareManagement
{
    public partial class MainForm : Form
    {

        private bool _formDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        private IPAddress _serverIP;
        private CancellationTokenSource _tokenSource;

        public MainForm()
        {
            _tokenSource = null;
            InitializeComponent();
        }

        #region Form Move

        private void AreaMouseDown()
        {
            _formDragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void AreaMouseMove()
        {
            if (_formDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void AreaMouseUp() => _formDragging = false;


        /// <summary>
        /// Title Panel Moving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            AreaMouseDown();
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            AreaMouseMove();
        }

        private void TitlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            AreaMouseUp();
        }

        /// <summary>
        /// Title Label Moving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            AreaMouseDown();
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            AreaMouseMove();
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            AreaMouseUp();
        }


        #endregion

        #region Exit

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Cursor = Cursors.Hand;
            ExitButton.ForeColor = ColorTranslator.FromHtml("#C0392B");
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Cursor = Cursors.Default;
            ExitButton.ForeColor = Color.White;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.ShowBalloonTip(1000, "مدیریت سخت افزاری شبکه",
                "برنامه در حال اجرا می باشد.", ToolTipIcon.Info);
        }

        private void FullExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Menu Icon


        private void MenuIcon_MouseEnter(object sender, EventArgs e)
        {
            menuIcon.BackgroundImage = Properties.Resources.line_menu_red;
            this.Cursor = Cursors.Hand;
        }

        private void MenuIcon_MouseLeave(object sender, EventArgs e)
        {
            menuIcon.BackgroundImage = Properties.Resources.line_menu_white;
            this.Cursor = Cursors.Default;
        }

        private void MenuIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mainMenu.Show(this.PointToScreen(e.Location));
            }
        }

        #endregion

        #region Other

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ActivitiesText.Text = "";
        }

        #endregion

        #region Form Load

        private async void MainForm_Load(object sender, EventArgs e)
        {
            ProgramStartupHelper.CheckApplicationStartupRegistry(Application.ExecutablePath);

            //checking global system information in startup
            using (UnitOfWork uof = new UnitOfWork())
            {
                ManageSystemInformations manageSystem = new ManageSystemInformations(uof, true);
                ActivitiesText.Text = (await manageSystem.UpdateOwnedSystem())
                    .Replace("<newLine>", Environment.NewLine) + Environment.NewLine + ActivitiesText.Text;
            }

            //Getting system ips
            LoadLocalIPs();

            //Starting server to communicate with other nodes
            //if (!string.IsNullOrEmpty(Properties.Settings.Default.LocalNetworkIP))
            //{
            //    ServerStartButton_Click(ServerStartButton, EventArgs.Empty);
            //}
        }

        /// <summary>
        /// Checking Connected Nodes On Network
        /// </summary>
        private void LoadLocalIPs()
        {
            LocalIPsCombo.Items.Clear();
            var localIps = IpAddressManagement.GetLocalIPv4Addresses().ToArray();
            LocalIPsCombo.Items.AddRange(localIps);
            LocalIPsCombo.SelectedIndex = 0;
        }


        #endregion

        private async void ServerStartButton_Click(object sender, EventArgs e)
        {
            if (ServerStartButton.Text == "استارت سرور")
            {
                if (string.IsNullOrEmpty(LocalIPsCombo.Text))
                {
                    MessageBox.Show("لطفا آیپی خود را انتخاب کنید.", "توجه",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (IPAddress.TryParse(LocalIPsCombo.Text, out IPAddress ip))
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            //Saving Default IP Address
                            Properties.Settings.Default.LocalNetworkIP = LocalIPsCombo.Text;
                            Properties.Settings.Default.Save();

                            //Starting Server
                            Task.Run(() =>
                            {
                                AsynchronousSocketListener.StartListening();
                            });
                            _serverIP = ip;
                            ActivitiesText.Text = "سرور استارت شد." + Environment.NewLine + ActivitiesText.Text;

                            //Getting Connected Nodes
                            await ShowConnectedNodes(ip.ToString());

                            ConnectedIPsTimer.Start();
                            ServerStartButton.Text = "توقف سرور";
                            ServerStartButton.BackColor = Color.Firebrick;

                        }
                    }
                    else
                    {
                        ActivitiesText.Text = "آیپی وارد شده معتبر می باشد." + Environment.NewLine + ActivitiesText.Text;
                    }
                }
                catch //(Exception exception)
                {
                    ActivitiesText.Text = "متاسفانه عملیات استارت سرور با شکست مواجه شد." + Environment.NewLine + ActivitiesText.Text;
                }
            }
            else
            {
                /*
                 * This Code Will Restart Application To Prevent Slowing Application If User Tries To Spam Servers
                 */
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.FileName = "cmd.exe";
                Process.Start(Info);
                Application.Exit();
            }
        }

        private async Task ShowConnectedNodes(string ipAddress)
        {
            IpAddressManagement ipManagement = new IpAddressManagement();
            NodesList.Items.AddRange(await ipManagement.StartGettingHosts(ipAddress));
        }

        private void showNodesButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm(LocalIPsCombo.Text);
            manageForm.Show();
        }

        private void BtnShowSystemInfo_Click(object sender, EventArgs e)
        {
            //Helper
            //DatabaseTest newForm = new DatabaseTest();
            //newForm.Show();

            PcInfoForm infoForm = new PcInfoForm(LocalIPsCombo.Text, true);
            infoForm.ShowDialog();
        }

        private async void ConnectedIPsTimer_Tick(object sender, EventArgs e)
        {
            await ShowConnectedNodes(_serverIP.ToString());
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        #region Menu Events

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgrammer aboutForm = new AboutProgrammer();
            aboutForm.ShowDialog();
        }

        private void ShowNodesMenuItem_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm(LocalIPsCombo.Text);
            manageForm.Show();
        }

        private void ShowSystemInfoMenuItem_Click(object sender, EventArgs e)
        {
            PcInfoForm infoForm = new PcInfoForm(LocalIPsCombo.Text, true);
            infoForm.ShowDialog();
        }

        #endregion

        #region NotifyIcon Menu Events

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void About2MenuItem_Click(object sender, EventArgs e)
        {
            AboutMenuItem_Click(about2MenuItem, EventArgs.Empty);
        }

        private void Exit2MenuItem_Click(object sender, EventArgs e)
        {
            ExitMenuItem_Click(exit2MenuItem, EventArgs.Empty);
        }

        #endregion
    }
}
