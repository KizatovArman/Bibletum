using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
         double r = double.Parse(Console.ReadLine()) ;

            Circle c1 = new Circle(r);

            Console.WriteLine(c1);
            Console.ReadKey();
        }
    }
}
