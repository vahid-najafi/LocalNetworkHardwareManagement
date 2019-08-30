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

        public PcInfoForm(string ipAddress)
        {
            IPAddress.TryParse(ipAddress, out _ip);
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

            if (String.IsNullOrEmpty(_ip.ToString()))
                MessageBox.Show("Error");

            ipLabel.Text = _ip.ToString();

            AsynchronousClient client = new AsynchronousClient();
            string recievedMessage = client.StartClient("/get", _ip);

            if (recievedMessage.Contains("<global>"))
            {
                GlobalSystemModel systemModel = ManageSystemInformations.ConverMessageToGlobalSystemModel(recievedMessage);

                //Add Or Update This System
                using (UnitOfWork uow = new UnitOfWork())
                {
                    ManageSystemInformations manageSystem = new ManageSystemInformations(uow);
                    manageSystem.AddOrUpdateThisSystem(systemModel);
                }

                //Fill The Controls
                CleanControls();
                FillControlsWithInfo(systemModel);
            }
            else
            {
                MessageBox.Show(recievedMessage);
                this.Close();
            }
        }

        private void FillControlsWithInfo(GlobalSystemModel systemModel)
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

            //TODO: Activities

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
    }
}
