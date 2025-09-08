namespace GovernmentApp
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblFormHeader;
        private Panel panelMainContent;

        private Panel pnlLocationCard;
        private Label lblLocation;
        private TextBox txtLocation;

        private Panel pnlCategoryCard;
        private Label lblCategory;
        private ComboBox cmbCategory;

        private Panel pnlDescriptionCard;
        private Label lblDescription;
        private RichTextBox rtbDescription;

        private Panel pnlAttachmentCard;
        private Button btnAttachMedia;
        private PictureBox pbPreview;

        private Button btnSubmit;
        private Button btnBackHome;
        private ProgressBar progressBar;
        private Label lblProgressStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing != null && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ------------------------
            // Form Header
            this.lblFormHeader = new Label();
            this.lblFormHeader.Text = "Report Issue";
            this.lblFormHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblFormHeader.ForeColor = Color.FromArgb(30, 30, 30);
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Location = new Point(30, 10);
            this.lblFormHeader.Anchor = AnchorStyles.Top;

            // ------------------------
            // Back Button
            this.btnBackHome = new Button();
            this.btnBackHome.Text = "← Back Home";
            this.btnBackHome.Font = new Font("Segoe UI", 10F);
            this.btnBackHome.Size = new Size(120, 30);
            this.btnBackHome.Location = new Point(650, 15);
            this.btnBackHome.BackColor = Color.FromArgb(45, 45, 48);
            this.btnBackHome.ForeColor = Color.White;
            this.btnBackHome.FlatStyle = FlatStyle.Flat;
            this.btnBackHome.FlatAppearance.BorderSize = 0;
            this.btnBackHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // ------------------------
            // Main Content Panel
            this.panelMainContent = new Panel();
            this.panelMainContent.Location = new Point(50, 60);
            this.panelMainContent.Size = new Size(this.ClientSize.Width - 100, 640);
            this.panelMainContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panelMainContent.AutoScroll = true;

            // ------------------------
            // Location Card
            this.pnlLocationCard = new Panel();
            this.pnlLocationCard.Size = new Size(700, 70);
            this.pnlLocationCard.BackColor = Color.FromArgb(245, 245, 245);
            this.pnlLocationCard.BorderStyle = BorderStyle.FixedSingle;
            this.pnlLocationCard.Location = new Point(0, 0);

            this.lblLocation = new Label();
            this.lblLocation.Text = "Location of Issue:";
            this.lblLocation.Font = new Font("Segoe UI", 12F);
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new Point(10, 10);

            this.txtLocation = new TextBox();
            this.txtLocation.Font = new Font("Segoe UI", 12F);
            this.txtLocation.Size = new Size(680, 30);
            this.txtLocation.Location = new Point(10, 35);

            this.pnlLocationCard.Controls.Add(this.lblLocation);
            this.pnlLocationCard.Controls.Add(this.txtLocation);

            // ------------------------
            // Category Card
            this.pnlCategoryCard = new Panel();
            this.pnlCategoryCard.Size = new Size(700, 70);
            this.pnlCategoryCard.BackColor = Color.FromArgb(245, 245, 245);
            this.pnlCategoryCard.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCategoryCard.Location = new Point(0, 80);

            this.lblCategory = new Label();
            this.lblCategory.Text = "Category:";
            this.lblCategory.Font = new Font("Segoe UI", 12F);
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new Point(10, 10);

            this.cmbCategory = new ComboBox();
            this.cmbCategory.Font = new Font("Segoe UI", 12F);
            this.cmbCategory.Size = new Size(300, 30);
            this.cmbCategory.Location = new Point(10, 35);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] {
                "Road Issue", "Water Supply", "Electricity", "Public Safety", "Other"
            });

            this.pnlCategoryCard.Controls.Add(this.lblCategory);
            this.pnlCategoryCard.Controls.Add(this.cmbCategory);

            // ------------------------
            // Description Card
            this.pnlDescriptionCard = new Panel();
            this.pnlDescriptionCard.Size = new Size(700, 200);
            this.pnlDescriptionCard.BackColor = Color.FromArgb(245, 245, 245);
            this.pnlDescriptionCard.BorderStyle = BorderStyle.FixedSingle;
            this.pnlDescriptionCard.Location = new Point(0, 160);

            this.lblDescription = new Label();
            this.lblDescription.Text = "Description:";
            this.lblDescription.Font = new Font("Segoe UI", 12F);
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(10, 10);

            this.rtbDescription = new RichTextBox();
            this.rtbDescription.Font = new Font("Segoe UI", 12F);
            this.rtbDescription.Size = new Size(680, 150);
            this.rtbDescription.Location = new Point(10, 35);

            this.pnlDescriptionCard.Controls.Add(this.lblDescription);
            this.pnlDescriptionCard.Controls.Add(this.rtbDescription);

            // ------------------------
            // Attachment Card
            this.pnlAttachmentCard = new Panel();
            this.pnlAttachmentCard.Size = new Size(700, 120);
            this.pnlAttachmentCard.BackColor = Color.FromArgb(245, 245, 245);
            this.pnlAttachmentCard.BorderStyle = BorderStyle.FixedSingle;
            this.pnlAttachmentCard.Location = new Point(0, 380);

            this.btnAttachMedia = new Button();
            this.btnAttachMedia.Text = "Attach Media";
            this.btnAttachMedia.Font = new Font("Segoe UI", 12F);
            this.btnAttachMedia.Size = new Size(150, 40);
            this.btnAttachMedia.Location = new Point(10, 30);
            this.btnAttachMedia.BackColor = Color.FromArgb(45, 45, 48);
            this.btnAttachMedia.ForeColor = Color.White;
            this.btnAttachMedia.FlatStyle = FlatStyle.Flat;
            this.btnAttachMedia.FlatAppearance.BorderSize = 0;

            this.pbPreview = new PictureBox();
            this.pbPreview.Location = new Point(180, 20);
            this.pbPreview.Size = new Size(100, 80);
            this.pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbPreview.BorderStyle = BorderStyle.FixedSingle;
            this.pbPreview.BackColor = Color.FromArgb(230, 230, 230);

            this.pnlAttachmentCard.Controls.Add(this.btnAttachMedia);
            this.pnlAttachmentCard.Controls.Add(this.pbPreview);

            // ------------------------
            // Submit Button
            this.btnSubmit = new Button();
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSubmit.Size = new Size(150, 40);
            this.btnSubmit.Location = new Point(0, 510);
            this.btnSubmit.BackColor = Color.FromArgb(0, 204, 204);
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;

            // ------------------------
            // Progress Bar & Status
            this.progressBar = new ProgressBar();
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Size = new Size(700, 20);
            this.progressBar.Location = new Point(0, 560);
            this.progressBar.Visible = false;

            this.lblProgressStatus = new Label();
            this.lblProgressStatus.Text = "";
            this.lblProgressStatus.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblProgressStatus.ForeColor = Color.Gray;
            this.lblProgressStatus.Location = new Point(0, 590);
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Visible = false;

            // ------------------------
            // Add cards to main panel
            this.panelMainContent.Controls.Add(this.pnlLocationCard);
            this.panelMainContent.Controls.Add(this.pnlCategoryCard);
            this.panelMainContent.Controls.Add(this.pnlDescriptionCard);
            this.panelMainContent.Controls.Add(this.pnlAttachmentCard);
            this.panelMainContent.Controls.Add(this.btnSubmit);
            this.panelMainContent.Controls.Add(this.progressBar);
            this.panelMainContent.Controls.Add(this.lblProgressStatus);

            // ------------------------
            // Add controls to form
            this.Controls.Add(this.lblFormHeader);
            this.Controls.Add(this.btnBackHome);
            this.Controls.Add(this.panelMainContent);

            // ------------------------
            // Form properties
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 720);
            this.Text = "Report Issue";
            this.BackColor = Color.White;

            // ------------------------
            // Resize event
            this.Resize += ReportIssueForm_Resize;

            // Apply layout immediately
            this.Load += (s, e) => UpdateLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ------------------------
        private void ReportIssueForm_Resize(object sender, EventArgs e)
        {
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            int maxCardWidth = 700;
            int sidePadding = 30;

            int cardWidth = Math.Min(this.ClientSize.Width - 2 * sidePadding, maxCardWidth);

            // Center all cards
            pnlLocationCard.Width = pnlCategoryCard.Width = pnlDescriptionCard.Width = pnlAttachmentCard.Width = cardWidth;
            pnlLocationCard.Left = pnlCategoryCard.Left = pnlDescriptionCard.Left = pnlAttachmentCard.Left = (this.ClientSize.Width - cardWidth) / 2;

            // Input fields width
            txtLocation.Width = cmbCategory.Width = rtbDescription.Width = cardWidth - 20;
            txtLocation.Left = cmbCategory.Left = rtbDescription.Left = 10;

            // Preview image position
            pbPreview.Left = btnAttachMedia.Right + 20;

            // Center submit button
            btnSubmit.Left = (this.ClientSize.Width - btnSubmit.Width) / 2;

            // Progress bar
            progressBar.Width = cardWidth;
            progressBar.Left = (this.ClientSize.Width - cardWidth) / 2;

            // Status label (centered below progress bar)
            lblProgressStatus.Left = progressBar.Left + (progressBar.Width - lblProgressStatus.Width) / 2;
            lblProgressStatus.Top = progressBar.Bottom + 5; // 5px spacing

            // -----------------------------
            // Back Home Button: always stick to top-right
            btnBackHome.Top = 15;
            btnBackHome.Left = this.ClientSize.Width - btnBackHome.Width - 20; // 20px margin from right
        }
    }
}

