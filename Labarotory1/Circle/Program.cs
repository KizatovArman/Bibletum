using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
         double r = double.Parse(Console.ReadLine()) ;

            Circle c1 = new Circle(r);
            int a = 2;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
