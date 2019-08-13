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
    }
}
