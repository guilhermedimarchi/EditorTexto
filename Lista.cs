using System;

namespace Editor
{
    /// <summary>
    /// Lista duplamente ligada linear
    /// </summary>
    public class ListaDupla
    {
        private Node list;
        private int count;

        public Node FirstNode
        {
            get { return list; }
        }
        public int Count
        {
            get { return count; }
        }

        // Construtor
        public ListaDupla()
        {
            list = null;
            count = 0;
        }

        // Se está vazia
        public bool Empty()
        {
            return (count==0);
        }

        // Insere um novo nó
        public void Insert(Node p, object x)
        {
            Node n = new Node();
            n.Info = x;
            n.Next = null;
            n.Prior = null;
            count++;


            if (list == null)
                list = n;
            else if(p==null)
            {
                n.Next = list;
                list.Prior = n;
                list = n;
            }
            else
            {
                if (p.Next != null)
                {
                    n.Next = p.Next;
                    n.Next.Prior = n;
                }

                n.Prior = p;
                p.Next = n;
            }
            

        }

        // Remove um nó
        public void Remove(Node p)
        {
            count--;

            if (p.Next == null)
                p.Prior.Next = null;
            else
            {
                p.Next.Prior = p.Prior;
            }

            if (p.Prior == null)
            {
                p.Next.Prior = null;
            }
            else
            {
                p.Prior.Next = p.Next;
            }
        }

        public void Delete(Node p)
        {
            count--;

            if (p.Next.Next != null)
            {
                p.Next.Next.Prior = p;
                p.Next = p.Next.Next;
            }
            else 
            { 
                p.Next = null; 
            }
           
        }

    }

}
