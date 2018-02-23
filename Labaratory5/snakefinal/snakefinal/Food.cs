using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakefinal
{
    [Serializable]
    public class Food
    {

        public Food() {}
        public Point location;
        public char sign;
        public ConsoleColor color;

        public Food(Snake sn, Wall w)
        {
            Random x1 = new Random();
            Random y1 = new Random();
            int _x = x1.Next(1, w.collumn - 2);
            int _y = y1.Next(1, w.row - 2);
            bool ok = true; 

            while (ok)
            {
                for (int i = 0; i < sn.body.Count; i++)
                {
                    if (sn.body[i].x == _x && sn.body[i].y == _y)
                    {
                        _x = x1.Next(1, w.collumn - 2);
                        _y = y1.Next(1, w.row - 2);
                        ok = true;
                        break;
                    }
                }

                foreach (Point p in w.body)
                {
                    if (p.x == _x && p.y == _y)
                    {
                        _x = x1.Next(1, w.collumn - 2);
                        _y = y1.Next(1, w.row - 2);
                        ok = true;
                        break;
                    }
                }
                location = new Point(_x, _y);
            }

            color = ConsoleColor.Green;
            sign = '@';
            location = new Point(10, 10);
        }

        public void SetRandomPosition()
        {
            int x = new Random().Next(0, 30);
            int y = new Random().Next(0, 15);


            location = new Point(x, y);
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}
