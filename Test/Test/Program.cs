using System;
using System.IO;

namespace Test
{
    class Program
    {

        public static bool IsPrime(int x)
        {
            bool res = true;
            for (int i = 2; i <= x / 2; i++)
            {
                if (x%i==0)
                {
                    res=false;
                    break;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(@"/Users/arman/Desktop/output.txt");
            StreamReader sr = new StreamReader(@"/Users/arman/Desktop/input.txt");
            string str = sr.ReadLine();
            int ch1 = int.Parse(str);
            StreamReader sr2 = new StreamReader(@"/Users/arman/Desktop/input.txt");
            string st = sr.ReadToEnd();
            string[] s = st.Split(" ");
            for (int j = 0; j < ch1; j++)
            {
                int ch2 = int.Parse(s[j]);
                if (IsPrime(ch2))
                {
                    Console.WriteLine(ch2.ToString());
                    Console.ReadKey();
                    sw.Write(ch2.ToString()+" "); 
                }
            }
            sw.Close();

        }
    }
}
