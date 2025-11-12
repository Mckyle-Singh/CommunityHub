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

        private Panel CreateKpiTile(string title, string value, Color bgColor)
        {
            Panel tile = new Panel
            {
                Size = new Size(220, 80),
                BackColor = bgColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 35),
                AutoSize = true
            };

            tile.Controls.Add(lblTitle);
            tile.Controls.Add(lblValue);

            return tile;
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.SelectedItem.ToString();
            string category = cmbCategory.SelectedItem.ToString();
            string keyword = txtSearch.Text.Trim();

            MessageBox.Show($"Filtering: {status}, {category}, \"{keyword}\"");
        }

        private void dgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRequests.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Pending")
                    e.CellStyle.ForeColor = Color.DarkOrange;
                else if (status == "Resolved")
                    e.CellStyle.ForeColor = Color.ForestGreen;
            }
        }



    }
}
