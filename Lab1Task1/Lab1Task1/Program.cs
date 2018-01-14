using System;

//почему не получается??? помогите

namespace Lab1Task1
{
    
    class Program
    {
        public static bool IsPrime(int N)
        {
            bool res = false;

            if (N == 2)
                res = true;
            
            for (int i = 2; i <= (N / 2); i++)
            {
                if (N % i == 0)
                {
                    res = false;
                    break;
                }
                else
                    res = true;
            }
            return res;
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 3, 5, 7, 14, 17 };
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                {
                    Console.WriteLine(array[i]);
                    Console.ReadKey();
                }
            }


        }
    }
}       



        
