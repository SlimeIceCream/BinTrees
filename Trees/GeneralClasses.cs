using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinTreeNode<T>
    {
        private T value;
        private BinTreeNode<T> left;
        private BinTreeNode<T> right;

        public BinTreeNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        public BinTreeNode(BinTreeNode<T> left, T value, BinTreeNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
        public T GetValue()
        {
            return value;
        }
        public BinTreeNode<T> GetLeft()
        {
            return left;
        }
        public BinTreeNode<T> GetRight()
        {
            return right;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetLeft(BinTreeNode<T> left)
        {
            this.left = left;
        }
        public void SetRight(BinTreeNode<T> right)
        {
            this.right = right;
        }
        public override string ToString()
        {
            return " ( " + left + " " + value + " " + right + " ) ";
        }
    }

    public class Stack<T>
    {
        public Stack()
        {
            this.arr = new T[5];
            this.t = -1;
        }

        private T[] arr;
        public int t;

        public void Push(T v)
        {
            if (t == arr.Length - 1)
            {
                T[] temp = new T[arr.Length * 2];
                for (int i = 0; i < this.arr.Length; i++)
                {
                    temp[i] = arr[i];
                }
                this.arr = temp;
            }
            t++;
            arr[t] = v;

        }
        public T Top()
        {
            T v = arr[t];
            return v;
        }
        public T Pop()
        {
            T v = arr[t];
            t--;
            return v;
        }
        public bool IsEmpty()
        {
            return t == -1 ? true : false;
        }
        public override string ToString()
        {
            if (IsEmpty())
                return "[]";
            string s = "[";
            for (int i = 0; i <= t; i++)
            {
                s = s + arr[i] + ",";
            }
            return s.Substring(0, s.Length - 1) + "]";
        }
    }

    public class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T GetValue()
        {
            return value;
        }

        public Node<T> GetNext()
        {
            return next;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetNext(Node<T> next)
        {
            this.next = next;
        }



        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    public class List<T>
    {
        private Node<T> first;

        public List()
        {
            this.first = null;
        }

        public Node<T> GetFirst()
        {
            return first;
        }

        public Node<T> Insert(Node<T> p, T info)
        {
            Node<T> q = new Node<T>(info);
            if (p == null)
            {
                q.SetNext(first);
                first = q;
            }
            else
            {
                q.SetNext(p.GetNext());
                p.SetNext(q);
            }
            return q;
        }

        public Node<T> Remove(Node<T> p)
        {
            if (first == p)
            {
                first = p.GetNext();
                return first;
            }
            else
            {
                Node<T> prev = first;
                while (prev.GetNext() != p) prev = prev.GetNext();
                prev.SetNext(p.GetNext());
                return prev.GetNext();
            }
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public override string ToString()
        {
            string s = "[";
            Node<T> p = this.first;
            while (p != null)
            {
                s = s + p.GetValue().ToString();
                if (p.GetNext() != null)
                    s = s + ",";
                p = p.GetNext();
            }
            s = s + "]";
            return s;
        }
    }
}
