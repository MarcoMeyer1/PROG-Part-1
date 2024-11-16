using System;

namespace Part_1
{
    public class ServiceRequestBST
    {
        private class Node
        {
            public ServiceRequest Data;
            public Node Left;
            public Node Right;

            public Node(ServiceRequest data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public ServiceRequestBST()
        {
            root = null;
        }

        public void Insert(ServiceRequest request)
        {
            root = Insert(root, request);
        }

        private Node Insert(Node node, ServiceRequest request)
        {
            if (node == null)
                return new Node(request);

            if (request.ID < node.Data.ID)
                node.Left = Insert(node.Left, request);
            else if (request.ID > node.Data.ID)
                node.Right = Insert(node.Right, request);

            return node;
        }

        public ServiceRequest Find(int id)
        {
            return Find(root, id);
        }

        private ServiceRequest Find(Node node, int id)
        {
            if (node == null)
                return null;

            if (id == node.Data.ID)
                return node.Data;
            else if (id < node.Data.ID)
                return Find(node.Left, id);
            else
                return Find(node.Right, id);
        }

        public void InOrderTraversal(Action<ServiceRequest> action)
        {
            InOrderTraversal(root, action);
        }

        private void InOrderTraversal(Node node, Action<ServiceRequest> action)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left, action);
            action(node.Data);
            InOrderTraversal(node.Right, action);
        }
    }
}
