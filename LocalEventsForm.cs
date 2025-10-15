using CommunityHub.Models;
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
            btnClearSearch.Click += BtnClearSearch_Click;

            LoadMockEvents();
            AnalyzeEventMetadata();
            
        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close(); // closes the modal and returns to HomePage
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();
            DateTime selectedDate = dtpDate.Value.Date;
            string keyword = txtKeyword.Text.Trim().ToLower();

            var allEvents = MockEventService.GetUpcomingEvents();
            var filtered = allEvents.Where(ev =>
                (selectedCategory == "All" || ev.Category == selectedCategory) &&
                ev.Date.Date == selectedDate &&
                (string.IsNullOrEmpty(keyword) ||
                 ev.Title.ToLower().Contains(keyword) ||
                 ev.Description.ToLower().Contains(keyword))
            ).ToList();

            filtered.Sort((a, b) => a.Date.CompareTo(b.Date)); // soonest first

            RenderEvents(filtered);
        }

        private void LoadMockEvents()
        {
            var sortedEvents = new List<Event>(MockEventService.GetUpcomingEvents());
            sortedEvents.Sort((a, b) => a.Date.CompareTo(b.Date)); // soonest first
            RenderEvents(sortedEvents);
        }


        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            txtKeyword.Text = "";
            LoadMockEvents(); // reload all events
        }

        private void RenderEvents(List<Event> events)
        {
            flowEvents.Controls.Clear();
            var colors = MockEventService.GetCategoryColors();

            foreach (var ev in events)
            {
                Panel card = new Panel
                {
                    Width = 800,
                    Height = 100,
                    BackColor = Color.White,
                    Margin = new Padding(10),
                    Padding = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblTitle = new Label
                {
                    Text = ev.Title,
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = colors.ContainsKey(ev.Category) ? colors[ev.Category] : Color.Black,
                    Dock = DockStyle.Top
                };

                Label lblDate = new Label
                {
                    Text = ev.Date.ToString("MMMM dd, yyyy"),
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    Dock = DockStyle.Top
                };

                Label lblDesc = new Label
                {
                    Text = ev.Description,
                    Font = new Font("Segoe UI", 10F),
                    Dock = DockStyle.Fill
                };

                // Highlight urgent events
                if ((ev.Date - DateTime.Today).TotalDays <= 1)
                {
                    card.BackColor = Color.LightYellow;
                    lblTitle.Text += " ⚠️";
                }

                card.Controls.Add(lblDesc);
                card.Controls.Add(lblDate);
                card.Controls.Add(lblTitle);
                flowEvents.Controls.Add(card);
            }

            if (flowEvents.Controls.Count == 0)
            {
                Label noResults = new Label
                {
                    Text = "No events match your search.",
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flowEvents.Controls.Add(noResults);
            }
        }

        private void AnalyzeEventMetadata()
        {
            var events = MockEventService.GetUpcomingEvents();

            HashSet<string> uniqueCategories = new HashSet<string>();
            HashSet<DateTime> uniqueDates = new HashSet<DateTime>();

            foreach (var ev in events)
            {
                uniqueCategories.Add(ev.Category);
                uniqueDates.Add(ev.Date.Date);
            }

            Console.WriteLine("Unique Categories:");
            foreach (var cat in uniqueCategories)
                Console.WriteLine($"- {cat}");

            Console.WriteLine("Unique Dates:");
            foreach (var date in uniqueDates)
                Console.WriteLine($"- {date.ToShortDateString()}");
        }

    }
}
