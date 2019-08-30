using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public MainForm()
        {
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
            //Should Go On Notification
        }

        private void FullExitButton_Click(object sender, EventArgs e)
        {
            //Should Close Nodes First
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

            //Just for test
            //using (UnitOfWork uof = new UnitOfWork())
            //{
            //    DatabaseDummyTest test = new DatabaseDummyTest(uof);
            //    await test.InsertTestRecords();
            //}

            //checking global system information in startup
            using (UnitOfWork uof = new UnitOfWork())
            {
                ManageSystemInformations manageSystem = new ManageSystemInformations(uof);
                ActivitiesText.Text = (await manageSystem.UpdateOwnedSystem())
                    .Replace("<newLine>", Environment.NewLine) + Environment.NewLine + ActivitiesText.Text;
            }

            //Getting Connected Nodes
            LoadLocalIPs();

            //Starting server to communicate with other nodes
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LocalNetworkIP))
            {
                ServerStartButton_Click(ServerStartButton, EventArgs.Empty);
            }

            //Helper
            //DatabaseTest newForm = new DatabaseTest();
            //newForm.Show();

            //ManageForm manageForm = new ManageForm("127.0.0.1");
            //manageForm.Show();

            //PcInfoForm pcInfoForm = new PcInfoForm();
            //pcInfoForm.Show();
        }

        private void LoadLocalIPs()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LocalNetworkIP))
            {
                LocalIPsCombo.Items.Add(Properties.Settings.Default.LocalNetworkIP);
            }
            var localIps = IpAddressManagement.GetLocalIPv4Addresses().ToArray();
            LocalIPsCombo.Items.AddRange(localIps);
            LocalIPsCombo.SelectedIndex = 0;
        }


        #endregion

        //TODO: Show Errors
        private async void ServerStartButton_Click(object sender, EventArgs e)
        {
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
                        Task.Run(() => AsynchronousSocketListener.StartListening());
                        ActivitiesText.Text = "سرور استارت شد." + Environment.NewLine + ActivitiesText.Text;

                        //Getting Connected Nodes
                        IpAddressManagement ipManagement = new IpAddressManagement();
                        NodesList.Items.AddRange(await ipManagement.StartGettingHosts(ip.ToString()));

                    }
                }
                else
                {
                    ActivitiesText.Text = "آیپی وارد شده اشتباه می باشد." + Environment.NewLine + ActivitiesText.Text;
                }
            }
            catch (Exception exception)
            {
                ActivitiesText.Text = "متاسفانه عملیات با شکست مواجه شد." + Environment.NewLine + ActivitiesText.Text;
            }
        }

        private void showNodesButton_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm(LocalIPsCombo.Text);
            manageForm.Show();
        }
    }
}
