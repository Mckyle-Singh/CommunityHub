namespace GovernmentApp
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            btnReportIssue.Click += BtnReportIssue_Click;
            btnLocalEvents.Click += (s, e) => ShowComingSoonPopup("Local Events & Announcements");
            btnServiceStatus.Click += (s, e) => ShowComingSoonPopup("Service Request Status");
        }

        private void BtnReportIssue_Click(object sender, EventArgs e)
        {
            
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.Show();
            this.Hide();
        }

        private void ShowComingSoonPopup(string featureName)
        {
            Form popup = new Form();
            popup.Size = new Size(300, 150);
            popup.StartPosition = FormStartPosition.CenterParent;

            // Keep the standard title bar with the close button
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.BackColor = Color.FromArgb(45, 45, 48);

            Label lbl = new Label();
            lbl.Text = $"{featureName} coming soon!";
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;

            popup.Controls.Add(lbl);

            popup.ShowDialog();
        }

    }
}
