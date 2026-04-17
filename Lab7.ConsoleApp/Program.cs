using System;
using Lab7.DataStructures;

namespace Lab7.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            LinkedList list = new LinkedList();

            list.AddLast(4.2f);
            list.AddLast(12.5f);
            list.AddLast(-3.1f);
            list.AddLast(15.0f);
            list.AddLast(-8.4f);
            list.AddLast(-10.0f);

            Console.WriteLine("~Виведення списку~");
            foreach (float item in list)
            {
                Console.Write($"{item}   ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("~Доступ по індексу~");
            int indexToRead = 5;
            float valueToRead = list[indexToRead];
            Console.WriteLine($"Елемент з індексом {indexToRead}: {valueToRead}");
            Console.WriteLine();

            Console.WriteLine("~Видалення по індексу~");
            int indexToRemove = 0;
            float valueToRemove = list[indexToRemove];
            Console.WriteLine($"Видалення елементу з індексом {indexToRemove} ({valueToRemove})...");
            list.RemoveAt(indexToRemove);

            Console.Write("~Список після видалення~ \n");
            foreach (float item in list)
            {
                Console.Write($"{item}   ");
            }
            Console.WriteLine("\n\n");

            float targetThreshold = 14.0f;

            Console.WriteLine($"1. Перший елемент більший за {targetThreshold}");
            float? firstGreater = list.FindFirstGreaterThan(targetThreshold);
            if (firstGreater.HasValue)
            {
                Console.WriteLine($"Елемент: {firstGreater.Value}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
            }
            Console.WriteLine();

            Console.WriteLine("2. Сума елементів, менших за перший від'ємний");
            try
            {
                float sum = list.CalculateSumLessThanFirstNegative();
                Console.WriteLine($"Сума: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine($"3. Список з елементами більшими за {targetThreshold}");
            LinkedList newList = list.GetListGreaterThan(targetThreshold);

            Console.Write("Новий список: ");
            foreach (float item in newList)
            {
                Console.Write($"{item}    ");
            }
            Console.WriteLine("\n");

            Console.ReadLine();
        }
    }
}