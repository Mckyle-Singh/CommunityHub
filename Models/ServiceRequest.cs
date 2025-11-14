using CommunityHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Models
{
    public class ServiceRequest
    {
        public string Id { get; set; }                     // e.g., "SRQ-001"
        public string ServiceType { get; set; }            // e.g., "Road Repair"
        public string Subject { get; set; }                // e.g., "Pothole on Main St."
        public RequestStatus Status { get; set; }          // Enum: Submitted, Assigned, etc.
        public int PriorityScore { get; set; }             // 0–100 scale for heap
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public string Area { get; set; }                   // e.g., "Ward 4", "Central", "Zone A"
        public List<string> Dependencies { get; set; }     // IDs of blocking requests
        public List<StatusHistoryEntry> StatusHistory { get; set; }

        public ServiceRequest(string id)
        {
            Id = id;
            Dependencies = new List<string>();
            StatusHistory = new List<StatusHistoryEntry>();
        }


    }
}
