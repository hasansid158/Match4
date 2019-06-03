using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match4Project
{
    class LinkedList<T> where T : IComparable<T>
    {
        private Node head;
        private int length = 0;

        private class Node
        {
            public Node(T data)
            {
                this.data = data;
            }
            public T data;
            public Node next, prev;
        }

        public int Length
        {
            get
            {
                Node current = head;
                while (current != null)
                {
                    current = current.next;
                    length++;
                }
                return length;
            }
        }

        public void Add(T data)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
        }

        public T Get(int index)
        {
            Node current = head;
            int currentInd = 0;
            T value = default(T);

            while (current != null)
            {
                if (index == currentInd)
                {
                    value = current.data;
                }

                currentInd++;
                current = current.next;
            }
            return value;
        }

        public bool Contains(T data)
        {
            Node current = head;
            bool value = false;

            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    value = true;
                }

                current = current.next;
            }
            return value;
        }

        public void Clear()
        {
            Node current = head;

            while (current != null)
            {
                Node next = current.next;
                current = null;
                current = next;
            }
            head = null;
            Console.WriteLine("CLEARED");
        }

        public void Remove(T data)
        {
            if (head == null)
                return;

            if (head.data.Equals(data))
            {
                Node next = head.next;
                head = null;
                head = next;
            }
            else
            {
                Node current = head;
                Node prev = current.prev;

                while (current != null)
                {
                    if (current.data.Equals(data))
                    {
                        prev.next = current.next;
                    }
                    else
                    {
                        prev = current;
                    }
                    current = current.next;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (head == null)
                return;

            if (index == 0)
            {
                Node next = head.next;
                head = null;
                head = next;
            }
            else
            {
                int cur_index = 0;
                Node current = head;
                Node prev = current.prev;

                while (current != null)
                {
                    if (cur_index == index)
                    {
                        prev.next = current.next;
                        cur_index++;
                    }
                    else
                    {
                        prev = current;
                        current = current.next;
                        cur_index++;
                    }
                }
            }
        }

        public void Sort()
        {
            Node current = head;
            Node temp = head;
            T prevVal;

            if (current != null)
            {
                for (temp = head; temp.next != null; temp = temp.next)
                {
                    for (current = head; current.next != null; current = current.next)
                    {
                        if (current.next.data.CompareTo(current.data) <= 0)
                        {
                            prevVal = current.data;
                            current.data = current.next.data;
                            current.next.data = prevVal;
                        }
                    }
                }
            }
        }

        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
            Console.WriteLine("");
        }
    }
}
