using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.GraphTraversal
{
    public static class DfsTraversal
    {
        public static List<ServiceRequest> GetBlockedChain(string startId, Dictionary<string, ServiceRequest> allRequests)
        {
            var visited = new HashSet<string>();
            var chain = new List<ServiceRequest>();

            void DFS(string currentId)
            {
                if (visited.Contains(currentId) || !allRequests.ContainsKey(currentId)) return;
                visited.Add(currentId);

                var req = allRequests[currentId];
                chain.Add(req);

                foreach (var depId in req.Dependencies)
                    DFS(depId);
            }

            DFS(startId);
            return chain;
        }

    }
}
