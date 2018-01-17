using System;
using System.IO;

namespace W2Lab2
{
    class Program
    {
        public static int mini = 10000;
        public static int maxi = 0;

        static void Main(string[] args)
        {

            string str = System.IO.File.ReadAllText(@"/Users/arman/Documents/Bibletum/W2Lab2/W2Lab2/input.txt");

            args = str.Split(" ");

            foreach(string s in args)
            {
                int ch1 = int.Parse(s);
                if (ch1>maxi)
                {
                    maxi = ch1;
                }

                if (ch1 < mini)
                {
                    mini = ch1;
                }

            }
            Console.WriteLine(maxi + "\n" + mini);
            Console.ReadKey();
        }
    }
}
