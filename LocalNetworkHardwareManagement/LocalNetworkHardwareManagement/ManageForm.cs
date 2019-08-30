using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkHardwareManagement.Core.Buisness;
using LocalNetworkHardwareManagement.Core.Models;
using LocalNetworkHardwareManagement.Core.Socket_Classes;

namespace LocalNetworkHardwareManagement
{
    public partial class ManageForm : Form
    {
        private string _ipAddress;
        private bool _formDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        public ManageForm(string ipAddress)
        {
            InitializeComponent();
            _ipAddress = ipAddress;
            ipLabel.Text = _ipAddress;
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
            this.Close();
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

        #region Form Load

        private void ManageForm_Load(object sender, EventArgs e)
        {
            UpdateLocalNodesInfo();

            pcNameLabel.Text = Environment.MachineName;
        }

        private async Task UpdateLocalNodesInfo()
        {
            IpAddressManagement ipManagement = new IpAddressManagement();
            var localIps = await ipManagement.StartGettingHosts(_ipAddress);

            await Task.Run(() =>
            {
                foreach (string ip in localIps)
                {
                    AsynchronousClient client = new AsynchronousClient();
                    string recievedMessage = client.StartClient("/getshort", ip);

                    if (recievedMessage.Contains("<system>"))
                    {
                        ShortSystemModel systemModel =
                            ManageSystemInformations.ConvertMessageToShortSystemModel(recievedMessage);

                        systemModel.SystemIp = ip;

                        if (this.nodesDataGrid.InvokeRequired)
                        {
                            nodesDataGrid.Invoke(new Action(() =>
                            {
                                nodesDataGrid.Rows.Add(systemModel.SystemIp, systemModel.SystemName, systemModel.Cpu);
                            }));
                        }
                        else
                        {
                            nodesDataGrid.Rows.Add(systemModel.SystemIp, systemModel.SystemName, systemModel.Cpu);
                        }

                    }
                    else
                    {
                        if (this.nodesDataGrid.InvokeRequired)
                        {
                            nodesDataGrid.Invoke(new Action(() => { nodesDataGrid.Rows.Add(ip, "", ""); }));
                        }
                        else
                        {
                            nodesDataGrid.Rows.Add(ip, "", "");
                        }
                    }


                }

                if (this.nodesDataGrid.InvokeRequired)
                {
                    nodesDataGrid.Invoke(new Action(() => { nodesDataGrid.Rows.Add("123.123.1.1", "TestData", "TestData"); }));
                }
                else
                {
                    nodesDataGrid.Rows.Add("123.123.1.1", "TestData", "TestData");
                }
            });
        }


        #endregion

        private async void SowSelectedSystemButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                //Get Selected System Ip
                if (nodesDataGrid.SelectedRows.Count <= 0)
                    return;

                string ipAddress = nodesDataGrid.SelectedRows[0].Cells[0].Value.ToString();

                PcInfoForm infoForm = new PcInfoForm(ipAddress);
                infoForm.ShowDialog();
            });

        }
    }
}
