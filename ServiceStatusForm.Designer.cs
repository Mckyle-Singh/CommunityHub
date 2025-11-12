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


    }
}