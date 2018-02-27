using System;

namespace Lab2Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] token = s.Split();
            string[] s1 = token[0].Split('/'); 
            string[] s2 = token[1].Split('/');
            Complex a = new Complex(int.Parse(s1[0]), int.Parse(s1[1]));
            Complex b = new Complex(int.Parse(s2[0]), int.Parse(s2[1]));
            Complex c = a * b;
            Complex d = a / b;
            Complex e = a + b;
            Complex f = a - b;
            Console.WriteLine("Multiplication "+ c + "\n" + "Division "+ d+ "\n" + "Addition "+ e + "\n" + "Substraction "+f);
            Console.ReadKey();

        }
    }
}
