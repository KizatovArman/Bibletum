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
        public static void F1(Complexnumbs cnn)
        {
            FileStream fs = new FileStream( @"data.ser", FileMode.Create, FileAccess.Write);

           // Complexnumbs cn = new Complexnumbs();

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs,cnn);   
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

        public static void F2(Complexnumbs cnn1)
        {
            FileStream fs = new FileStream(@"data.ser", FileMode.Open, FileAccess.Read); // такая же фигняб не создается data.ser 

            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                cnn1 = bf.Deserialize(fs) as Complexnumbs; 

                Console.WriteLine(cnn1);
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
            Complexnumbs cn1 = new Complexnumbs(15,14);
            Complexnumbs cn2 = new Complexnumbs();
            F1(cn1);
            F2(cn2);
            Console.ReadKey();
            
        }
    }
}
