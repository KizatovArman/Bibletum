using System;

namespace Lab1Student
{
    class Program
    {
        static void Main(string[] args)
        {
            double g1 = double.Parse(Console.ReadLine());
            double g2 = double.Parse(Console.ReadLine());
            double g3 = double.Parse(Console.ReadLine());
            double g4 = double.Parse(Console.ReadLine());
            Student S1 = new Student();
            Console.WriteLine(S1);
            Console.ReadKey();
        }
    }
}
