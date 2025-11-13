using CommunityHub.DataStructures.Heaps;
using CommunityHub.DataStructures.Trees;
using CommunityHub.Domain;
using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunityHub
{
    public partial class ServiceStatusForm : Form
    {
        private ServiceRequestBST bst = new ServiceRequestBST();
        private ServiceRequestAVL avl = new ServiceRequestAVL();
        private MaxHeap<ServiceRequest> urgentHeap = new MaxHeap<ServiceRequest>((a, b) => a.PriorityScore.CompareTo(b.PriorityScore));


        public ServiceStatusForm()
        {
            InitializeComponent();
            this.Text = "Service Request Status";
            this.BackColor = Color.White;

            LoadSampleRequests();
            BindRequestsToTable();
            DisplayUrgentRequests();
        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {
            this.Close(); // Or navigate to HomePage if needed
        }

        private Panel CreateKpiTile(string title, string value, Color bgColor)
        {
            Panel tile = new Panel
            {
                Size = new Size(220, 80),
                BackColor = bgColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 35),
                AutoSize = true
            };

            tile.Controls.Add(lblTitle);
            tile.Controls.Add(lblValue);

            return tile;
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.SelectedItem.ToString();
            string category = cmbCategory.SelectedItem.ToString();
            string keyword = txtSearch.Text.Trim().ToLower();

            dgvRequests.Rows.Clear();

            var filtered = avl.FilteredTraversal(req =>
                (status == "All" || req.Status.ToString() == status) &&
                (category == "All" || req.ServiceType == category) &&
                (string.IsNullOrEmpty(keyword) || req.Subject.ToLower().Contains(keyword))
            );

            foreach (var req in filtered)
            {
                dgvRequests.Rows.Add(
                    req.Id,
                    req.ServiceType,
                    req.Status.ToString(),
                    req.CreatedAt.ToShortDateString(),
                    req.Subject
                );
            }
        }

        private void dgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRequests.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Pending")
                    e.CellStyle.ForeColor = Color.DarkOrange;
                else if (status == "Resolved")
                    e.CellStyle.ForeColor = Color.ForestGreen;
            }
        }


        /// <summary>
        /// Populates the Binary Search Tree (BST) with sample service requests.
        /// The requests are inserted out of order (REQ-002, REQ-001, REQ-003),
        /// and later retrieved in sorted order using InOrderTraversal() to populate the DataGridView.
        /// This confirms that the BST is functioning correctly.
        /// </summary>
        private void LoadSampleRequests()
        {
            var req1 = new ServiceRequest("REQ-001")
            {
                ServiceType = "Water",
                Subject = "Burst pipe on Main Street",
                Status = RequestStatus.Submitted,
                CreatedAt = new DateTime(2025, 11, 10),
                PriorityScore = 90
            };

            var req2 = new ServiceRequest("REQ-002")
            {
                ServiceType = "Electricity",
                Subject = "Power outage in Zone 3",
                Status = RequestStatus.Resolved,
                CreatedAt = new DateTime(2025, 11, 09),
                PriorityScore = 60
            };

            var req3 = new ServiceRequest("REQ-003")
            {
                ServiceType = "Roads",
                Subject = "Pothole near school entrance",
                Status = RequestStatus.Submitted,
                CreatedAt = new DateTime(2025, 11, 08),
                PriorityScore = 80
            };

            // Insert into BST and AVL
            bst.Insert(req1); avl.Insert(req1);
            bst.Insert(req2); avl.Insert(req2);
            bst.Insert(req3); avl.Insert(req3);

            // Insert into MaxHeap (for urgent triage)
            urgentHeap.Insert(req1);
            urgentHeap.Insert(req2);
            urgentHeap.Insert(req3);
        }

        private void BindRequestsToTable()
        {
            if (dgvRequests == null) return; // Safety check

            dgvRequests.Rows.Clear(); // Clear any existing rows

            foreach (var req in bst.InOrderTraversal())
            {
                dgvRequests.Rows.Add(
                    req.Id,
                    req.ServiceType,
                    req.Status.ToString(),
                    req.CreatedAt.ToShortDateString(),
                    req.Subject
                );
            }
        }

        private void DisplayUrgentRequests()
        {
            lvUrgentRequests.Items.Clear();

            // Get all requests from the heap
            var allUrgents = urgentHeap.PeekTopN(urgentHeap.Count);

            // Filter by PriorityScore ≥ 70
            var filtered = allUrgents.Where(r => r.PriorityScore >= 70);

            foreach (var req in filtered)
            {
                var item = new ListViewItem(req.Id);
                item.SubItems.Add(req.ServiceType); // or req.Category
                lvUrgentRequests.Items.Add(item);
            }
        }

    }
}
