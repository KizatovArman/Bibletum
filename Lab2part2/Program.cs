using System;
using System.IO;

namespace Lab2part2
{
    class Program
    {
        public static bool IsPrime(int N)
        {
            bool res = true;

            for (int i = 2; i <= (N / 2); i++)
            {
                if (N % i == 0)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public static int mini = 10000; 

        static void Main(string[] args)
        {
            string str = System.IO.File.ReadAllText(@"/Users/arman/Documents/Bibletum/W2Lab2/W2Lab2/input.txt");

            args = str.Split(" ");

            foreach(string s in args)
            {
                int ch1 = int.Parse(s);
                if (ch1 < mini)
                {
                    if (IsPrime(ch1))
                        mini = ch1;
                }
            }
            Console.WriteLine(mini + "\n");
            Console.ReadKey();
        }
    }
}
