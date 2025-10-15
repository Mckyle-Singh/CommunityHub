using CommunityHub.Services;
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
            btnSearch.Click += BtnSearch_Click;
            LoadMockEvents();
        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the modal and returns to HomePage
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search clicked — logic coming in Phase 5!");
        }

        private void LoadMockEvents()
        {
            flowEvents.Controls.Clear();

            var events = MockEventService.GetUpcomingEvents();
            var colors = MockEventService.GetCategoryColors();

            foreach (var ev in events)
            {
                Panel card = new Panel();
                card.Width = 800;
                card.Height = 100;
                card.BackColor = Color.White;
                card.Margin = new Padding(10);
                card.Padding = new Padding(10);
                card.BorderStyle = BorderStyle.FixedSingle;

                Label lblTitle = new Label();
                lblTitle.Text = ev.Title;
                lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                lblTitle.ForeColor = colors.ContainsKey(ev.Category) ? colors[ev.Category] : Color.Black;
                lblTitle.Dock = DockStyle.Top;

                Label lblDate = new Label();
                lblDate.Text = ev.Date.ToString("MMMM dd, yyyy");
                lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                lblDate.Dock = DockStyle.Top;

                Label lblDesc = new Label();
                lblDesc.Text = ev.Description;
                lblDesc.Font = new Font("Segoe UI", 10F);
                lblDesc.Dock = DockStyle.Fill;

                card.Controls.Add(lblDesc);
                card.Controls.Add(lblDate);
                card.Controls.Add(lblTitle);

                flowEvents.Controls.Add(card);
            }
        }

    }
}
