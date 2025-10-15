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
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
            btnBackHome.Click += BtnBackHome_Click;

        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the modal and returns to HomePage
        }
    }
}
