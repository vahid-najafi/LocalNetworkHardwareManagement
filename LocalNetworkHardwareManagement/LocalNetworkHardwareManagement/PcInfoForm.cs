using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkHardware.DataLayer.Context;
using LocalNetworkHardwareManagement.Core.Helpers;
using LocalNetworkHardwareManagement.Core.Models;
using LocalNetworkHardwareManagement.Core.Socket_Classes;
using LocalNetworkHardwareManagement.Core.Buisness;

namespace LocalNetworkHardwareManagement
{
    public partial class PcInfoForm : Form
    {
        private bool _formDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private IPAddress _ip;
        private bool _isOwned;

        public PcInfoForm(string ipAddress, bool isOwned)
        {
            _isOwned = isOwned;
            if (!IPAddress.TryParse(ipAddress, out _ip))
            {
                if (!_isOwned)
                {

                    MessageBox.Show("آیپی سیستم مقصد نا معتبر می باشد", "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
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
            this.Close();
        }

        #endregion

        private void PcInfoForm_Load(object sender, EventArgs e)
        {
            if (_ip != null)
                ipLabel.Text = _ip.ToString();

            if (_isOwned)
            {
                ShowMySystemInfo();
            }
            else
            {
                GetConnectedSystemInfo();
            }

        }

        private void FillControlsWithInfo(GlobalSystemModel systemModel, ActivitiesViewModel[] activities)
        {
            try
            {
                //System
                motherboardLabel.Text = systemModel.System.UniqMotherBoardId;
                nameLabel.Text = systemModel.System.Name;

                //CPU
                cpuNameLabel.Text = systemModel.CPU.Name;
                cpuCoresLabel.Text = systemModel.CPU.Cores.ToString();

                //RAM
                ramLabel.Text = systemModel.RAM.Memory.SizeSuffix();

                //Operating Systems
                osList.Items.AddRange(systemModel.OperatingSystems.Select(os => os.Name).ToArray());

                //Network Adapters
                networkAdaptersList.Items.AddRange(systemModel.NetworkAdapters.Select(na => na.Name).ToArray());

                //Sound Cards
                soundCardsList.Items.AddRange(systemModel.SoundCards.Select(s => s.Name).ToArray());

                //GPU
                gpuList.Items.AddRange(systemModel.GPUs.Select(g => g.Name).ToArray());

                //Printers
                printersList.Items.AddRange(systemModel.Printers.Select(p => p.Name).ToArray());

                //Drivers
                foreach (var driver in systemModel.Drivers)
                {
                    if (this.driversDataGrid.InvokeRequired)
                    {
                        driversDataGrid.Invoke(new Action(() =>
                        {
                            driversDataGrid.Rows.Add(driver.DiskName,
                                driver.Address,
                                driver.TotalSpace.SizeSuffix(),
                                driver.AvailableSpace.SizeSuffix());
                        }));
                    }
                    else
                    {
                        driversDataGrid.Invoke(new Action(() =>
                        {
                            driversDataGrid.Rows.Add(driver.DiskName,
                                driver.Address,
                                driver.TotalSpace.SizeSuffix(),
                                driver.AvailableSpace.SizeSuffix());
                        }));
                    }
                }

                //Activities
                foreach (ActivitiesViewModel activity in activities)
                {
                    activitiesText.Text += $"({activity.ShamsiDate}) - {activity.Description}" + Environment.NewLine;
                }
            }
            catch
            {
            }
        }

        private void CleanControls()
        {
            motherboardLabel.Text = "";
            nameLabel.Text = "";

            cpuNameLabel.Text = "";
            cpuCoresLabel.Text = "";

            ramLabel.Text = "";

            osList.Items.Clear();

            networkAdaptersList.Items.Clear();

            gpuList.Items.Clear();

            soundCardsList.Items.Clear();

            printersList.Items.Clear();

            driversDataGrid.Rows.Clear();
            driversDataGrid.Refresh();

            activitiesText.Text = "";
        }

        private void GetConnectedSystemInfo()
        {
            //Start Client
            AsynchronousClient client = new AsynchronousClient();
            string recievedMessage = client.StartClient("/get", _ip);

            if (recievedMessage.Contains("<global>"))
            {
                //Getting Activities And System Model From Message
                ActivitiesViewModel[] activities;
                GlobalSystemModel systemModel = ManageSystemInformations
                    .ConverMessageToGlobalSystemModel(recievedMessage, out activities);

                //Add Or Update This System
                using (UnitOfWork uow = new UnitOfWork())
                {
                    ManageSystemInformations manageSystem = new ManageSystemInformations(uow, false);
                    manageSystem.AddOrUpdateSystem(systemModel);
                }

                //Fill The Controls
                CleanControls();
                FillControlsWithInfo(systemModel, activities);
            }
            else
            {
                MessageBox.Show(recievedMessage);
                this.Close();
            }
        }

        private async void ShowMySystemInfo()
        {
            ActivitiesViewModel[] activities;
            GlobalSystemModel systemModel = await HardwareInformationHelper.GetGlobalSystemModel();
            using (UnitOfWork uow = new UnitOfWork())
            {
                ManageSystemInformations systemInformations =
                    new ManageSystemInformations(uow, false);
                activities = systemInformations.GetSystemActivitiesToShow().ToArray();
            }

            CleanControls();
            FillControlsWithInfo(systemModel, activities);
        }
    }
}
