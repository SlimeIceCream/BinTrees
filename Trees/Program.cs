using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            /*           
             in order:   H, E, A, J, I, C, B, D, G, F -> [H, E, A, J, I], [B, D, G, F] -> [H, E], [J, I], [G, F] ...
             post order: E, H, J, I, A, B, F, G, D, C
             Tree:    C
                    /   \
                   A     D
                  / \   / \
                 H   I B   G
                 \  /       \
                  E J        F
            */
            BinTreeNode<int> e = new BinTreeNode<int>(5);
            BinTreeNode<int> d = new BinTreeNode<int>(10);
            BinTreeNode<int> c = new BinTreeNode<int>(d, 1, e);
            BinTreeNode<int> b = new BinTreeNode<int>(9);
            BinTreeNode<int> a = new BinTreeNode<int>(b, 2, c); //root
            Console.WriteLine("Page One:");
            Console.WriteLine(IsInTree(a, 5));
            Console.WriteLine(CountVertices(a));
            Console.WriteLine(SumValues(a));
            Console.WriteLine(CountLeaves(a));
            Console.WriteLine(CountFullVertices(a));
            Console.WriteLine(CountPartialVertices(a));
            Console.WriteLine("Page Two:");
            //DivideEvens(a); //Leaving it off for other tests.
            Console.WriteLine(d.GetValue()); //example
            //AddZeroToPartial(a);
            //Console.WriteLine(c.GetLeft().GetValue()); //set c.Left = null and check
            Console.WriteLine(CountEvenVertices(a)); //Note: after running DivideEvens this should be 0 - mark it as a comment for a different result.
            Console.WriteLine(SumRightNodes(a));
            try
            {
                Console.WriteLine(GetParent(a, 1).GetValue());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No parent");
            }
            Console.WriteLine(IsAllEven(a));

            Console.WriteLine("Page Three:");
            Node<int> p = TurnToSortedList(null, a);
                //TurnToSortedList(a, null);
            while (p != null)
            { 
                Console.WriteLine(p.GetValue());
                p = p.GetNext();
            }
        }

        public static bool IsInTree(BinTreeNode<int> r, int v)
        {
            if (r == null) return false;
            if (r.GetValue() == v) return true;
            return IsInTree(r.GetLeft(),v) || IsInTree(r.GetRight(),v);
        }

        public static int CountVertices(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            return 1 + CountVertices(r.GetLeft()) + CountVertices(r.GetRight());
        }

        public static int SumValues(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            return r.GetValue() + SumValues(r.GetLeft()) + SumValues(r.GetRight());
        }

        public static int CountLeaves(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            if (r.GetRight() == null && r.GetLeft() == null) return 1;
            return CountLeaves(r.GetRight()) + CountLeaves(r.GetLeft()); 
        }

        public static int CountFullVertices(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            if (r.GetRight() != null && r.GetLeft() != null) return 1+ CountFullVertices(r.GetRight()) + CountFullVertices(r.GetLeft());
            return CountFullVertices(r.GetRight()) + CountFullVertices(r.GetLeft());
        }

        public static int CountPartialVertices(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            if ((r.GetRight() != null && r.GetLeft() == null) || r.GetLeft() != null && r.GetRight() == null) return 1 + CountPartialVertices(r.GetRight()) + CountPartialVertices(r.GetLeft());
            return CountPartialVertices(r.GetRight()) + CountPartialVertices(r.GetLeft());
        }

        public static bool IsFullTree(BinTreeNode<int> r)
        {
            if (CountPartialVertices(r) == 0) return true;
            return false;
        }

        public static void DivideEvens(BinTreeNode<int> r)
        {
            if (r == null) return;
            if(r.GetValue() % 2 == 0) r.SetValue(r.GetValue() / 2);
            DivideEvens(r.GetLeft());
            DivideEvens(r.GetRight());
        }

        public static void AddZeroToPartial(BinTreeNode<int> r)
        {
            if (r == null) return;
            if (r.GetLeft() != null && r.GetRight() == null)
            {
                r.SetRight(new BinTreeNode<int>(0));
                AddZeroToPartial(r.GetLeft());
            }
            else if (r.GetLeft() == null && r.GetRight() != null)
            {
                r.SetLeft(new BinTreeNode<int>(0));
                AddZeroToPartial(r.GetRight());
            }
            else
            {
                AddZeroToPartial(r.GetLeft());
                AddZeroToPartial(r.GetRight());
            }
        }

        public static int CountEvenVertices(BinTreeNode<int> r)
        {
            if (r == null) return 0;
            if (r.GetValue() % 2 == 0) return 1 + CountEvenVertices(r.GetLeft()) + CountEvenVertices(r.GetRight());
            return CountEvenVertices(r.GetLeft()) + CountEvenVertices(r.GetRight());
        }

        public static int SumRightNodes(BinTreeNode<int> r)
        {
            if (r.GetRight() == null) return 0;
            return r.GetRight().GetValue() + SumRightNodes(r.GetRight()) + SumRightNodes(r.GetLeft());
        }

        public static BinTreeNode<int> GetParent(BinTreeNode<int> r, int v)
        {
            if (r.GetLeft() == null && r.GetRight() == null) return null;
            if (r.GetLeft().GetValue() == v || r.GetRight().GetValue() == v) return r;
            GetParent(r.GetLeft(), v);
            GetParent(r.GetRight(), v);
            return null;
        }

        public static bool IsAllEven(BinTreeNode<int> r)
        {
            if (r == null) return true;
            if (r.GetValue() % 2 == 1) return false;
            return IsAllEven(r.GetRight()) && IsAllEven(r.GetLeft());
        }

        public static Node<int> TurnToSortedList(Node<int> h, BinTreeNode<int> r)
        {
            if (r == null)
            {
                return h;
            }
            h = TurnToSortedList(h, r.GetLeft());
            Node<int> t = new Node<int>(r.GetValue());
            Node<int> temp = h;
            Node<int> p = null;
            if (temp == null)
            {
                h = t;
            }
            else
            {
                FindNode(r, ref temp, ref p);
                h = AttachNode(h, t, temp, p);
            } 
            h = TurnToSortedList(h, r.GetRight());
            return h;
        }
        private static Node<int> AttachNode(Node<int> h, Node<int> t, Node<int> temp, Node<int> p)
        {

            if (temp == null)
            {
                p.SetNext(t);
            }
            else
            {
                if (p == null)
                {
                    t.SetNext(temp);
                    h = t;
                }
                else
                {
                    t.SetNext(temp);
                    p.SetNext(t);
                }
            }

            return h;
        }
        public static void FindNode(BinTreeNode<int> r, ref Node<int> temp, ref Node<int> p)
        {
            while (temp != null)
            {
                if (temp.GetValue() > r.GetValue())
                {
                    break;
                }
                else
                {
                    p = temp;
                    temp = temp.GetNext();
                }
            }
        }
    }
}
