using CommunityHub.Models;
using CommunityHub.Services;
using System;
using System.Collections;
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
        // Used in BtnSearch_Click to track and retrieve event metadata like category and keyword frequency using dictionaries
        private Dictionary<string, int> searchFrequency = new Dictionary<string, int>();
        private Dictionary<string, int> keywordFrequency = new Dictionary<string, int>();

        public LocalEventsForm()
        {
            InitializeComponent();

            // ──────────────── ToolTips Setup ────────────────
            ToolTip tooltips = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 200,
                ShowAlways = true
            };

            tooltips.SetToolTip(cmbCategory, "Filter events by category. Select 'All' to view everything.");
            tooltips.SetToolTip(dtpDate, "Choose a specific date to narrow results. Uncheck to ignore date.");
            tooltips.SetToolTip(txtKeyword, "Search by title or description keywords like 'cleanup' or 'water'.");
            tooltips.SetToolTip(btnSearch, "Run your search using selected filters.");
            tooltips.SetToolTip(btnClearSearch, "Reset all filters and reload all events.");
            tooltips.SetToolTip(flowEvents, "Search results will appear here.");
            tooltips.SetToolTip(flowRecommendations, "Recommended events based on your recent searches.");

            // ──────────────── Event Wiring ────────────────
            btnBackHome.Click += BtnBackHome_Click;
            btnSearch.Click += BtnSearch_Click;
            btnClearSearch.Click += BtnClearSearch_Click;

            // ──────────────── Initial Load ────────────────
            LoadMockEvents();
            PopulateInsightsPanel();
        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();
            DateTime selectedDate = dtpDate.Value.Date;
            string keyword = txtKeyword.Text.Trim().ToLower();

            
            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All")
            {
                if (!searchFrequency.ContainsKey(selectedCategory))
                    searchFrequency[selectedCategory] = 0;

                searchFrequency[selectedCategory]++;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                if (!keywordFrequency.ContainsKey(keyword))
                    keywordFrequency[keyword] = 0;

                keywordFrequency[keyword]++;
            }

            var allEvents = MockEventService.GetUpcomingEvents();
            var filtered = allEvents.Where(ev =>
                (selectedCategory == "All" || ev.Category == selectedCategory) &&
                (!dtpDate.Checked || ev.Date.Date == selectedDate) &&
                (string.IsNullOrEmpty(keyword) ||
                 ev.Title.ToLower().Contains(keyword) ||
                 ev.Description.ToLower().Contains(keyword))
            ).ToList();

            filtered.Sort((a, b) => a.Date.CompareTo(b.Date)); 

            RenderEvents(filtered);
            var recommended = GetRecommendedEvents();
            RenderRecommendations(recommended);

        }

        //Demonstrates use of a queue to manage event-related data.
        private void LoadMockEvents()
        {
            Queue<Event> eventQueue = MockEventService.GetUpcomingEvents();
            List<Event> events = new List<Event>();
            while (eventQueue.Count > 0)
            {
                events.Add(eventQueue.Dequeue());
            }
            events.Sort((a, b) => a.Date.CompareTo(b.Date));
            RenderEvents(events);
        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            txtKeyword.Text = "";
            LoadMockEvents();
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


        /// <summary>
        /// Analyzes user search patterns, applies frequency-based filtering using dictionaries,
        /// and returns chronologically sorted recommended events for user-friendly display.
        /// </summary>
        private List<Event> GetRecommendedEvents()
        {
            var allEvents = MockEventService.GetUpcomingEvents();

            string keyword = txtKeyword.Text.Trim().ToLower();
            DateTime selectedDate = dtpDate.Value.Date;
            bool useDateFilter = dtpDate.Checked;

            List<string> topCategories;

            if (searchFrequency.Count == 0)
            {
                // Fallback: use all categories if no search history yet
                topCategories = allEvents.Select(ev => ev.Category).Distinct().ToList();
            }
            else
            {
                topCategories = searchFrequency
                    .OrderByDescending(kvp => kvp.Value)
                    .Take(2)
                    .Select(kvp => kvp.Key)
                    .ToList();
            }

            var recommended = allEvents
                .Where(ev =>
                    topCategories.Contains(ev.Category) &&
                    (!useDateFilter || ev.Date.Date == selectedDate) &&
                    (string.IsNullOrEmpty(keyword) ||
                     ev.Title?.ToLower().Contains(keyword) == true ||
                     ev.Description?.ToLower().Contains(keyword) == true)
                )
                .OrderBy(ev => ev.Date)
                .ToList();

            return recommended;

        }

        private void RenderRecommendations(List<Event> events)
        {
            flowRecommendations.Controls.Clear();
            var colors = MockEventService.GetCategoryColors();

            foreach (var ev in events)
            {
                Panel card = new Panel
                {
                    Width = 250,
                    Height = 100,
                    BackColor = Color.White,
                    Margin = new Padding(8),
                    Padding = new Padding(8),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblTitle = new Label
                {
                    Text = ev.Title,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = colors.ContainsKey(ev.Category) ? colors[ev.Category] : Color.Black,
                    Dock = DockStyle.Top
                };

                Label lblDate = new Label
                {
                    Text = ev.Date.ToString("MMM dd"),
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    Dock = DockStyle.Top
                };

                Label lblCategory = new Label
                {
                    Text = $"Category: {ev.Category}",
                    Font = new Font("Segoe UI", 9F),
                    Dock = DockStyle.Bottom
                };

                card.Controls.Add(lblCategory);
                card.Controls.Add(lblDate);
                card.Controls.Add(lblTitle);
                flowRecommendations.Controls.Add(card);
            }

            if (flowRecommendations.Controls.Count == 0)
            {
                Label noRecs = new Label
                {
                    Text = "No recommendations yet.",
                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flowRecommendations.Controls.Add(noRecs);
            }
        }

        private void FilterByCategory(string category)
        {
            cmbCategory.SelectedItem = category;
            BtnSearch_Click(null, null); // Trigger search
        }


        // Uses sets to track unique categories and dates while populating the insights panel with tags, summaries, and metadata.
        private void PopulateInsightsPanel()
        {
            var events = MockEventService.GetUpcomingEvents();

            // --- Use sets for uniqueness ---
            HashSet<string> uniqueCategories = new HashSet<string>();
            HashSet<DateTime> uniqueDates = new HashSet<DateTime>();

            foreach (var ev in events)
            {
                uniqueCategories.Add(ev.Category);
                uniqueDates.Add(ev.Date.Date);
            }

            // --- Update Tag Buttons ---
            flowTags.Controls.Clear();
            foreach (var cat in uniqueCategories.OrderBy(c => c))
            {
                Button btnTag = new Button
                {
                    Text = cat,
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Gainsboro,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Margin = new Padding(3, 0, 3, 0),
                    Padding = new Padding(6, 3, 6, 3),
                    AutoSize = true
                };
                btnTag.Click += (s, e) => FilterByCategory(cat);
                flowTags.Controls.Add(btnTag);
            }

            // --- Update Date Summary Grid ---
            dgvSummary.Rows.Clear();
            var grouped = events.GroupBy(e => e.Date.Date)
                                .OrderBy(g => g.Key);
            foreach (var group in grouped)
            {
                dgvSummary.Rows.Add(group.Key.ToShortDateString(), group.Count());
            }

            // --- Update Metadata Labels ---
            lblMetaCategories.Text = $"Categories: {uniqueCategories.Count}";
            lblMetaDates.Text = $"Unique Dates: {uniqueDates.Count}";
        }
    }
}
