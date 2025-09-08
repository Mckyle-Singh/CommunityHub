namespace GovernmentApp
{
    public partial class HomePage : Form
    {
        private Label placeholderLabel;
        public HomePage()
        {
            InitializeComponent();
            LoadReports();
            btnReportIssue.Click += BtnReportIssue_Click;
            btnLocalEvents.Click += (s, e) => ShowComingSoonPopup("Local Events & Announcements");
            btnServiceStatus.Click += (s, e) => ShowComingSoonPopup("Service Request Status");
        }

        private void BtnReportIssue_Click(object sender, EventArgs e)
        {

            using (ReportIssueForm reportForm = new ReportIssueForm())
            {
                this.Hide();               // hide current window
                reportForm.ShowDialog();   // open ReportIssueForm modally
                this.Show();               // show current window again after report form closes
                LoadReports();
            }
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

        private void LoadReports()
        {
            dgvRecentReports.Rows.Clear();

            // Prevent headers from turning blue when selected
            dgvRecentReports.EnableHeadersVisualStyles = false;
            dgvRecentReports.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvRecentReports.ColumnHeadersDefaultCellStyle.BackColor;
            dgvRecentReports.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvRecentReports.ColumnHeadersDefaultCellStyle.ForeColor;

            // Remove old placeholder if any
            if (placeholderLabel != null && dgvRecentReports.Controls.Contains(placeholderLabel))
                dgvRecentReports.Controls.Remove(placeholderLabel);

            if (ReportIssueForm.Reports.Count == 0)
            {
                placeholderLabel = new Label()
                {
                    Text = "No issues logged",
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                dgvRecentReports.Controls.Add(placeholderLabel);
            }
            else
            {
                foreach (var r in ReportIssueForm.Reports)
                {
                    dgvRecentReports.Rows.Add(r.Location, r.Category, r.Description);
                }

                // Clear selection so no row is highlighted in blue**
                dgvRecentReports.ClearSelection();
                dgvRecentReports.CurrentCell = null;

                // Optional: prevent user from selecting rows entirely
                dgvRecentReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRecentReports.ReadOnly = true;
            }
        }

    }
}
