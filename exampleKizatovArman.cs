using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exampleKizatovArman
{
	class Program
	{
		public static bool IsPrime(int x){
			if (x==1) 
			return false;
			bool result = true;
			for (int i = 2 ; i < sqrt(x); i++){
				if (x%i==0){
					result = true;
					break;
				}
			}
			return result;
		}

		static void Main(string[] args){
			string s = Console.ReadLine();
			string[] a = Line.Split(" ");
			for (int i = 0; i < a.Lenght; i++){
				
			}
		}
	}
}
