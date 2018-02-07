using System;
using System.IO;

namespace W2Lab2
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string str = System.IO.File.ReadAllText(@"/Users/arman/Documents/Bibletum/W2Lab2/W2Lab2/input.txt");

            string[] arr = str.Split(" ");
            int maxi = int.Parse(arr[0]);
            int mini = int.Parse(arr[1]);
            foreach(string s in arr)
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
