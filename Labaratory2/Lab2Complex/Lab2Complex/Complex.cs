using System;

namespace Lab2Complex

{
    public class Complex

    {
        public int x, y;

        public Complex(){}

        public Complex(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static Complex operator *(Complex com1, Complex com2)
        {
            Complex A = new Complex(com1.x * com2.x, com1.y * com2.y);
            A.Simplification();
            return A;
        }

        public static Complex operator /(Complex com3, Complex com4)
        {
            Complex B = new Complex(com3.x * com4.y, com3.y * com4.x);
            B.Simplification();
            return B;
        }

        public static Complex operator +(Complex com5, Complex com6)
        {
            Complex C = new Complex(com5.x * com6.y + com5.y * com6.x, com5.y * com6.y);
            C.Simplification();
            return C;
        }

        public static Complex operator -(Complex com7, Complex com8)
        {
            Complex D = new Complex(com7.x * com8.y - com7.y * com8.x, com7.y * com8.y);
            D.Simplification();
            return D;
        }
        //
        public override string ToString()
        {
            return x + "/" + y;
        }

        public void Simplification()
        {
            int _x = this.x;
            int _y = this.y;
            while (_x > 0 && _y > 0)
            {
                if (_x > _y)
                    _x = _x % _y;
                else
                    _y = _y % _x;
            }
            int gcd = _x + _y;
            x /= gcd;
            y /= gcd;
        }
    }
}
