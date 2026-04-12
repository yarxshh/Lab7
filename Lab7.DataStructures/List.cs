using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab7.DataStructures
{
    /// <summary>
    /// Вузол односпрямованого зв'язаного списку.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Значення елемента списку.
        /// </summary>
        public float Data { get; set; }

        /// <summary>
        /// Посилання на наступний вузол.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Конструктор вузла.
        /// </summary>
        /// <param name="data">Значення типу float.</param>
        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// Власна структура даних: Односпрямований лінійний список для типу float.
    /// </summary>
    public class LinkedList : IEnumerable<float>
    {
        /// <summary>
        /// Посилання на перший елемент списку (голову).
        /// </summary>
        private Node _head;

        /// <summary>
        /// Посилання на останній елемент списку (хвіст).
        /// </summary>
        private Node _tail;

        /// <summary>
        /// Кількість елементів у списку.
        /// </summary>
        private int _count;

        /// <summary>
        /// Індексатор для доступу до елементів на читання за індексом
        /// </summary>
        /// <param name="index">Індекс</param>
        /// <returns>значення елемента</returns>
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException("Індекс знаходиться поза межами списку.");
                }

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        /// <summary>
        /// Додавання елементу в кінець списку
        /// </summary>
        /// <param name="data">Значення для додавання.</param>
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

        /// <summary>
        /// Видалення елементу за заданим індексом
        /// </summary>
        /// <param name="index">елемент для видалення</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Індекс знаходиться поза межами списку.");
            }

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

        /// <summary>
        /// Операція 1: Знайти перший елемент, більший за задане значення.
        /// </summary>
        /// <param name="threshold">Граничне значення для порівняння.</param>
        /// <returns>Значення знайденого елемента, або null, якщо такого немає.</returns>
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

        /// <summary>
        /// Операція 2: Знайти суму елементів, значення яких менші за значення першого від'ємного елементу.
        /// </summary>
        /// <returns>Сума елементів.</returns>
        /// <exception cref="InvalidOperationException">Викидається, якщо від'ємний елемент не знайдено.</exception>
        public float CalculateSumLessThanFirstNegative()
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

            float sum = 0;
            current = _head;

            while (current != null)
            {
                if (current.Data < firstNegativeValue.Value)
                {
                    sum += current.Data;
                }
                current = current.Next;
            }

            return sum;
        }

        /// <summary>
        /// новий список зі значень елементів, більших за задане.
        /// </summary>
        /// <param name="threshold">значення для порівняння.</param>
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

        /// <summary>
        /// для можливості використання foreach.
        /// </summary>
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
