using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkHardware.DataLayer.Context;
using LocalNetworkHardwareManagement.Core.Buisness;
using LocalNetworkHardwareManagement.Core.Helpers;
using LocalNetworkHardwareManagement.Core.Socket_Classes;

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
            ExitButton.ForeColor = Color.DarkRed;
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
                ManageSystemInformations manageSystem = new ManageSystemInformations(uof);
                ActivitiesText.Text += (await manageSystem.UpdateOwnedSystem())
                    .Replace("<newLine>", Environment.NewLine);
            }

            //Starting server to communicate with other nodes
            Task.Run(() => AsynchronousSocketListener.StartListening());

            ActivitiesText.Text += "سرور استارت شد.\n";
            //Helper
            DatabaseTest newForm = new DatabaseTest();
            newForm.Show();
        }

        #endregion


    }
}
