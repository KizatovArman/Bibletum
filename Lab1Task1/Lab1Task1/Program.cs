using System;

//почему не получается??? помогите

namespace Lab1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string s = Console.ReadLine();
            int n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                string s1 = Console.ReadLine();
                int x = int.Parse(s1); 
                if (IsPrime(x)){
                    Console.WriteLine(x);
                }
            }
            */

            int n;
            n = Convert.ToInt16(Console.ReadLine());
            // массив A с n-элементами 
            double[] A = new double[n];
            int i = 0;
            while (i < n)
            {
                /* Вводим элементы массива с клавиатуры 
                 * и заполняем ими массив */
                A[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
                i++;
            }
            // Вывод всех прайм чисел
            for (i = 0; i < n; i++)
            {
                if (IsPrime(A[i]))
                Console.WriteLine(A[i] + " ");
                Console.ReadKey();
            }
        }
        //метод определябщий является число простым или нет
        public static bool IsPrime(double N)
        {
            bool res = false;

            for (double i = 2; i < (N / 2); i++)
            {
                if (N % i == 0)
                {
                    res = false;
                    break;
                }
                else
                {
                    res = true;
                }
            }
            return res;
        }
    }
}

        
