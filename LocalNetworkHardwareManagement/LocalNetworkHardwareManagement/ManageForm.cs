using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Should Go On Notification
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
                //mainMenu.Show(this.PointToScreen(e.Location));
            }
        }

        #endregion
    }
}
