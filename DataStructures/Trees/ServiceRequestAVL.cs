using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.Trees
{
    public class ServiceRequestAVL
    {
        private AVLNode root;

        public void Insert(ServiceRequest request)
        {
            root = InsertRecursive(root, request);
        }

        private AVLNode InsertRecursive(AVLNode node, ServiceRequest request)
        {
            if (node == null) return new AVLNode(request);

            int cmp = string.Compare(request.Id, node.Data.Id, StringComparison.OrdinalIgnoreCase);
            if (cmp < 0)
                node.Left = InsertRecursive(node.Left, request);
            else if (cmp > 0)
                node.Right = InsertRecursive(node.Right, request);
            else
                return node;

            UpdateHeight(node);
            return Balance(node);
        }

        private void UpdateHeight(AVLNode node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        private int GetHeight(AVLNode node) => node?.Height ?? 0;
        private int GetBalance(AVLNode node) => GetHeight(node.Left) - GetHeight(node.Right);

        private AVLNode Balance(AVLNode node)
        {
            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            UpdateHeight(y);
            UpdateHeight(x);
            return x;
        }

        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            UpdateHeight(x);
            UpdateHeight(y);
            return y;
        }

        public List<ServiceRequest> FilteredTraversal(Func<ServiceRequest, bool> predicate)
        {
            var result = new List<ServiceRequest>();
            TraverseWithFilter(root, predicate, result);
            return result;
        }

        private void TraverseWithFilter(AVLNode node, Func<ServiceRequest, bool> predicate, List<ServiceRequest> result)
        {
            if (node == null) return;
            TraverseWithFilter(node.Left, predicate, result);
            if (predicate(node.Data)) result.Add(node.Data);
            TraverseWithFilter(node.Right, predicate, result);
        }
    }
}


