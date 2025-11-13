using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Domain
{
    public enum RequestStatus
    {
        Submitted,
        Verified,
        Scheduled,
        Assigned,
        InProgress,
        Blocked,
        Resolved
    }
}
