using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab7.DataStructures
{
    public class Node
    {
        public float Data { get; set; }

        public Node Next { get; set; }

        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList : IEnumerable<float>
    {
        private Node _head;

        private Node _tail;

        private int _count;

        public float this[int index]
        {
            get
            {
                ValidateIndex(index);

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        public void AddLast(float data)
        {
            Node newNode = new Node(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            if (index == 0)
            {
                _head = _head.Next;
                if (_head == null)
                {
                    _tail = null;
                }
            }
            else
            {
                Node previous = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    previous = previous.Next;
                }

                previous.Next = previous.Next.Next;

                if (previous.Next == null)
                {
                    _tail = previous;
                }
            }
            _count--;
        }

        public float? FindFirstGreaterThan(float threshold)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data > threshold)
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }

        public float FindFirstNegative()
        {
            float? firstNegativeValue = null;
            Node current = _head;

            while (current != null)
            {
                if (current.Data < 0)
                {
                    firstNegativeValue = current.Data;
                    break;
                }
                current = current.Next;
            }

            if (!firstNegativeValue.HasValue)
            {
                throw new InvalidOperationException("У списку немає від'ємних елементів.");
            }

            return firstNegativeValue.Value;
        }
        
        public float CalculateSumLessThanFirstNegative()
        {
            float firstNegativeValue = FindFirstNegative();
            Node current = _head;

            float sum = 0;
            current = _head;

            while (current != null)
            {
                if (current.Data < firstNegativeValue)
                {
                    sum += current.Data;
                }
                current = current.Next;
            }

            return sum;
        }

        public void ValidateIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Індекс знаходиться поза межами списку.");
            }
        }

        public LinkedList GetListGreaterThan(float threshold)
        {
            LinkedList newList = new LinkedList();
            Node current = _head;

            while (current != null)
            {
                if (current.Data > threshold)
                {
                    newList.AddLast(current.Data);
                }
                current = current.Next;
            }

            return newList;
        }

        public IEnumerator<float> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
