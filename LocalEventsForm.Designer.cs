namespace CommunityHub
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        // ──────────────── Header ────────────────
        private Label lblHeader;
        private Panel panelHeader;
        private Button btnBackHome;

        // ──────────────── Search Controls ────────────────
        private Panel panelSearch;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnClearSearch;

        // ──────────────── Event Display ────────────────
        private FlowLayoutPanel flowEvents;

        // ──────────────── Insights Panel ────────────────
        private Panel panelInsights;
        private Label lblInsightsTitle;
        private FlowLayoutPanel flowTags;
        private Label lblDateSummary;
        private DataGridView dgvSummary;
        private Label lblMetaSummary;
        private Label lblMetaCategories;
        private Label lblMetaDates;

        // ──────────────── Recommendations ────────────────
        private Label lblRecommendations;
        private Panel panelRecommendations;
        private FlowLayoutPanel flowRecommendations;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Text = "Local Events & Announcements";
            this.Size = new Size(900, 600);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // ──────────────── Header Panel ────────────────
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            lblHeader = new Label
            {
                Text = "Local Events & Announcements",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Left,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Width = 600,
                Padding = new Padding(20, 0, 0, 0)
            };

            btnBackHome = new Button
            {
                Text = "← Back Home",
                Font = new Font("Segoe UI", 10F),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(panelHeader.Width - 140, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Margin = new Padding(0, 20, 20, 0)
            };
            btnBackHome.FlatAppearance.BorderSize = 0;

            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(btnBackHome);


            // ──────────────── Search Panel ────────────────
            panelSearch = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(20, 10, 20, 10),
                BackColor = Color.FromArgb(45, 45, 48)
            };

            cmbCategory = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.AddRange(new string[] { "All", "Public Notice", "Volunteer", "Government" });
            cmbCategory.SelectedIndex = 0;

            dtpDate = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10F),
                Width = 150,
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Checked = false
            };

            txtKeyword = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Width = 200,
                PlaceholderText = "Search..."
            };

            btnSearch = new Button
            {
                Text = "Search",
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100
            };
            btnSearch.FlatAppearance.BorderSize = 0;

            btnClearSearch = new Button
            {
                Text = "Clear",
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 100
            };
            btnClearSearch.FlatAppearance.BorderSize = 0;

            // Positioning
            cmbCategory.Location = new Point(0, 10);
            dtpDate.Location = new Point(160, 10);
            txtKeyword.Location = new Point(320, 10);
            btnSearch.Location = new Point(530, 10);
            btnClearSearch.Location = new Point(640, 10);

            panelSearch.Controls.Add(cmbCategory);
            panelSearch.Controls.Add(dtpDate);
            panelSearch.Controls.Add(txtKeyword);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(btnClearSearch);


            // ──────────────── Event Display ────────────────
            flowEvents = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true,
                BackColor = Color.FromArgb(245, 245, 245),
                WrapContents = true
            };


            // ──────────────── Recommendations Section ────────────────
            panelRecommendations = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 150,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(15)
            };

            lblRecommendations = new Label
            {
                Text = "Recommended for You",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 10)
            };

            flowRecommendations = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                Padding = new Padding(5),
                BackColor = Color.White
            };

            panelRecommendations.Controls.Add(flowRecommendations);
            panelRecommendations.Controls.Add(lblRecommendations);


            // ──────────────── Insights Panel ────────────────
            panelInsights = new Panel
            {
                Dock = DockStyle.Right,
                Width = 300,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            FlowLayoutPanel flowInsightsContent = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(0),
                AutoSize = false
            };

            lblInsightsTitle = new Label
            {
                Text = "Insights Panel",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true
            };

            flowTags = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,           // Prevent wrapping
                AutoScroll = true,             // Prevent scrollbars
                Dock = DockStyle.Top,
                Height = 40,                    // Enough for one row
                Width = panelInsights.Width - 20, // Slight padding
                Margin = new Padding(0, 5, 0, 10),
                Padding = new Padding(0),
                BackColor = Color.Transparent
            };



            lblDateSummary = new Label
            {
                Text = "Date Summary",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };

            dgvSummary = new DataGridView
            {
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.LightGray,
                Height = 100,
                Margin = new Padding(0, 0, 0, 10),
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false
            };

            // Add columns
            dgvSummary.Columns.Add("Date", "Date");
            dgvSummary.Columns.Add("EventCount", "Event Count");

            // ---------- Styling ----------
            dgvSummary.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240), // Light gray header
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.FromArgb(240, 240, 240),
                SelectionForeColor = Color.Black
            };

            dgvSummary.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(230, 230, 230),
                SelectionForeColor = Color.Black,
                Padding = new Padding(3)
            };

            lblMetaSummary = new Label
            {
                Text = "Metadata Summary",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };

            lblMetaCategories = new Label
            {
                Font = new Font("Segoe UI", 9F),
                AutoSize = true
            };

            lblMetaDates = new Label
            {
                Font = new Font("Segoe UI", 9F),
                AutoSize = true
            };

            flowInsightsContent.Controls.Add(lblInsightsTitle);
            flowInsightsContent.Controls.Add(flowTags);
            flowInsightsContent.Controls.Add(lblDateSummary);
            flowInsightsContent.Controls.Add(dgvSummary);
            flowInsightsContent.Controls.Add(lblMetaSummary);
            flowInsightsContent.Controls.Add(lblMetaCategories);
            flowInsightsContent.Controls.Add(lblMetaDates);

            panelInsights.Controls.Add(flowInsightsContent);


            // ──────────────── Add to Form ────────────────
            this.Controls.Add(flowEvents);
            this.Controls.Add(panelRecommendations);
            this.Controls.Add(panelInsights);
            this.Controls.Add(panelSearch);
            this.Controls.Add(panelHeader);
        }
        #endregion
    }
}