using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
         double r = double.Parse(Console.ReadLine()) ;

            Circle c1 = new Circle(r);
            Circle c2 = new Circle();
            Console.WriteLine(c2);
            Console.WriteLine(c1);
            Console.ReadKey();
        }
    }
}
