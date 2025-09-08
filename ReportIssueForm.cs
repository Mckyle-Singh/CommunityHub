using GovernmentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GovernmentApp
{
    public partial class ReportIssueForm : Form
    {
        public static List<ReportIssue> Reports = new List<ReportIssue>();

        private string selectedAttachment = null; // keep last attached file

        public ReportIssueForm()
        {
            InitializeComponent();
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            this.btnAttachMedia.Click += new System.EventHandler(this.btnAttachMedia_Click);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);


        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|Video Files|*.mp4;*.avi;*.mov|All Files|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    MessageBox.Show($"Selected file: {selectedFile}", "Attachment Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // If it’s an image, display it in PictureBox
                    if (selectedFile.EndsWith(".jpg") || selectedFile.EndsWith(".jpeg") ||
                        selectedFile.EndsWith(".png") || selectedFile.EndsWith(".bmp"))
                    {
                        pbPreview.Image = Image.FromFile(selectedFile);
                    }

                    // 🔹 Later you can store selectedFile in a variable to save or submit with the issue
                }
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string location = txtLocation.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString();
            string description = rtbDescription.Text.Trim();

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show progress
            progressBar.Visible = true;
            lblProgressStatus.Text = "Submitting...";
            lblProgressStatus.ForeColor = Color.Gray;
            lblProgressStatus.Visible = true;

            // Fake "sending" delay
            await Task.Delay(2000);

            // Create report object
            ReportIssue report = new ReportIssue
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentPath = selectedAttachment
            };

            Reports.Add(report);

            // Hide progress + show success
            progressBar.Visible = false;
            lblProgressStatus.Text = "✅ Submitted successfully!";
            lblProgressStatus.ForeColor = Color.Green;

            

            // Reset fields
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            selectedAttachment = null;
        }

    }
}
