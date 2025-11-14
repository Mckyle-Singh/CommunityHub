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
            try
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

                        if (selectedFile.EndsWith(".jpg") || selectedFile.EndsWith(".jpeg") ||
                            selectedFile.EndsWith(".png") || selectedFile.EndsWith(".bmp"))
                        {
                            try
                            {
                                pbPreview.Image = Image.FromFile(selectedFile);
                                selectedAttachment = selectedFile; // store for submission
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            selectedAttachment = selectedFile; // store non-image file
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string location = txtLocation.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString();
                string description = rtbDescription.Text.Trim();

                if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Please fill in all required fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                progressBar.Visible = true;
                lblProgressStatus.Text = "Submitting...";
                lblProgressStatus.ForeColor = Color.Gray;
                lblProgressStatus.Visible = true;

                await Task.Delay(2000); // simulate submission

                ReportIssue report = new ReportIssue
                {
                    Location = location,
                    Category = category,
                    Description = description,
                    AttachmentPath = selectedAttachment
                };

                Reports.Add(report);

                progressBar.Visible = false;
                lblProgressStatus.Text = "Submitted successfully!";
                lblProgressStatus.ForeColor = Color.Green;

                txtLocation.Clear();
                cmbCategory.SelectedIndex = -1;
                rtbDescription.Clear();
                selectedAttachment = null;
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblProgressStatus.Text = "Submission failed!";
                lblProgressStatus.ForeColor = Color.Red;
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
