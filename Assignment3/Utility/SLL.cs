using System;
using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        private Node head;
        [DataMember]
        private Node tail;
        [DataMember]
        private int count;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Count())
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        public int Count()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void RemoveFirst()
        {
            if (!IsEmpty())
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (!IsEmpty())
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    Node current = head;
                    while (current.Next != tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    tail = current;
                }
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    tail = current;
                }
            }
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public void Reverse()
        {
            Node current = head;
            Node prev = null;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        public User[] CopyToArray()
        {
            User[] array = new User[Count()];
            Node current = head;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

            return array;
        }
    }
}
