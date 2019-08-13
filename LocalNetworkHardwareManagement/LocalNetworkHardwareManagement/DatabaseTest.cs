using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalNetworkHardware.DataLayer;

namespace LocalNetworkHardwareManagement
{
    public partial class DatabaseTest : Form
    {
        LocalNetworkHardwareManagement_DBEntities db = new LocalNetworkHardwareManagement_DBEntities();

        public DatabaseTest()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.CPUs.ToList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Systems.ToList();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Drivers.ToList();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OpratingSystems.ToList();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NetworkAdapters.ToList();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GPUs.ToList();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.SoundCards.ToList();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Printers.ToList();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.RAMs.ToList();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.CdROMs.ToList();
        }
    }
}
