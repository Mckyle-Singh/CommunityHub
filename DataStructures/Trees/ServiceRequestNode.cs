using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.Trees
{
    public class ServiceRequestNode
    {
        public ServiceRequest Data { get; set; }
        public ServiceRequestNode Left { get; set; }
        public ServiceRequestNode Right { get; set; }

        public ServiceRequestNode(ServiceRequest request)
        {
            Data = request;
            Left = null;
            Right = null;
        }

    }
}
