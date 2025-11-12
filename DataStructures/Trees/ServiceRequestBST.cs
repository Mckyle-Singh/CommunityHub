using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.Trees
{
    public class ServiceRequestBST
    {
        private ServiceRequestNode root;

        public void Insert(ServiceRequest request)
        {
            root = InsertRecursive(root, request);
        }

        private ServiceRequestNode InsertRecursive(ServiceRequestNode node, ServiceRequest request)
        {
            if (node == null)
                return new ServiceRequestNode(request);

            int comparison = string.Compare(request.Id, node.Data.Id, StringComparison.OrdinalIgnoreCase);
            if (comparison < 0)
                node.Left = InsertRecursive(node.Left, request);
            else if (comparison > 0)
                node.Right = InsertRecursive(node.Right, request);

            return node;
        }

        public ServiceRequest Search(string id)
        {
            return SearchRecursive(root, id);
        }

        private ServiceRequest SearchRecursive(ServiceRequestNode node, string id)
        {
            if (node == null)
                return null;

            int comparison = string.Compare(id, node.Data.Id, StringComparison.OrdinalIgnoreCase);
            if (comparison == 0)
                return node.Data;
            else if (comparison < 0)
                return SearchRecursive(node.Left, id);
            else
                return SearchRecursive(node.Right, id);
        }

        public List<ServiceRequest> InOrderTraversal()
        {
            var result = new List<ServiceRequest>();
            TraverseInOrder(root, result);
            return result;
        }

        private void TraverseInOrder(ServiceRequestNode node, List<ServiceRequest> result)
        {
            if (node == null) return;
            TraverseInOrder(node.Left, result);
            result.Add(node.Data);
            TraverseInOrder(node.Right, result);
        }

    }
}
