using System;

namespace Lab1Task1
{
    class Program
    {
        public static bool IsPrime(int N)// method to determine primeness of numbers;
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
        static void Main(string[] args)
        {
            /*
            int[] array = new int[] { 2, 3, 5, 7, 14, 17 };
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                {
                    Console.WriteLine(array[i]);
                    Console.ReadKey();
                }
            }
            I tried to find prime with "ready array";
            */
            string str = Console.ReadLine();//we gather our input
            args = str.Split(' ');//split our input string and obtain something like this {"1","2"...}
            foreach(string S in args)//cycle to look through our variables(циферки)
            {
                int ch1 = int.Parse(S);
                if (IsPrime(ch1)){//check for primeness
                    Console.WriteLine(ch1);//and print the answer
                }
            }
            Console.ReadKey();// wait until user press any button
        }
    }
}       



        
