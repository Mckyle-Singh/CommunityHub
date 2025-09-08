namespace GovernmentApp
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnReportIssue;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;

        // Cards
        private System.Windows.Forms.FlowLayoutPanel flowCards;
        private System.Windows.Forms.Panel cardTotalReports;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Panel cardEvents;

        // DataGridView
        private System.Windows.Forms.DataGridView dgvRecentReports;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ---------------- Header ----------------
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);

            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHeader.Text = "Community Hub";
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(30, 15);
            this.panelHeader.Controls.Add(this.lblHeader);

            // ---------------- Sidebar ----------------
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 220;
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);

            this.btnReportIssue = CreateSidebarButton("Report Issue", 12F);
            this.btnLocalEvents = CreateSidebarButton("Local Events & Announcements", 10F);
            this.btnServiceStatus = CreateSidebarButton("Service Request Status", 10F);

            // Add buttons in reverse order so DockStyle.Top stacks correctly
            this.panelSidebar.Controls.Add(this.btnServiceStatus);
            this.panelSidebar.Controls.Add(this.btnLocalEvents);
            this.panelSidebar.Controls.Add(this.btnReportIssue);

            // ---------------- Main Content ----------------
            this.panelMainContent = new Panel();
            this.panelMainContent.Dock = DockStyle.Fill;
            this.panelMainContent.BackColor = Color.White;

            // FlowLayoutPanel for cards
            this.flowCards = new FlowLayoutPanel();
            this.flowCards.Dock = DockStyle.Top;
            this.flowCards.Height = 150;
            this.flowCards.Padding = new Padding(20);
            this.flowCards.WrapContents = true;
            this.flowCards.AutoSize = true;
            this.flowCards.BackColor = Color.White;

            // Cards
            this.cardTotalReports = CreateCardPanel(Color.FromArgb(0, 204, 204), "Total Reports", "0");
            this.cardPending = CreateCardPanel(Color.FromArgb(45, 45, 48), "Pending Requests", "0");
            this.cardEvents = CreateCardPanel(Color.FromArgb(30, 30, 30), "Local Events", "5");

            this.flowCards.Controls.Add(cardTotalReports);
            this.flowCards.Controls.Add(cardPending);
            this.flowCards.Controls.Add(cardEvents);

            // DataGridView for Recent Reports (modern style)
            this.dgvRecentReports = new DataGridView();
            this.dgvRecentReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentReports.ReadOnly = true;
            this.dgvRecentReports.AllowUserToAddRows = false;
            this.dgvRecentReports.AllowUserToDeleteRows = false;
            this.dgvRecentReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentReports.EnableHeadersVisualStyles = false;
            this.dgvRecentReports.BorderStyle = BorderStyle.FixedSingle;
            this.dgvRecentReports.BackgroundColor = Color.FromArgb(250, 250, 250);
            this.dgvRecentReports.GridColor = Color.FromArgb(220, 220, 220);
            this.dgvRecentReports.RowTemplate.Height = 40;
            this.dgvRecentReports.ColumnHeadersHeight = 40;
            this.dgvRecentReports.RowHeadersVisible = false;

            // Header style
            this.dgvRecentReports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            this.dgvRecentReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvRecentReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvRecentReports.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Row style
            this.dgvRecentReports.DefaultCellStyle.BackColor = Color.White;
            this.dgvRecentReports.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            this.dgvRecentReports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 191, 166); // teal selection
            this.dgvRecentReports.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvRecentReports.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvRecentReports.DefaultCellStyle.Padding = new Padding(5);

            // Alternating row style
            this.dgvRecentReports.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Columns
            this.dgvRecentReports.Columns.Add("Location", "Location");
            this.dgvRecentReports.Columns.Add("Category", "Category");
            this.dgvRecentReports.Columns.Add("Description", "Description");



            // ---------------- Container panel for spacing ----------------
            Panel dgvContainer = new Panel();
            dgvContainer.Dock = DockStyle.Fill;
            dgvContainer.Padding = new Padding(20, 0, 20, 30); // left, top, right, bottom spacing
            dgvRecentReports.Dock = DockStyle.Fill;
            dgvContainer.Controls.Add(dgvRecentReports);

            // Add controls to main content
            this.panelMainContent.Controls.Add(dgvContainer);
            this.panelMainContent.Controls.Add(flowCards); // keep cards on top


            // ---------------- Add panels to form ----------------
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);

            // ---------------- Form Properties ----------------
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 600);
            this.Text = "Home Page";

            this.ResumeLayout(false);
        }

        // Helper method to create sidebar button
        private Button CreateSidebarButton(string text, float fontSize)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", fontSize);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(45, 45, 48);
            btn.Height = 50;
            btn.Padding = new Padding(20, 0, 0, 0);
            return btn;
        }

        // Helper method to create a card panel
        private Panel CreateCardPanel(Color bgColor, string title, string value)
        {
            Panel card = new Panel();
            card.Size = new Size(220, 120);
            card.Margin = new Padding(10);
            card.BackColor = bgColor;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 10);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.ForeColor = Color.White;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.Location = new Point(10, 40);

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            return card;
        }

        #endregion
    }
}

