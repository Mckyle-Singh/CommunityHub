using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunityHub
{
    public partial class ServiceStatusForm : Form
    {
        public ServiceStatusForm()
        {
            InitializeComponent();
            this.Text = "Service Request Status";
            this.BackColor = Color.White;
        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close(); // Or navigate to HomePage if needed
        }


    }
}
