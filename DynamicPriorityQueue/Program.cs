using System;

namespace DynamicPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            //Create queue
            DynamicPriorityQueue<string> qNames = new DynamicPriorityQueue<string>();

            //Enqueue some test data
            qNames.Enqueue("Mike", 2);
            qNames.Enqueue("Thabo", 3);
            qNames.Enqueue("Lily", 5);
            qNames.Enqueue("Susan", 1);
            qNames.Enqueue("Mary", 1);
            qNames.Dequeue();
            qNames.Enqueue("John", 2);
            qNames.Enqueue("Peter", 4);
            qNames.Enqueue("Hendrik", 2);
            qNames.Enqueue("Kgomotso", 3);

            //Peek first element
            Console.WriteLine("\tFirst name: " + qNames.Peek());
            Console.WriteLine();

            if (qNames.Contains("Peter"))
                Console.WriteLine("\tPosition of 'Peter': " + qNames.Position("Peter"));
            else
                Console.WriteLine("\t'Peter' is not in the queue.");
            Console.WriteLine();

            //Dequeue and print names
            Console.Write("\tList names: ");
            while (qNames.Count > 0)
                Console.Write(qNames.Dequeue() + ", ");
            Console.WriteLine();

            //Opportunity to read output
            Console.WriteLine();
            Console.Write("\tPress any key to exit ...");
            Console.ReadKey();
        } //Main
    } //class {rogram
} //namespace
