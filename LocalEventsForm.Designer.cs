namespace CommunityHub
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private FlowLayoutPanel flowEvents;
        private Button btnBackHome;
        private Panel panelHeader;

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

            // Add to header panel
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(btnBackHome);

            // ---------------- FlowLayoutPanel for Events ----------------
            flowEvents = new FlowLayoutPanel();
            flowEvents.Dock = DockStyle.Fill;
            flowEvents.Padding = new Padding(20);
            flowEvents.AutoScroll = true;
            flowEvents.BackColor = Color.FromArgb(245, 245, 245);
            flowEvents.WrapContents = true;

            // ---------------- Add to Form ----------------
            this.Controls.Add(flowEvents);
            this.Controls.Add(panelHeader);
        }

        #endregion
    }
}