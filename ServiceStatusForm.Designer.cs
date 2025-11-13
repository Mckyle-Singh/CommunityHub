namespace CommunityHub
{
    partial class ServiceStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header controls
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.FlowLayoutPanel rightHeaderPanel;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Label lblTitle;

        //Tile controlls
        private System.Windows.Forms.Panel kpiPanel;
        private System.Windows.Forms.Panel tileTotal;
        private System.Windows.Forms.Panel tilePending;
        private System.Windows.Forms.Panel tileLocal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Label lblPendingValue;
        private System.Windows.Forms.Label lblLocalTitle;
        private System.Windows.Forms.Label lblLocalValue;

        //filter section
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSearch;

        //data grid view
        private System.Windows.Forms.Panel tableContainer;
        private System.Windows.Forms.DataGridView dgvRequests;


        //urgent request 
        private Panel urgentPanel;
        private Label lblUrgentTitle;
        private ListView lvUrgentRequests;

        // Blocked Chain Panel
        private FlowLayoutPanel blockedChainPanel;
        private Label lblBlockedChainTitle;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "ServiceStatusForm";

            InitializeBlockedChainPanel();
            InitializeUrgentRequestSection();
            InitializeRequestTable();
            InitializeFilterSection();
            InitializeKpiTiles();
            InitializeHeader();
           

        }

        private void InitializeHeader()
        {
            // Header panel
            headerPanel = new System.Windows.Forms.Panel
            {
                BackColor = System.Drawing.Color.Black,
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 60,
                TabIndex = 0
            };

            // Title label
            lblTitle = new System.Windows.Forms.Label
            {
                Text = "Service Request Status",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                AutoSize = true,
                Location = new System.Drawing.Point(20, 15),
                TabIndex = 1
            };

            // Back button
            btnBackHome = new System.Windows.Forms.Button
            {
                Text = "← Back Home",
                Font = new System.Drawing.Font("Segoe UI", 10F),
                Size = new System.Drawing.Size(120, 30),
                BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                TabIndex = 2
            };
            btnBackHome.FlatAppearance.BorderSize = 0;
            btnBackHome.Click += new System.EventHandler(this.BtnBackHome_Click);

            // Right-aligned container for button
            rightHeaderPanel = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Right,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 15, 20, 0),
                AutoSize = true
            };
            rightHeaderPanel.Controls.Add(btnBackHome);

            // Assemble header
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(rightHeaderPanel);
            this.Controls.Add(headerPanel);
        }

        private void InitializeKpiTiles()
        {
            kpiPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(20, 10, 20, 10),
                BackColor = Color.White
            };

            tileTotal = CreateKpiTile("Total Requests", "128", Color.FromArgb(240, 248, 255));
            tilePending = CreateKpiTile("Pending Requests", "37", Color.FromArgb(255, 250, 205));
            tileLocal = CreateKpiTile("Local Requests", "19", Color.FromArgb(245, 255, 250));

            tileTotal.Location = new Point(20, 20);
            tilePending.Location = new Point(280, 20);
            tileLocal.Location = new Point(540, 20);

            kpiPanel.Controls.Add(tileTotal);
            kpiPanel.Controls.Add(tilePending);
            kpiPanel.Controls.Add(tileLocal);

            this.Controls.Add(kpiPanel);
        }

        private void InitializeFilterSection()
        {
            filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(20, 10, 20, 10),
                BackColor = Color.White
            };

            lblStatus = new Label
            {
                Text = "Status:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Location = new Point(20, 0),
                AutoSize = true
            };

            cmbStatus = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(20, 15),
                Size = new Size(150, 30)
            };
            cmbStatus.Items.AddRange(new string[] { "All", "Pending", "Resolved" });
            cmbStatus.SelectedIndex = 0;

            lblCategory = new Label
            {
                Text = "Category:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Location = new Point(190, 0),
                AutoSize = true
            };

            cmbCategory = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(190, 15),
                Size = new Size(150, 30)
            };
            cmbCategory.Items.AddRange(new string[] { "All", "Water", "Electricity", "Roads" });
            cmbCategory.SelectedIndex = 0;

            lblSearch = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Location = new Point(360, 0),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                Location = new Point(360, 15),
                Size = new Size(200, 30),
                PlaceholderText = "Search by keyword..."
            };

            btnSearch = new Button
            {
                Text = "Search",
                Font = new Font("Segoe UI", 10F),
                Size = new Size(100, 30),
                Location = new Point(570, 15),
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += new EventHandler(this.BtnSearch_Click);

            filterPanel.Controls.Add(lblStatus);
            filterPanel.Controls.Add(cmbStatus);
            filterPanel.Controls.Add(lblCategory);
            filterPanel.Controls.Add(cmbCategory);
            filterPanel.Controls.Add(lblSearch);
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(btnSearch);

            this.Controls.Add(filterPanel);
        }

        private void InitializeRequestTable()
        {
            // Container panel to center the table
            tableContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            dgvRequests = new DataGridView
            {
                Size = new Size(760, 300),
                Location = new Point(20, 10),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10F),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(240, 240, 240),
                    ForeColor = Color.Black,
                    SelectionBackColor = Color.FromArgb(200, 200, 200),
                    SelectionForeColor = Color.Black,
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                EnableHeadersVisualStyles = false


            };

            dgvRequests.Columns.Add("RequestId", "Request ID");
            dgvRequests.Columns.Add("Category", "Category");
            dgvRequests.Columns.Add("Status", "Status");
            dgvRequests.Columns.Add("Date", "Date");
            dgvRequests.Columns.Add("Summary", "Summary");

            // Sample data
            //dgvRequests.Rows.Add("REQ-001", "Water", "Pending", "2025-11-10", "Burst pipe on Main Street");
            //dgvRequests.Rows.Add("REQ-002", "Electricity", "Resolved", "2025-11-09", "Power outage in Zone 3");
            //dgvRequests.Rows.Add("REQ-003", "Roads", "Pending", "2025-11-08", "Pothole near school entrance");

            dgvRequests.CellFormatting += dgvRequests_CellFormatting;

            tableContainer.Controls.Add(dgvRequests);
            this.Controls.Add(tableContainer);
        }

        private void InitializeUrgentRequestSection()
        {
            urgentPanel = new Panel
            {
                Width = 250,
                Height = 150, // Constrained height so it doesn't stretch down
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.ClientSize.Width - 270, 100), // Adjust Y to align with filters
                Padding = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            lblUrgentTitle = new Label
            {
                Text = "Urgent Requests",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft
            };

            lvUrgentRequests = new ListView
            {
                View = View.Details,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                FullRowSelect = true,
                GridLines = true,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            // Simplified columns: only ID and Category
            lvUrgentRequests.Columns.Add("Request ID", 100);
            lvUrgentRequests.Columns.Add("Category", 120);

            urgentPanel.Controls.Add(lvUrgentRequests);
            urgentPanel.Controls.Add(lblUrgentTitle);

            this.Controls.Add(urgentPanel);
        }

        private void InitializeBlockedChainPanel()
        {
            lblBlockedChainTitle = new Label
            {
                Text = "Blocked Chain",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(20, 360),
                AutoSize = true
            };

            blockedChainPanel = new FlowLayoutPanel
            {
                Name = "blockedChainPanel",
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Location = new Point(20, 390),
                Size = new Size(760, 80),
                BackColor = Color.White,
                Padding = new Padding(5)
            };

            this.Controls.Add(lblBlockedChainTitle);
            this.Controls.Add(blockedChainPanel);

        }


    }
}