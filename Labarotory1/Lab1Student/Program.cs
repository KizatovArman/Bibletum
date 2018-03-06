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

            Student s2 = new Student("KBTU", "FIT",g1,g2,g3,g4);
            Console.WriteLine(S1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
