using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab4BinarySerialization
{
    class Program
    {
        public static void f1()
        {
            FileStream fs = new FileStream( @"data.ser", FileMode.Create, FileAccess.Write);

            Complexnumbs cn = new Complexnumbs();

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs,cn);   
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                fs.Close();   
            }
        }

        public static void f2()
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Open, FileAccess.Read); // такая же фигняб не создается data.ser 

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Complexnumbs cs1 = bf.Deserialize(fs) as Complexnumbs; 

                Console.WriteLine(cs1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                fs.Close();
            }
        }

        static void Main(string[] args)
        {
            f2();
            Console.ReadKey();
            
        }
    }
}
