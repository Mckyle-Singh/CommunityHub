using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Domain
{
    public class StatusHistoryEntry
    {
        public RequestStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string Actor { get; set; }          // Clerk or system
        public string Note { get; set; }

    }
}
