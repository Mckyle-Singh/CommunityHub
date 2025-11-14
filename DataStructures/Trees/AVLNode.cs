using CommunityHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.DataStructures.Trees
{
    public class AVLNode
    {
        public ServiceRequest Data;
        public AVLNode Left;
        public AVLNode Right;
        public int Height;

        public AVLNode(ServiceRequest data)
        {
            Data = data;
            Height = 1;
        }
    }
}
