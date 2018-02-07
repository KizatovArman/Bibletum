using System;
using System.Xml.Serialization;
using System.IO;
namespace Lab4Serialization
{
    [Serializable]
    public class Complex1
    {
        
        public int x, y;
        public Complex1(){}


        public Complex1(int _x,int _y)
        {
            x = _x;
            y = _y;
        }

       /* public static  Complex1 operator *(Complex1 com1, Complex1 com2)
        {
             Complex1 A = new Complex1(com1.x * com2.x, com1.y * com2.y);
            A.Simplizer();
            return A;

        }

        public static Complex1 operator /(Complex1 com3, Complex1 com4)
        {
            Complex1 B = new Complex1(com3.x * com4.y, com3.y * com4.x);
            B.Simplizer();
            return B;
        }
        */
        // and other "перегружение операторов"

        public override string ToString()
        {
            return x + "/" + y;
        }
        /*
        public void Simplizer()
        {
            int _x = x;
            int _y = y;
            int gcd;

            while (_x>0 && y>0)
            {
                if (_x > _y)
                    _x = _x % _y;
                else
                    _y = _x % _y;
            }
            gcd = _x + _y;

            x /= gcd;
            y /= gcd;
            */
        }
    }

