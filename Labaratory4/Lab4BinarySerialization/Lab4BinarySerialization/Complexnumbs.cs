using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab4BinarySerialization
{
    [Serializable]
    public class Complexnumbs
    {
        
        public int a, b;
        public Complexnumbs() { }
        public Complexnumbs ( int _a, int _b)
        {
            a = _a;
            b = _b;
        }

        public override string ToString()
        {
            return a + "/" + b;
        }
    }
}