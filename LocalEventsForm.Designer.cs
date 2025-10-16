namespace CommunityHub
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;



        private Label lblHeader;
        private FlowLayoutPanel flowEvents;
        private Button btnBackHome;
        private Panel panelHeader;
        private Panel panelSearch;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnClearSearch;

        private Panel panelInsights;
        private Label lblInsightsTitle;
        private FlowLayoutPanel flowTags;
        private Label lblDateSummary;
        private DataGridView dgvSummary;
        private Label lblMetaSummary;
        private Label lblMetaCategories;
        private Label lblMetaDates;

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

            // ---------------- Header Panel ----------------
            panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;
            panelHeader.BackColor = Color.FromArgb(30, 30, 30);

            // Header Label
            lblHeader = new Label();
            lblHeader.Text = "Local Events & Announcements";
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Dock = DockStyle.Left;
            lblHeader.AutoSize = false;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Width = 600;
            lblHeader.Padding = new Padding(20, 0, 0, 0);

            // Back Button
            btnBackHome = new Button();
            btnBackHome.Text = "← Back Home";
            btnBackHome.Font = new Font("Segoe UI", 10F);
            btnBackHome.Size = new Size(120, 30);
            btnBackHome.BackColor = Color.FromArgb(45, 45, 48);
            btnBackHome.ForeColor = Color.White;
            btnBackHome.FlatStyle = FlatStyle.Flat;
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.Size = new Size(120, 30);
            btnBackHome.Location = new Point(panelHeader.Width - 140, 20); // adjust X and Y
            btnBackHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackHome.Margin = new Padding(0, 20, 20, 0);

            // Search Panel
            panelSearch = new Panel();
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 50;
            panelSearch.Padding = new Padding(20, 10, 20, 10);
            panelSearch.BackColor = Color.FromArgb(45, 45, 48);

            // Category ComboBox
            cmbCategory = new ComboBox();
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.Width = 150;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Items.AddRange(new string[] { "All", "Public Notice", "Volunteer", "Government" });
            cmbCategory.SelectedIndex = 0;

            // Date Picker
            dtpDate = new DateTimePicker();
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Width = 150;
            dtpDate.Format = DateTimePickerFormat.Short;

            // Keyword TextBox
            txtKeyword = new TextBox();
            txtKeyword.Font = new Font("Segoe UI", 10F);
            txtKeyword.Width = 200;
            txtKeyword.PlaceholderText = "Search...";

            // Search Button
            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.BackColor = Color.FromArgb(60, 60, 60);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Width = 100;

            //clear search button
            btnClearSearch = new Button();
            btnClearSearch.Text = "Clear";
            btnClearSearch.Font = new Font("Segoe UI", 10F);
            btnClearSearch.BackColor = Color.FromArgb(60, 60, 60); // slightly lighter than Search
            btnClearSearch.ForeColor = Color.White;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.FlatAppearance.BorderSize = 0;
            btnClearSearch.Width = 100;

            // Positioning
            cmbCategory.Location = new Point(0, 10);
            dtpDate.Location = new Point(160, 10);
            txtKeyword.Location = new Point(320, 10);
            btnSearch.Location = new Point(530, 10);
            btnClearSearch.Location = new Point(640, 10);

            // Add to header panel
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(btnBackHome);

            // Add to search panel
            panelSearch.Controls.Add(cmbCategory);
            panelSearch.Controls.Add(dtpDate);
            panelSearch.Controls.Add(txtKeyword);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(btnClearSearch);


            // ---------------- FlowLayoutPanel for Events ----------------
            flowEvents = new FlowLayoutPanel();
            flowEvents.Dock = DockStyle.Fill;
            flowEvents.Padding = new Padding(20);
            flowEvents.AutoScroll = true;
            flowEvents.BackColor = Color.FromArgb(245, 245, 245);
            flowEvents.WrapContents = true;

            // ---------------- Recommendations Section ----------------
            panelRecommendations = new Panel();
            panelRecommendations.Dock = DockStyle.Bottom;
            panelRecommendations.Height = 150;
            panelRecommendations.BackColor = Color.WhiteSmoke;
            panelRecommendations.Padding = new Padding(15);

            lblRecommendations = new Label();
            lblRecommendations.Text = "Recommended for You";
            lblRecommendations.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRecommendations.AutoSize = true;
            lblRecommendations.Dock = DockStyle.Top;
            lblRecommendations.Margin = new Padding(0, 0, 0, 10);

            flowRecommendations = new FlowLayoutPanel();
            flowRecommendations.Dock = DockStyle.Fill;
            flowRecommendations.AutoScroll = true;
            flowRecommendations.WrapContents = true;
            flowRecommendations.Padding = new Padding(5);
            flowRecommendations.BackColor = Color.White;

            // Add inside panel
            panelRecommendations.Controls.Add(flowRecommendations);
            panelRecommendations.Controls.Add(lblRecommendations);

            // ---------------- Insights Panel ----------------
            panelInsights = new Panel();
            panelInsights.Dock = DockStyle.Right;
            panelInsights.Width = 260;
            panelInsights.BackColor = Color.WhiteSmoke;
            panelInsights.Padding = new Padding(10);

            // A vertical flow panel for content
            FlowLayoutPanel flowInsightsContent = new FlowLayoutPanel();
            flowInsightsContent.Dock = DockStyle.Fill;
            flowInsightsContent.FlowDirection = FlowDirection.TopDown;
            flowInsightsContent.WrapContents = false;
            flowInsightsContent.AutoScroll = true;
            flowInsightsContent.Padding = new Padding(0);
            flowInsightsContent.AutoSize = false;

            // Title
            lblInsightsTitle = new Label();
            lblInsightsTitle.Text = "Insights Panel";
            lblInsightsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInsightsTitle.AutoSize = true;

            // Tag buttons container
            flowTags = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,            // ✅ Keep horizontal layout
                AutoScroll = true,               // ✅ Enables scroll if overflow
                Height = 40,                     // ✅ Fixed height for compact layout
                Dock = DockStyle.Top,            // ✅ Anchors it properly
                Margin = new Padding(0, 5, 0, 10),
                Padding = new Padding(0),
                BackColor = Color.Transparent
            };


            // Date Summary Label
            lblDateSummary = new Label();
            lblDateSummary.Text = "Date Summary";
            lblDateSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDateSummary.AutoSize = true;
            lblDateSummary.Margin = new Padding(0, 10, 0, 5);

            // DataGridView for summary
            dgvSummary = new DataGridView();
            dgvSummary.ReadOnly = true;
            dgvSummary.AllowUserToAddRows = false;
            dgvSummary.AllowUserToDeleteRows = false;
            dgvSummary.RowHeadersVisible = false;
            dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummary.BackgroundColor = Color.White;
            dgvSummary.Height = 100; // fixed height prevents overlap
            dgvSummary.Margin = new Padding(0, 0, 0, 10);
            dgvSummary.Columns.Add("Date", "Date");
            dgvSummary.Columns.Add("EventCount", "Event Count");
           

            // Metadata Summary
            lblMetaSummary = new Label();
            lblMetaSummary.Text = "Metadata Summary";
            lblMetaSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMetaSummary.AutoSize = true;
            lblMetaSummary.Margin = new Padding(0, 10, 0, 5);

            lblMetaCategories = new Label();
            lblMetaCategories.Font = new Font("Segoe UI", 9F);
            lblMetaCategories.AutoSize = true;

            lblMetaDates = new Label();
            lblMetaDates.Font = new Font("Segoe UI", 9F);
            lblMetaDates.AutoSize = true;

            // Add to the flow panel
            flowInsightsContent.Controls.Add(lblInsightsTitle);
            flowInsightsContent.Controls.Add(flowTags);
            flowInsightsContent.Controls.Add(lblDateSummary);
            flowInsightsContent.Controls.Add(dgvSummary);
            flowInsightsContent.Controls.Add(lblMetaSummary);
            flowInsightsContent.Controls.Add(lblMetaCategories);
            flowInsightsContent.Controls.Add(lblMetaDates);

            // Add to main panel
            panelInsights.Controls.Add(flowInsightsContent);

            // ---------------- Add to Form ----------------
            this.Controls.Add(flowEvents);
            this.Controls.Add(this.panelRecommendations);
            this.Controls.Add(panelInsights);
            this.Controls.Add(panelSearch);
            this.Controls.Add(panelHeader);

        }

        #endregion
    }
}