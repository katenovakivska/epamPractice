using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class MyTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public event EventHandler<MyTreeEventArgs<T>> OnInsert;
        public event EventHandler<MyTreeEventArgs<T>> OnRemove;

        public MyTree()
        {
            Root = null;
        }

        public void Insert(T Data)
        {
            if (ReferenceEquals(Data, null))
                throw new ArgumentNullException("Node can not have null value");

            Node<T> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (Data.CompareTo(after.Data) == -1)
                    after = after.Left;
                else
                {
                    after = after.Right;
                }
            }

            Node<T> newNode = new Node<T>(Data);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else if (Data.CompareTo(before.Data) == -1)
            {
                before.Left = newNode;
            }
            else
            {
                before.Right = newNode;
            }
            if (!ReferenceEquals(OnInsert, null))
                OnInsert(this, new MyTreeEventArgs<T>(newNode.Data));
        }

        public void Remove(T Data)
        {
            if (ReferenceEquals(Data, null))
                throw new ArgumentNullException("Node can not have null value");

            Remove(this.Root, Data);
            if (!ReferenceEquals(OnRemove, null))
                OnRemove(this, new MyTreeEventArgs<T>(Data));
        }

        public Node<T> Remove(Node<T> parent, T Data)
        {
            if (parent == null)
                return parent;

            if (Data.CompareTo(parent.Data) == -1)
                parent.Left = Remove(parent.Left, Data);
            else if (Data.CompareTo(parent.Data) == 1)
                parent.Right = Remove(parent.Right, Data);
            else
            {
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;

                parent.Data = MinValue(parent.Right);
                parent.Right = Remove(parent.Right, parent.Data);
            }

            return parent;

        }

        public bool Find(T Data)
        {
            if (ReferenceEquals(Data, null))
                throw new ArgumentNullException("Node can not have null value");

            if (ReferenceEquals(Find(Data, this.Root), null))
                return false;
            else
                return true;
        }

        public Node<T> Find(T Data, Node<T> parent)
        {
            if (parent != null)
            {
                if (Data.CompareTo(parent.Data) == 0)
                    return parent;
                if (Data.CompareTo(parent.Data) == -1)
                    return Find(Data, parent.Left);
                if (Data.CompareTo(parent.Data) == 1)
                    return Find(Data, parent.Right);
            }
            return null;
        }
        public T MinValue(Node<T> node)
        {
            T min = node.Data;

            while (node.Left != null)
            {
                min = node.Left.Data;
                node = node.Left;
            }

            return min;
        }

        public IEnumerable<T> LevelTraverse()
        {
            if (Root == null) yield break;

            var queue = new Queue<Node<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Data;
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return LevelTraverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}
