using System;
using System.Xml.Serialization;
using System.IO;

namespace Lab4Serialization
{
    class Program
    {
        static void FunctionToSer()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);// не знаю почему но на маке не хочет создавать data.xml

            XmlSerializer xs = new XmlSerializer(typeof(Complex1));

            Complex1 c1 = new Complex1();
            try
            {
                xs.Serialize(fs, c1);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("done");
        }

        static void FunctionToDeSer()
        {

            FileStream sf = new FileStream(@"data.xml", FileMode.Open, FileAccess.Read);

            XmlSerializer sx = new XmlSerializer(typeof(Complex1));

            try
            {
                Complex1 c2 = sx.Deserialize(sf) as Complex1;

                Console.WriteLine(c2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);// сообщить об ошибке
            }
            finally
            {
                sf.Close();
            }
        }

        static void Main(string[] args)
        {
           //
            FunctionToDeSer();
            Console.ReadKey();
        }
    }
}
