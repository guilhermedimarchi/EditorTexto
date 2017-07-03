using System;

namespace Editor
{
    // Classe do nó
    public class Node
    {
        private object info;
        private Node next, prior;

        public object Info
        {
            get { return info; }
            set { info = value; }
        }
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node Prior
        {
            get { return prior; }
            set { prior = value; }
        }
    }
}
